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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string enviarCorreo(string usuario)
        {
            CLNCorreo correo = new CLNCorreo();
            string respuesta = string.Empty;
            try
            {
               respuesta = correo.enviarCorreo(usuario);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
    }
}