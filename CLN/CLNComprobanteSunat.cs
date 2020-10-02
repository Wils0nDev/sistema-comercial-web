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
    public class CLNComprobanteSunat
    {
        public int RegistrarComprobSunat(CENComprobSunat data)
        {
            CADcomprobSunat cADcomprob = new CADcomprobSunat();
            try
            {
                return cADcomprob.RegistrarComprobSunat(data);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarComprobSunat(int codTransaccino, string tramaSalida, int estado)
        {
            CADcomprobSunat cADcomprob = new CADcomprobSunat();
            try
            {
                cADcomprob.ActualizarComprobSunat( codTransaccino,  tramaSalida,  estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CENComprobSunat> ListarComprobantesFallidos()
        {
            CADcomprobSunat cADcomprob = new CADcomprobSunat();
            try
            {
                return cADcomprob.ListarComprobantesFallidos();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarComproanteFallidos()
        {
            List<CENComprobSunat> listaComp = new List<CENComprobSunat>();
            RequestApiBoleta dataVenta = new RequestApiBoleta();
            CLNConexionServicio clnServicio = new CLNConexionServicio();
            CLNConsultas consultas = new CLNConsultas();
            CADcomprobSunat cADcomprob = new CADcomprobSunat();
            ResponseApi respVenta = new ResponseApi();
            string tramaSUNAT = CENConstante.g_const_vacio;
            int estadoSUNAT = CENConstante.g_const_0;
            bool estado = false;
            try
            {
                listaComp = ListarComprobantesFallidos();
                foreach(CENComprobSunat comprobante in listaComp){

                    if (comprobante.codModulo == CENConstante.g_const_1 && comprobante.tipDocSunat == CENConstante.g_const_1)
                    {
                        //VENTA
                        estado = ValidarVenta(comprobante.tramEntrada);
                        if (estado)
                        {
                            dataVenta = JsonConvert.DeserializeObject<RequestApiBoleta>(
                            comprobante.tramEntrada);

                            respVenta = clnServicio.RegistrarBoleta(dataVenta);
                            tramaSUNAT = JsonConvert.SerializeObject(respVenta);
                            if (respVenta.sunatResponse.success)
                            {
                                //ACTUALIZAR COMPROBANTE DE LA SUNAT - CORRECTO
                                estadoSUNAT = CENConstante.g_const_1;
                            }
                            else
                            {
                                //ACTUALIZAR COMPROBANTE DE LA SUNAT - INCORRECTO
                                estadoSUNAT = CENConstante.g_const_2;
                            }
                            cADcomprob.ActualizarComprobSunat(comprobante.ntraComprob, tramaSUNAT, estadoSUNAT);
                        }
                    }

                    
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarVenta(string trama)
        {
            RequestApiBoleta dataVenta = new RequestApiBoleta();
            try
            {
                dataVenta = JsonConvert.DeserializeObject<RequestApiBoleta>(
                           trama);
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
