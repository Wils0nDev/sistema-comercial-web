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
    public partial class frmMantRutas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<CENRutas> CargarTabla(int flag)
        {
            CLNRutas urutas = null;
            List<CENRutas> ListRu = null;
            try
            {
                urutas = new CLNRutas();
                ListRu = urutas.ListarRutas(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListRu;
        }

        //[WebMethod]
        //public static List<CENSucursales> ListarSucursales(int flag)
        //{
        //    CLNSucursales usucursal = null;
        //    List<CENSucursales> ListSu = null;
        //    try
        //    {
        //        usucursal = new CLNSucursales();
        //        ListSu = usucursal.ListarSucursales(flag);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return ListSu;
        //}




        [WebMethod]
        public static int EliminarRutas(int codRuta)
        {
            CLNRutas objCLNRutas = null;

            CENRutas objtRutas = new CENRutas()
            {
                ntraRutas = codRuta,
            };
            try
            {
                objCLNRutas = new CLNRutas();
                int ok = objCLNRutas.EliminarRutas(objtRutas);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        public static int InsertarRutas(string descripcion, string pseudonimo, int codSucursal)
        {
            CLNRutas objCLNRutas = null;

            CENRutas objtRutasADS = new CENRutas()
            {

                descripcion = descripcion,
                pseudonimo = pseudonimo,
                codSucursal = codSucursal


            };
            try
            {
                objCLNRutas = new CLNRutas();
                int ok = objCLNRutas.InsertarRutas(objtRutasADS);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        public static int ActualizarRutas(string descripcion, string pseudonimo, int ntraRutas)
        {

            CENRutas objtRutasADS = new CENRutas()
            {

                descripcion = descripcion,
                pseudonimo = pseudonimo,
                ntraRutas = ntraRutas


            };
            CLNRutas objCLNRutas = null;

            //int codRutaAn = Convert.ToInt32(codRutaAnterior);
            try
            {
                objCLNRutas = new CLNRutas();
                int ok = objCLNRutas.ActualizarRutas(objtRutasADS, ntraRutas);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //[WebMethod]
        //public static int ActualizaOrdenRutas(List<CENRutas> arrayData)
        //{

        //    CLNRutas objCLNRutas = null;

        //    try
        //    {
        //        objCLNRutas = new CLNRutas();

        //        int ok = objCLNRutas.ActualizaOrdenRutas(arrayData);
        //        return ok;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}




        public static List<CENRutasAsignadasView> ActualizarTabla(int codUsuario)
        {
            List<CENRutasAsignadasView> ListaRA = null;
            CLNRutasAsignadasView objRutasView = null;
            try
            {
                objRutasView = new CLNRutasAsignadasView();
                ListaRA = objRutasView.ListarRutasAsignadasPorVendedor(codUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaRA;
        }
    }
}