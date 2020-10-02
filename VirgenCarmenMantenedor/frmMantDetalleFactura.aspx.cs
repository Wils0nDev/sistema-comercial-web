using System;
using System.Collections.Generic;
using System.Web.Services;
using CEN;
using CLN;

namespace VirgenCarmenMantenedor
{
    public partial class frmMantDetalleFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CENDocumentoVentaView> ListarDocumentosVenta(
            Int16 flagFiltro, int fechaActual, int codEstado, int codCliente,
            int codVendedor, string fechaInicial, string fechaFinal, int codTipoDoc, int ntraVenta, string serie, int numdoc)
        {
            List<CENDocumentoVentaView> ListaDV = null;
            CLNDocumentoVentaView objDocVenta = null;
            try
            {
                objDocVenta = new CLNDocumentoVentaView();
                ListaDV = objDocVenta.ListarDocumentosVenta(flagFiltro, fechaActual, codEstado, codCliente, codVendedor, fechaInicial, fechaFinal, codTipoDoc, ntraVenta, serie,  numdoc);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaDV;
        }

        [WebMethod]
        public static List<CENConcepto> ListarEstados(int flag)
        {
            List<CENConcepto> listES = null;
            CLNConcepto estado = null;
            try
            {
                estado = new CLNConcepto();
                listES = estado.ListarDias(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listES;
        }     

        [WebMethod]
        public static CENVentaFiltroPA ListarDetalleVenta(int codigo)
        {
            CENVentaFiltroPA listES = new CENVentaFiltroPA();
            CLN_Venta clnVenta = new CLN_Venta();
            try
            {
                listES = clnVenta.listarVentaCodigo(codigo);

                CLNVentaPdf clnPDF = new CLNVentaPdf();
                CENPreventaLista lista = new CENPreventaLista();
                //listES.l_pdfbytes = clnPDF.VentaPdf(codigo);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listES;
        }

        [WebMethod]
        public static byte[] generarVentaPdf(int codigo)
        {
            CLNVentaPdf clnPDF = new CLNVentaPdf();
            byte[] binaryData = null;

            try
            {
                binaryData = clnPDF.VentaPdf(codigo);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return binaryData;
        }
        
        [WebMethod]
        public static CENCuentaCobro BuscarCuentaPorCobrar(int codVenta, int flag)
        {
            CENCuentaCobro objCxC = null;
            CLNCuentaCobro objCLNCxC = null;
            try
            {
                objCLNCxC = new CLNCuentaCobro();
                objCxC = new CENCuentaCobro();

                objCxC = objCLNCxC.BuscarCuentaPorCobrar(codVenta,flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objCxC;
        }


        [WebMethod]
        public static CENParametrosGenerales ListarParametros(int flag, int codSucursal)
        {
            CENParametrosGenerales objCENPA = null;
            CLNParametrosGenerales objCLNPA = null;
            try
            {
                objCLNPA = new CLNParametrosGenerales();
                objCENPA = objCLNPA.ListarParametros(flag, codSucursal);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objCENPA;
        }

        [WebMethod]

        public static int InsertarTransaccionPago(string flag, string codPrestamo, string nroCuota,
            string codVenta, string ntraMedioPago, string tipoCambio,
            string tipoMoneda, string igv, string estado, string importe, string vuelto,
            string nroTransf, string nroCuenta, string banco, string fechaTrans)
        {
            int? CodPrestamos;
            int? NroCuotas;

            int Flag = Convert.ToInt16(flag);
            if (codPrestamo == null)
            {
                CodPrestamos = null;
            }
            else
            {
                CodPrestamos = Convert.ToInt32(codPrestamo);
            }

            if (nroCuota == null)
            {
                NroCuotas = null;
            }
            else
            {
                NroCuotas = Convert.ToInt32(nroCuota);
            }

            CENTransaccionPago objTP = new CENTransaccionPago()
            {
                codPrestamo = CodPrestamos,
                nroCuota = NroCuotas,
                codVenta = Convert.ToInt32(codVenta),
                ntraMedioPago = Convert.ToInt16(ntraMedioPago),
                tipoCambio = Convert.ToDecimal(tipoCambio),
                tipoMoneda = Convert.ToInt16(tipoMoneda),
                IGV = Convert.ToDecimal(igv),
                estado = Convert.ToInt16(estado)
            };

            CENPagoEfectivo objPE = new CENPagoEfectivo()
            {
                importe = Convert.ToDecimal(importe),
                vuelto = Convert.ToDecimal(vuelto),
                tipoMoneda = Convert.ToInt16(tipoMoneda),
                estado = Convert.ToInt16(estado)
            };

            CENPagoTransferencia objePT = new CENPagoTransferencia()
            {
                 nroTransferencia = nroTransf,
                 cuentaTransferencia= nroCuenta,
                 banco= banco,
                 importe= Convert.ToDecimal(importe),
                 tipoMoneda = Convert.ToInt16(tipoMoneda),
                 fechaTransferencia= Convert.ToDateTime(fechaTrans),
                 estado= Convert.ToInt16(estado)

            };

            CLNPagoTransaccion objCLNTP = null;
            try
            {
                
                objCLNTP = new CLNPagoTransaccion();
                int ok = objCLNTP.InsertarTransaccionPago(Flag, objTP, objPE, objePT);

                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<CENCronograma> ListarCronograma(int codVenta, int flag)
        {
            List<CENCronograma> objCro = null;
            CLNCronograma objCLNCro = null;
            try
            {
               
                objCLNCro = new CLNCronograma();

                objCro = objCLNCro.ListarCronograma(codVenta, flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objCro;
        }

        [WebMethod]
        public static int EnviarComproanteFallidos()
        {
            CLNComprobanteSunat clnComprobante = new CLNComprobanteSunat();
            int estado = CENConstante.g_const_0;
            try
            {
                clnComprobante.EnviarComproanteFallidos();
                estado = CENConstante.g_const_1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estado;
        }


    }
}