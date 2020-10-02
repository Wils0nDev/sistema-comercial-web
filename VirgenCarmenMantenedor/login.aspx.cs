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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<CENUsuario> getSession()
        {
            List<CENUsuario> DataUser;
            CENUsuario user = new CENUsuario();
            try
            {
                DataUser = new List<CENUsuario>();
                user.perfil = System.Web.HttpContext.Current.Session["perfil"].ToString();
                user.nombre = System.Web.HttpContext.Current.Session["nombres"].ToString();
                user.ntraUsuario = Convert.ToInt32(System.Web.HttpContext.Current.Session["codUser"].ToString());
                user.sucursal = System.Web.HttpContext.Current.Session["sucursal"].ToString();
                DataUser.Add(user);

            }
            catch (Exception ex)
            {
                CerrarSesion();
                return DataUser = null;
            }
            return DataUser;
        }

        [WebMethod]
        public static Boolean InsertSession(string perfil, string nombre, string sucursal, string codUser, string codPersona)
        {
            try
            {
                System.Web.HttpContext.Current.Session["perfil"] = perfil;
                System.Web.HttpContext.Current.Session["nombres"] = nombre;
                System.Web.HttpContext.Current.Session["sucursal"] = sucursal;
                System.Web.HttpContext.Current.Session["codUser"] = codUser;
                System.Web.HttpContext.Current.Session["codPersona"] = codPersona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        [WebMethod]
        public static List<CENUsuario> consultarDatos(string user, string pass, int intentos, int sucursal)
        {
            CLNUsuario objUser = new CLNUsuario();
            List<CENUsuario> datos;
            try
            {
                datos = objUser.credencialesUsuario(user, pass, intentos, sucursal);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        [WebMethod]
        public static List<CENUsuario> CerrarSesion()
        {
            int codUser = Convert.ToInt32(System.Web.HttpContext.Current.Session["codUser"].ToString());
            List<CENUsuario> datos = null;
            CLNUsuario clnUsuario = new CLNUsuario();
            try
            {
                datos = clnUsuario.CerrarSesion(codUser);
                System.Web.HttpContext.Current.Session["codUser"] = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datos;
        }
        [WebMethod]
        public static List<CENUsuario> CerrarSesionInactividad(int codUser)
        {

            List<CENUsuario> datos = null;
            CLNUsuario clnUsuario = new CLNUsuario();
            try
            {
                datos = clnUsuario.CerrarSesion(codUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datos;
        }

        [WebMethod]
        public static List<CENSucursalVIEW> listarSucursal(int flag)
        {

            List<CENSucursalVIEW> sucursales;
            CLNUsuario clnUsuario = new CLNUsuario();
            try
            {
                sucursales = clnUsuario.cargarSucursal(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sucursales;
        }

    }
}