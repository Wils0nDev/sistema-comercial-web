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
    public partial class frmRutasBitacora1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CENRutasBitacora> ListarRutasBitacora(int codVendedor, int fechaActual, Int16 flagFiltro, DateTime fechaIncio, DateTime fechaFin)
        {
            List<CENRutasBitacora> ListaRA = null;
            CLNRutasBitacora objRutasBitacora = null;
            try
            {
                objRutasBitacora = new CLNRutasBitacora();
                ListaRA = objRutasBitacora.ListarRutasBitacora(codVendedor, fechaActual, flagFiltro, fechaIncio, fechaFin);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaRA;
        }

    }
}