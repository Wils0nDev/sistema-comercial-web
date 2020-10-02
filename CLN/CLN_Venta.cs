using CAD;
using CEN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLN_Venta
    {
        public List<CENPreventaFiltroPA> listarPreventaFiltro(CENPreventaFiltro data)
        {
            CADVenta cadVenta = new CADVenta();
            CLNConsultas consulta = new CLNConsultas();

            List<CENPreventaFiltroPA> respuesta = new List<CENPreventaFiltroPA>();
            try
            {
                respuesta = cadVenta.listarPreventaFiltro(data);
                for (int i = CENConstante.g_const_0; i < respuesta.Count; i++)
                {
                    //respuesta[i].igv = consulta.RedondeoMontoFavorCliente(respuesta[i].igv);
                    respuesta[i].total = consulta.RedondeoMontoFavorCliente(respuesta[i].total);
                    //respuesta[i].recargo = consulta.RedondeoMontoFavorCliente(respuesta[i].recargo);
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CENRespVenta RegistrarVenta(int codPreventa, int codCliente, int codVendedor, string fechPag, int tipoVenta,
            int tipoMoneda, double recargo, double IGV, double total, int sucursal, int tipoDocumentoVenta, int codPuntoEntrega)
        {
            CENRespVenta respuesta = new CENRespVenta();
            CADVenta cad_venta = new CADVenta();
            CEN_DataVenta requestData = new CEN_DataVenta();
            RequestApiBoleta dataApi = new RequestApiBoleta();
            CLNConexionServicio conServicio = new CLNConexionServicio();
            ResponseApi responseApi = new ResponseApi();
            int estadoSUNAT = CENConstante.g_const_0;
            string tramaSUNAT = CENConstante.g_const_vacio;
            try
            {
                requestData = LlenarDataVenta(codPreventa, codCliente, codVendedor, fechPag, tipoVenta, tipoMoneda,
                    recargo, IGV, total, sucursal, tipoDocumentoVenta, codPuntoEntrega);
                respuesta = cad_venta.registrarVenta(requestData);
                if (respuesta.venta > CENConstante.g_const_0)
                {
                    //Registro de comprobante sunat
                    CLNComprobanteSunat comprobante = new CLNComprobanteSunat();
                    CENComprobSunat dataComprob = new CENComprobSunat();
                    int codigoComprob = CENConstante.g_const_0;
                    string trama = CENConstante.g_const_vacio;
                    dataComprob.codModulo = CENConstante.g_const_1;
                    dataComprob.codTransaccion = respuesta.venta;
                    dataComprob.tipDocSunat = CENConstante.g_const_1;
                    dataComprob.tipDocVenta = requestData.tipoVenta;
                    dataComprob.estado = CENConstante.g_const_1;
                    dataComprob.usuario = requestData.usuario;
                    dataComprob.ip = CENConstante.g_const_vacio;
                    dataComprob.mac = CENConstante.g_const_vacio;




                    //AGREGAR TRAMA PARA COMPROBANTE
                    if (requestData.tipoDocumentoVenta == CENConstante.g_const_1)
                    {
                        //Boleta
                        dataApi = ObtenerDataComprobante(requestData, respuesta, "0101");
                        trama = JsonConvert.SerializeObject(dataApi);
                    }
                    else if (requestData.tipoDocumentoVenta == CENConstante.g_const_2)
                    {
                        //Factura
                        dataApi = ObtenerDataComprobante(requestData, respuesta, "0101");
                        trama = JsonConvert.SerializeObject(dataApi);
                    }
                    dataComprob.tramEntrada = trama;
                    codigoComprob = comprobante.RegistrarComprobSunat(dataComprob);

                    if (codigoComprob > CENConstante.g_const_0)
                    {
                        //ENVIO A LA SUNAT
                        responseApi = conServicio.RegistrarBoleta(dataApi);
                        tramaSUNAT = JsonConvert.SerializeObject(responseApi);
                        if (responseApi.sunatResponse.success)
                        {
                            //ACTUALIZAR COMPROBANTE DE LA SUNAT
                            estadoSUNAT = CENConstante.g_const_1;
                        }
                        else
                        {
                            //ACTUALIZAR COMPROBANTE DE LA SUNAT
                            estadoSUNAT = CENConstante.g_const_2;
                        }
                        /*
                        if (requestData.tipoDocumentoVenta == CENConstante.g_const_1)
                        {
                            //Boleta
                            responseApi= conServicio.RegistrarBoleta(dataApi);
                            tramaSUNAT = JsonConvert.SerializeObject(responseApi);
                            if (responseApi.sunatResponse.success)
                            {
                                //ACTUALIZAR COMPROBANTE DE LA SUNAT
                                estadoSUNAT = CENConstante.g_const_1;
                            }
                            else
                            {
                                //ACTUALIZAR COMPROBANTE DE LA SUNAT
                                estadoSUNAT = CENConstante.g_const_2;
                            }

                        }
                        else if (requestData.tipoDocumentoVenta == CENConstante.g_const_2)
                        {
                            //Factura

                        }
                        */
                        comprobante.ActualizarComprobSunat(codigoComprob, tramaSUNAT, estadoSUNAT);
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        private RequestApiBoleta ObtenerDataComprobante(CEN_DataVenta requestData, CENRespVenta respuesta, string tipoOperacion)
        {
            RequestApiBoleta data = new RequestApiBoleta();
            CENApiNC obj = new CENApiNC();
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            try
            {


                obj = cadNotaCredito.obtenerDatosSunat(respuesta.venta, CENConstante.g_const_0, respuesta.venta);
                data.tipoOperacion = tipoOperacion;
                data.tipoDoc = obj.tipoDoc;
                data.serie = respuesta.serie;
                data.correlativo = respuesta.nroDocumento.ToString();
                data.fechaEmision = obj.fechaEmision;
                data.tipoMoneda = obj.tipoMoneda;
                data.mtoOperGravadas = obj.mtoOperGravadas;
                data.mtoIGV = obj.mtoIGV;
                data.totalImpuestos = obj.totalImpuestos;
                data.mtoImpVenta = obj.mtoImpVenta;
                data.ublVersion = obj.ublVersion;

                data.valorVenta = data.mtoImpVenta / 1.18;
                data.valorVenta = Math.Round(data.valorVenta, CENConstante.g_const_2); //returns 1.99
                //Cliente

                data.client = obj.client;
                /*
                data.client.tipoDoc = "1";
                data.client.numDoc = "77388057";
                data.client.address.direccion = "DIRECCION";
                */
                //Empresa
                data.company = obj.company;
                /*
                data.company.address.direccion = "DIRECCION EMPRESA";
                data.company.ruc = "10773880579";
                data.company.razonSocial = "RAZON SOCIAL EMPRESA";
                */

                //DATA DE DETALLE
                data.details = obj.details;
                //DATA DE LEGENDS
                data.legends = new List<CENLegends>();

                CLNProcesosGenerales pg = new CLNProcesosGenerales();
                CENLegends legend = new CENLegends();
                legend.value = pg.convertirALetras(obj.mtoImpVenta.ToString());
                legend.code = CENConstante.g_const_1000.ToString();
                data.legends.Add(legend);





            }
            catch (Exception ex)
            {

            }
            return data;
        }

        private CEN_DataVenta LlenarDataVenta(int codPreventa, int codCliente, int codVendedor, string fechPag, int tipoVenta,
            int tipoMoneda, double recargo, double IGV, double total, int sucursal, int tipoDocumentoVenta, int codPuntoEntrega)
        {
            CEN_DataVenta data = new CEN_DataVenta();
            CLNConsultas consultas = new CLNConsultas();
            try
            {
                data.codPreventa = codPreventa;
                data.codCliente = codCliente;
                data.codVendedor = codVendedor;
                data.fechaTransaccion = DateTime.Now;
                data.fechaPago = consultas.ConvertFechaStringToDate(fechPag);
                data.importeRecargo = recargo;
                data.importeTotal = total;
                data.IGV = IGV;
                data.sucursal = sucursal;
                data.tipoVenta = tipoVenta;
                data.tipoMoneda = tipoMoneda;
                data.proceso = CENConstante.g_const_1;
                data.tipoDocumentoVenta = tipoDocumentoVenta;
                data.codPuntoEntrega = codPuntoEntrega;
                data.estado = CENConstante.g_const_1;
                //Verificar registro pendiente de pago
                /*
                TimeSpan timePago = data.fechaPago - DateTime.Now;
                int diaPago = timePago.Days;
                if (diaPago > CENConstante.g_const_0)
                {
                    */
                if (data.tipoVenta == CENConstante.g_const_1) // contado
                {
                    //Pendiente de pago
                    //data.estado = CENConstante.g_const_1;
                    //Registro de clase de pendiente de cobro
                    data.cuentaCobro.fechaCobro = data.fechaPago;
                    data.cuentaCobro.fechaTransaccion = DateTime.Now;
                    data.cuentaCobro.horaTransaccion = DateTime.Now.ToString(CENConstante.g_const_horaFech);
                    data.cuentaCobro.responsable = CENConstante.g_const_vacio;
                    data.cuentaCobro.estado = CENConstante.g_const_1;
                    data.cuentaCobro.importe = data.importeTotal;

                    //Validamos que si se debe registrar cuenta cobro
                    data.est_reg_cue_cob = CENConstante.g_const_1;
                }
                //Tipo de pago
                if (data.tipoVenta == CENConstante.g_const_1) // contado
                {
                    //TOTAL
                    data.tipoPago = CENConstante.g_const_1;
                }
                else //credito
                {
                    //PARCIAL
                    data.tipoPago = CENConstante.g_const_2;
                    //Generar prestamo
                    data.prestamo.fechaTransaccion = DateTime.Now;
                    data.prestamo.importeTotal = total;
                    data.prestamo.interesTotal = CENConstante.g_const_0;
                    data.prestamo.nroCuotas = CENConstante.g_const_1;
                    data.prestamo.estado = CENConstante.g_const_1;
                    TimeSpan ts = data.fechaPago - DateTime.Now;
                    data.prestamo.plazo = ts.Days;
                    //Generar cronograma
                    CENCronograma cronograma = new CENCronograma();
                    cronograma.fechaPago = data.fechaPago;
                    cronograma.importe = total;
                    cronograma.nroCuota = CENConstante.g_const_1;
                    cronograma.estado = CENConstante.g_const_1;
                    data.listCuotas.Add(cronograma);

                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CENVentaFiltroPA listarVentaCodigo(int codigo)
        {
            CADVenta cadVenta = new CADVenta();
            CENVentaFiltroPA data = new CENVentaFiltroPA();
            CLNConsultas clnConsultas = new CLNConsultas();
            try
            {
                data = cadVenta.listarVentaCodigo(codigo);
                data.nroDocumentoCadena = clnConsultas.ConvertirNroDocumento(data.nroDocumento);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
