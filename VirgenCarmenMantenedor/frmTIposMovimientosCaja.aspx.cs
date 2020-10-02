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
    public partial class frmTIposMovimientosCaja1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CENTipoMovimiento> ListarTiposMovimientosCaja(int flag)
        {
            CLNTipoMovimiento utiposmov = null;
            List<CENTipoMovimiento> ListTm = null;
            try
            {
                utiposmov = new CLNTipoMovimiento();
                ListTm = utiposmov.ListarTiposMovimientosCaja(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListTm;
        }

        [WebMethod]
        public static int AltaBajaTipoMov(CENTipoMovimiento tipoMov, int flag)
        {
            CLNTipoMovimiento objCLNTipoMovimiento = null;

            try
            {
                objCLNTipoMovimiento = new CLNTipoMovimiento();
                int ok = objCLNTipoMovimiento.AltaBajaTipoMovimientoCaja(tipoMov, flag);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        public static int RegistrarTipoMovimientoCaja(CENTipoMovimiento tipoMov)
        {
            CLNTipoMovimiento objCLNTipoMovimiento = null;

            try
            {
                objCLNTipoMovimiento = new CLNTipoMovimiento();
                int ok = objCLNTipoMovimiento.RegistrarTipoMovimientoCaja(tipoMov);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        public static int ActualizarTipoMovimientoCaja(CENTipoMovimiento tipoMov)
        {

            CLNTipoMovimiento objCLNTipoMovimiento = null;

            try
            {
                objCLNTipoMovimiento = new CLNTipoMovimiento();
                int ok = objCLNTipoMovimiento.ActualizarTipoMovimientoCaja(tipoMov);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<CENConcepto> ListarTiposRegistro(int flag)
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
    }
}