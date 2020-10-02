using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace VirgenCarmenMantenedor
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["sesion_user"] = 0;


        }

        void Session_Start(object sender, EventArgs e)
        {
            //incremento de sesion
            Application["sesion_user"] = (int)Application["sesion_user"] + 1;

            //inicializacion de variables
            Session["nombres"] = "";
            Session["perfil"] = "";
            Session["sucursal"] = "";
            Session["codUser"] = "";
            Session["codPersona"] = "";
        }
        void Session_End(object sender, EventArgs e)
        {
            //decremento de sesion
            Application["sesion_user"] = (int)Application["sesion_user"] - 1;

            //pasamos a null las variables de nombres y perfil

            Session["nombres"] = null;
            Session["perfil"] = null;
            Session["sucursal"] = null;
            Session["codPersona"] = null;
            Session["codUser"] = null;
        }
    }
}