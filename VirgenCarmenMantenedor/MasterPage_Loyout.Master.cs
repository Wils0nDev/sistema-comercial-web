using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirgenCarmenMantenedor
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["codUser"] == null || Session["codPersona"] == null || Session["sucursal"] == null || Session["perfil"] == null || Session["nombres"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}