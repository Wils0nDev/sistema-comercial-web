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
    public partial class frmMaestroCajas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CENCaja> ListarCajas(
            int ntraCaja, int estadoCaja, int ntraUsuario, string fechaInicial, string fechaFinal)
        {
            CLNCaja objCLNCaja = null;
            List<CENCaja> listC = null;
            int ntraSucursal = Convert.ToInt32(System.Web.HttpContext.Current.Session["sucursal"].ToString());
            try
            {
                objCLNCaja = new CLNCaja();
                listC = objCLNCaja.ListarCajas(ntraCaja, estadoCaja, ntraUsuario, ntraSucursal, fechaInicial, fechaFinal);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listC;
        }

        [WebMethod]
        public static CENCaja ListarTipos_Mov_Asig_Caja(CENCaja objCENCaja)
        {
            CLNCaja objCLNCaja = null;
            CENCaja objC = null;
            
            try
            {
                objCLNCaja = new CLNCaja();
                objC = objCLNCaja.ListarTipos_Mov_Asig_Caja(objCENCaja);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objC;
        }


        [WebMethod]
        public static int RegistrarCaja(CENCaja objCENCaja)
        {
            CLNCaja objCLNCaja = null;
            objCENCaja.ntraSucursal = Convert.ToInt32(System.Web.HttpContext.Current.Session["sucursal"].ToString());

            try
            {
                objCLNCaja = new CLNCaja();
                int ok = objCLNCaja.RegistrarCaja(objCENCaja);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        public static int ActualizarCaja(CENCaja objCENCaja)
        {

            CLNCaja objCLNCaja = null;

            try
            {
                objCLNCaja = new CLNCaja();
                int ok = objCLNCaja.ActualizarCaja(objCENCaja);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<CENConcepto> ListarxFlag(int flag)
        {
            List<CENConcepto> listTR = null;
            CLNConcepto objCLNConcepto = null;
            try
            {
                objCLNConcepto = new CLNConcepto();
                listTR = objCLNConcepto.ListarDias(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listTR;
        }

        [WebMethod]
        public static List<CENUsuario> ListarCajeros_Sucursal()
        {
            CLNUsuario ucajero = null;
            List<CENUsuario> ListCAJ = null;
            int ntraSucursal = Convert.ToInt32(System.Web.HttpContext.Current.Session["sucursal"].ToString());

            try
            {
                ucajero = new CLNUsuario();
                ListCAJ = ucajero.ListarCajeros_Sucursal(ntraSucursal);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ListCAJ;
        }

        [WebMethod]
        public static List<CENAperturaCaja> ListarCajasAperturadas(int ntraCaja, int flag)
        {
            CLNCaja objCLNCaja = null;
            List<CENAperturaCaja> listCA = null;
            int ntraSucursal = Convert.ToInt32(System.Web.HttpContext.Current.Session["sucursal"].ToString());
            try
            {
                objCLNCaja = new CLNCaja();
                listCA = objCLNCaja.ListarCajasAperturadas(ntraSucursal, ntraCaja, flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listCA;
        }


        [WebMethod]
        public static int RegistrarAperturaCaja(CENAperturaCaja objCENAperturaCaja)
        {
            CLNCaja objCLNCaja = null;

            try
            {
                objCLNCaja = new CLNCaja();
                int ok = objCLNCaja.RegistrarAperturaCaja(objCENAperturaCaja);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        public static int ActualizarAperturaCaja(CENAperturaCaja objCENAperturaCaja)
        {

            CLNCaja objCLNCaja = null;

            try
            {
                objCLNCaja = new CLNCaja();
                int ok = objCLNCaja.ActualizarAperturaCaja(objCENAperturaCaja);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<CENCierreCaja> ListarCajasCerradas(int ntraCaja, int flag)
        {
            CLNCaja objCLNCaja = null;
            List<CENCierreCaja> listCC = null;
            int ntraSucursal = Convert.ToInt32(System.Web.HttpContext.Current.Session["sucursal"].ToString());

            try
            {
                objCLNCaja = new CLNCaja();
                listCC = objCLNCaja.ListarCajasCerradas(ntraSucursal, ntraCaja, flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listCC;
        }

        [WebMethod]
        public static List<CENTransaccionCaja> ListarTransaccionesCajas(int ntraCaja, string fechaTransaccion, int flag)
        {
            CLNCaja objCLNCaja = null;
            List<CENTransaccionCaja> listTC = null;
            int ntraSucursal = Convert.ToInt32(System.Web.HttpContext.Current.Session["sucursal"].ToString());
            try
            {
                objCLNCaja = new CLNCaja();
                listTC = objCLNCaja.ListarTransaccionesCajas(ntraSucursal, ntraCaja, fechaTransaccion, flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listTC;
        }
    }
}