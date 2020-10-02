using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEN;
using CLN;
using Newtonsoft.Json;

namespace VirgenCarmenMantenedor
{
    public partial class frmRutasAsignadas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CENUsuario> ListarVendedores(int flag)
        {
            CLNUsuario uvendedor = null;
            List<CENUsuario> ListVE = null;
            try
            {
                uvendedor = new CLNUsuario();
                ListVE = uvendedor.ListarVendedores(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ListVE;
        }
        [WebMethod]
        public static List<CENRutasAsignadasView> ListarRutasAsignadas(int codUsuario)
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

        [WebMethod]
        public static List<CENRutas> ListarRutas(int flag)
        {
            List<CENRutas> listaRU = null;
            CLNRutas objRutas = null;
            try
            {
                objRutas = new CLNRutas();
                listaRU = objRutas.ListarRutas(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaRU;
        }
        [WebMethod]
        public static List<CENConcepto> ListarDias(int flag)
        {
            List<CENConcepto> listDI = null;
            CLNConcepto dias = null;
            try
            {
                dias = new CLNConcepto();
                listDI = dias.ListarDias(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listDI;
        }

        [WebMethod]
        public static int InsertarRutasAsignadas(string codUsuario, string codRuta, string codOrden, string diaSemana)
        {
            CLNRutasAsignadas objCLNRutasAsignadas = null;

            CENRutasAsignadas objtRutasADS = new CENRutasAsignadas()
            {

                codUsuario = Convert.ToInt32(codUsuario),
                codRuta = Convert.ToInt32(codRuta),
                codOrden = Convert.ToInt32(codOrden),
                diaSemana = Convert.ToInt32(diaSemana)


            };
            try
            {
                objCLNRutasAsignadas = new CLNRutasAsignadas();
                int ok = objCLNRutasAsignadas.InsertarRutasAsignadas(objtRutasADS);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static int ActualizarRutasAsignadas(string codUsuario, string codRutaAnterior, string codRuta, string diaSemana)
        {

            CENRutasAsignadas objtRutasADS = new CENRutasAsignadas()
            {

                codUsuario = Convert.ToInt32(codUsuario),
                codRuta = Convert.ToInt32(codRuta),
                diaSemana = Convert.ToInt32(diaSemana)


            };
            CLNRutasAsignadas objCLNRutasAsignadas = null;

            int codRutaAn = Convert.ToInt32(codRutaAnterior);
            try
            {
                objCLNRutasAsignadas = new CLNRutasAsignadas();
                int ok = objCLNRutasAsignadas.ActualizarRutasAsignadas(objtRutasADS, codRutaAn);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static int EliminarRutasAsignadas(string codUsuario, string codRuta)
        {
            CLNRutasAsignadas objCLNRutasAsignadas = null;

            CENRutasAsignadas objtRutasADS = new CENRutasAsignadas()
            {

                codUsuario = Convert.ToInt32(codUsuario),
                codRuta = Convert.ToInt32(codRuta),
            };
            try
            {
                objCLNRutasAsignadas = new CLNRutasAsignadas();
                int ok = objCLNRutasAsignadas.EliminarRutasAsignadas(objtRutasADS);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [WebMethod]
        public static int ActualizaOrdenRutasAsignadas(List<CENRutasAsignadas> arrayData)
        {

            CLNRutasAsignadas objCLNRutasAsignadas = null;

            try
            {
                objCLNRutasAsignadas = new CLNRutasAsignadas();

                int ok = objCLNRutasAsignadas.ActualizaOrdenRutasAsignadas(arrayData);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}