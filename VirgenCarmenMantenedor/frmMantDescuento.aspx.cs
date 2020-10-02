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
    public partial class frmMantDetalleDescuento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<CENConceptoDescuento> ListarCoceptos(int flag)
        {
            List<CENConceptoDescuento> listconcepto = null;
            CLNDescuento objCLNDescuento = null;
            try
            {
                objCLNDescuento = new CLNDescuento();
                listconcepto = objCLNDescuento.ListarCoceptos(flag);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listconcepto;
        }

        [WebMethod]
        public static List<CENConceptoDescuento> ListarEstado(int flag)
        {
            List<CENConceptoDescuento> listconcepto = null;
            CLNDescuento objCLNDescuento = null;
            try
            {
                objCLNDescuento = new CLNDescuento();
                listconcepto = objCLNDescuento.ListarEstado(flag);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listconcepto;
        }

        [WebMethod]
        public static List<CENProductolista> ListarProductosTipo(string cadena)
        {
            List<CENProductolista> listProducto = null;
            CLNDescuento objCLNDescuento = null;
            try
            {
                objCLNDescuento = new CLNDescuento();
                listProducto = objCLNDescuento.ListarProductosTipo(cadena);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listProducto;
        }

        [WebMethod]
        public static CENConceptoDescuento obtenerUnidadBaseProducto(string codProducto)
        {
            CENConceptoDescuento listProducto = null;
            CLNDescuento objCLNDescuento = null;
            try
            {
                objCLNDescuento = new CLNDescuento();
                listProducto = objCLNDescuento.obtenerUnidadBaseProducto(codProducto);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listProducto;
        }

        [WebMethod]
        public static List<CENListarDescuento> ListarDescuento(string codProd, int codVendedor, int codCliente, int codEstado, string codFechaI, string codFechaF)
        {
            List<CENListarDescuento> listaDeatlle = null;
            CLNDescuento objCLNDescuento = null;
            try
            {
                objCLNDescuento = new CLNDescuento();
                listaDeatlle = objCLNDescuento.ListarDescuento(codProd, codVendedor, codCliente, codEstado, codFechaI, codFechaF);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listaDeatlle;
        }

        [WebMethod]
        public static CENMensajeDescuento registrarEditarDescuento(CENRegistrarDescuento datosDescuento)
        {
            CENMensajeDescuento mensajeRegistrar = null;
            CLNDescuento objCLNDescuento = null;
            try
            {
                objCLNDescuento = new CLNDescuento();
                mensajeRegistrar = objCLNDescuento.registrarDescuento(datosDescuento);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return mensajeRegistrar;
        }

        [WebMethod]
        public static CENMensajeDescuento cambiarEstado(int idDesc, int estado)
        {
            CENMensajeDescuento mensajEstado = null;
            CLNDescuento objCLNDescuento = null;
            try
            {
                objCLNDescuento = new CLNDescuento();
                mensajEstado = objCLNDescuento.cambiarEstado(idDesc, estado);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return mensajEstado;
        }



        [WebMethod]
        public static List<CENProductolista> ListarProductosTipo2(string cadena)
        {
            List<CENProductolista> listProducto = null;
            CLNDescuento objCLNDescuento = null;
            try
            {
                objCLNDescuento = new CLNDescuento();
                listProducto = objCLNDescuento.ListarProductosTipo2(cadena);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listProducto;
        }




    }
}