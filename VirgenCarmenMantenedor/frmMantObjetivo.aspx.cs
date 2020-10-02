using CAD;
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
    public partial class frmMantObjetivo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<CENConcepto> ListaConceptos(int flag)
        {
            CADObjetivo concepto = null;
            List<CENConcepto> ListaCampos = null;

            try
            {
                concepto = new CADObjetivo();
                ListaCampos = concepto.ListarConceptos(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaCampos;
        }

        [WebMethod]
        public static List<CENConcepto> ListaConcecptosPerfil(int flag)
        {
            CADObjetivo concepto = null;
            List<CENConcepto> ListaCampos = null;

            try
            {
                concepto = new CADObjetivo();
                ListaCampos = concepto.ListarConceptosPerfil(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaCampos;
        }

        [WebMethod]
        public static List<CENTrabajador> ListarTrabajador(int codPer)
        {
            CADObjetivo trabajador = null;
            List<CENTrabajador> ListaTrabajador = null;
            try
            {
                trabajador = new CADObjetivo();
                ListaTrabajador = trabajador.ListarTrabajadorPorPerfil(codPer);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaTrabajador;
        }

        [WebMethod]
        public static int InsertarObjetivo(string descripcion, int tipoIndicador, int indicador, decimal valorIndicador, int perfil, int trabajador)
        {
            CLNObjetivo objCLNobjetivo = null;
            CENObjetivo objObjetivo = new CENObjetivo()
            {
                descripcion = descripcion,
                codTipoIndicador = tipoIndicador,
                codIndicador = indicador,
                valorIndicador = valorIndicador,
                codPerfil = perfil,
                codTrabajador = trabajador,
                usuario = Convert.ToString("EAY")
            };
            try
            {
                objCLNobjetivo = new CLNObjetivo();
                int ok = objCLNobjetivo.InsertarObjetivos(objObjetivo);
                return ok;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static List<CENObjetivoLista> ListarObjetivos(int codTipoIndicador, int codIndicador, int codPerfil, int codTrabajador, string fechaInicio, string fechaFin)
        {
            List<CENObjetivoLista> ListaObjetivo = null;
            CENObjetivo objCENObjetico = null;
            CLNObjetivo objCLNObjetivo = null;

            try
            {
                objCLNObjetivo = new CLNObjetivo();
                objCENObjetico = new CENObjetivo(codTipoIndicador, codIndicador, codPerfil, codTrabajador, fechaInicio, fechaFin);
                ListaObjetivo = objCLNObjetivo.ListarObjetivos(objCENObjetico);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaObjetivo;
        }
    }
}