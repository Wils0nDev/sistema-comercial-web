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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static int ActualizarPerfil(string nombre, string apellidoPaterno, string apellidoMaterno, string telefono, string correo, string password)
        {
            CLNPerfil objPerfil = new CLNPerfil();
            CENPerfil cenPerfil = new CENPerfil();


            cenPerfil.nombre = nombre;
            cenPerfil.apellidoMaterno = apellidoMaterno;
            cenPerfil.apellidoPaterno = apellidoPaterno;
            cenPerfil.telefono = telefono;
            cenPerfil.correo = correo;
            cenPerfil.password = password;

            cenPerfil.codUsuario = Convert.ToInt32(System.Web.HttpContext.Current.Session["codUser"].ToString());
            cenPerfil.codPersona = Convert.ToInt32(System.Web.HttpContext.Current.Session["codPersona"].ToString());

            int codigo = 0;
            try
            {
                codigo = objPerfil.actualizarPerfil(cenPerfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return codigo;
        }

        [WebMethod]
        public static List<CENPerfil> DataPerfil()
        {
            List<CENPerfil> dataPerfil;
            CLNPerfil clperfil = new CLNPerfil();
            string codUsuario = System.Web.HttpContext.Current.Session["codUser"].ToString();
            string codPersona = System.Web.HttpContext.Current.Session["codPersona"].ToString();
            Console.WriteLine(codUsuario);
            try
            {
                dataPerfil = clperfil.datosPerfil(Convert.ToInt32(codUsuario), Convert.ToInt32(codPersona));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataPerfil;
        }
    }
}