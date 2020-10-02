using CEN;
using CLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirgenCarmenMantenedor
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<CENPreventaCliente> buscarCliente(string cadena)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            List<CENPreventaCliente> lista = null;
            try
            {
                lista = notacredito.buscarCliente(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static List<CENNotaCreditoVenta> buscarVentas(CENNotaCreditoParametroBuscarVenta parametros)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            List<CENNotaCreditoVenta> lista = null;
            try
            {
                lista = notacredito.buscarVentas(parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static CENNotaCreditoDatosVenta obtenerVenta(int codigo)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            CENNotaCreditoDatosVenta obj = null;
            try
            {
                obj = notacredito.obtenerVenta(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        [WebMethod]
        public static List<CENNotaCreditoDatosDetalleVenta> obtenerDetalleVenta(int codigo)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            List<CENNotaCreditoDatosDetalleVenta> list = null;
            try
            {
                list = notacredito.obtenerDetalleVenta(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        [WebMethod]
        public static List<CENNotaCreditoMotivoNC> obtenerMotivosNC()
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            List<CENNotaCreditoMotivoNC> list = null;
            try
            {
                list = notacredito.obtenerMotivosNC();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        [WebMethod]
        public static List<CENNotaCreditoVentaPromocion> obtenerVentaPromocion(int codigo)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            List<CENNotaCreditoVentaPromocion> list = null;
            try
            {
                list = notacredito.obtenerVentaPromocion(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        [WebMethod]
        public static List<CENNotaCreditoVentaDescuento> obtenerVentaDescuento(int codigo)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            List<CENNotaCreditoVentaDescuento> list = null;
            try
            {
                list = notacredito.obtenerVentaDescuento(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        [WebMethod]
        public static CENNotaCreditoDatosPromocion obtenerValoresPromocion(int codigo)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            CENNotaCreditoDatosPromocion obj = null;
            try
            {
                obj = notacredito.obtenerValoresPromocion(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        [WebMethod]
        public static CENNotaCreditoDatosDescuento obtenerValoresDescuento(int codigo)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            CENNotaCreditoDatosDescuento obj = null;
            try
            {
                obj = notacredito.obtenerValoresDescuento(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        [WebMethod]
        public static CENNotaCreditoRptaRegistroNC registrarNC(CENNotaCredito nc)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            CENNotaCreditoRptaRegistroNC obj = null;
            try
            {
                obj = notacredito.registrarNC(nc);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        [WebMethod]
        public static byte[] generarNotaCreditoPDF(int codNotaCredito)
        {
            CLNNotaCredito objetoCLN = new CLNNotaCredito();
            byte[] binaryData = null;

            try
            {
                binaryData = objetoCLN.generarNotaCreditoPDF(codNotaCredito);
            }
            catch (Exception ex)
            {
                throw ex;
                //ex.StackTrace.ToString();
            }

            return binaryData;
        }

        [WebMethod]
        public static CENNotaCreditoRptaValidacion validarVenta(int codigo)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            CENNotaCreditoRptaValidacion obj = null;
            try
            {
                obj = notacredito.validarVenta(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        [WebMethod]
        public static CENNotaCreditoParametrosRpta obtenerParametros(CENNotaCreditoParametros parametros)
        {
            CLNNotaCredito notacredito = new CLNNotaCredito();
            CENNotaCreditoParametrosRpta obj = null;
            try
            {
                obj = notacredito.obtenerParametros(parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }
    }
}