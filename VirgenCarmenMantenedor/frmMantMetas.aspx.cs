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
    public partial class frmMantMetas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CENMetaLista> ListarMetas(int codProveedor, int codEstado, string fechaInicio, string fechaFin)
        {
            List<CENMetaLista> ListaMeta = null;
            CENMeta objCENMeta = null;
            CLNMeta objCLNMeta = null;

            try
            {
                objCLNMeta = new CLNMeta();
                objCENMeta = new CENMeta(codProveedor, codEstado, fechaInicio, fechaFin);
                ListaMeta = objCLNMeta.ListarMetas(objCENMeta);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaMeta;
        }

        [WebMethod]
        public static int InsertarMeta(string descripcion, string fechaInicio, string fechaFin)
        {
            CLNMeta objCLNmeta = null;
            CENMeta objMeta = new CENMeta()
            {
                descripcion = descripcion,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin,
                usuario = Convert.ToString("EAY")

            };
            try
            {
                objCLNmeta = new CLNMeta();
                int ok = objCLNmeta.InsertarMetas(objMeta);
                return ok;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}