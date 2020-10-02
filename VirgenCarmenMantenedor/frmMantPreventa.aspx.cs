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
    public partial class frmMantPreventa1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<CENConceptos> ListarConcepto(int flag)
        {
            List<CENConceptos> listaConcepto = null;
            CLNPreventa objCLNPreventa = null;
            try
            {
                objCLNPreventa = new CLNPreventa();
                listaConcepto = objCLNPreventa.ListarConcepto(flag);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
            return listaConcepto;
        }

        [WebMethod]
        public static List<CENCamposPreventa> ListarCampos(int flag)
        {
            List<CENCamposPreventa> listaCampos = null;
            CLNPreventa objCLNPreventa = null;
            try
            {
                objCLNPreventa = new CLNPreventa();
                listaCampos = objCLNPreventa.ListarCampos(flag);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
            return listaCampos;
        }



        [WebMethod]
        public static List<CENCamposPreventa> ListarCamposReg(int flag)
        {
            List<CENCamposPreventa> listaCampos = null;
            CLNPreventa objCLNPreventa = null;
            try
            {
                objCLNPreventa = new CLNPreventa();
                listaCampos = objCLNPreventa.ListarCampos(flag);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
            return listaCampos;
        }



        [WebMethod]
        public static List<CENPreventaProducto> ListarProductos_Sku(string cadena)
        {
            List<CENPreventaProducto> listaProducto = null;
            CLNPreventa objCLNPreventa = null;
            try
            {
                objCLNPreventa = new CLNPreventa();
                listaProducto = objCLNPreventa.ListarProductos_Sku(cadena);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
            return listaProducto;
        }


        [WebMethod]
        public static CENMensajePreventa ValidarFecharR(string fechaRegI, string fechaRegF)
        {
            CENMensajePreventa fechaValida = null;
            CLNPreventa objCLNPreventa = null;
            try
            {
                objCLNPreventa = new CLNPreventa();
                fechaValida = objCLNPreventa.validarFechaRegistro(fechaRegI, fechaRegF);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
            return fechaValida;
        }

        [WebMethod]
        public static List<CENPreventaLista> ListarPreventa(string codPreventa, int codvendedor, string codProducto, int codCliente, int codProveedor, int codRuta, int codEstado, int codTipo_venta, int codTipo_doc, int codOrigen_venta, string codfechaEntregaI, string codfechaEntregaF, string codfechaRegistroI, string codfechaRegistroF)
        {
            List<CENPreventaLista> lista_preventa = null;
            CENPreventaDatos objCENPreventaDatos = null;
            CLNPreventa objCLNPreventa = null;
            int num = CENConstante.g_const_0;
            int Cpreventa = (int.TryParse(codPreventa, out num)) ? Int32.Parse(codPreventa) : num;

            try
            {
                objCLNPreventa = new CLNPreventa();
                objCENPreventaDatos = new CENPreventaDatos(Cpreventa, codvendedor, codProducto, codCliente, codProveedor, codRuta, codEstado, codTipo_venta, codTipo_doc, codOrigen_venta, codfechaEntregaI, codfechaEntregaF, codfechaRegistroI, codfechaRegistroF);
                lista_preventa = objCLNPreventa.ListarPreventa(objCENPreventaDatos);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
            return lista_preventa;
        }

        [WebMethod]
        public static List<CENDetallePreventa> ListarDetalle(int npre)
        {
            List<CENDetallePreventa> listaDetalle = null;
            CLNPreventa objCLNPreventa = null;

            try
            {
                objCLNPreventa = new CLNPreventa();
                listaDetalle = objCLNPreventa.ListarDetalle(npre);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listaDetalle;
        }

        [WebMethod]
        public static int anularPreventa(int npre)
        {
            CLNPreventa objCLNPreventa = null;
            int resp;
            try
            {
                objCLNPreventa = new CLNPreventa();
                resp = objCLNPreventa.AnularPreventa(npre).codigo;
            }
            catch (Exception ex)
            {
                resp = -100;
                ex.StackTrace.ToString();
            }
            return resp;
        }

        [WebMethod]
        public static byte[] crearPdf(CENPreventaLista datosPre)
        {
            CLNPreventaPdf objCLNPreventaPdf = null;
            int nprev = datosPre.ntraPreventa;
            byte[] binaryData = null;

            try
            {
                objCLNPreventaPdf = new CLNPreventaPdf();
                binaryData = objCLNPreventaPdf.preventaPdf(datosPre);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return binaryData;
        }

        [WebMethod]
        public static List<CENPreventaCliente> buscarCliente(string cadena)
        {
            List<CENPreventaCliente> listaCampos = null;
            CLNPreventa objCLNPreventa = null;
            try
            {
                objCLNPreventa = new CLNPreventa();
                listaCampos = objCLNPreventa.buscarCliente(cadena);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
            return listaCampos;
        }


        [WebMethod]
        public static List<CENProductolista> ListarProductosCombo(int flag)
        {
            List<CENProductolista> listaProducto = null;
            CLNPreventa objCLNPreventa = null;
            try
            {
                objCLNPreventa = new CLNPreventa();
                listaProducto = objCLNPreventa.ListarProductosCombo(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaProducto;
        }
    }
}