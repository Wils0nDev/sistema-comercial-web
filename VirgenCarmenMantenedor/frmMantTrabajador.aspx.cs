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
    public partial class frmMantTrabajador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static int registrarTrabajador(byte tipoPersona, byte tipoDocumento, string numeroDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento,
                                       Int16 estadoCivil, string direccion, string correo, Int16 asignacionFamilia, string telefono, string celular, string ruc, Int16 area, Int16 estadoTrabajador,
                                       Int16 tipoTrabajador, Int16 cargo, Int16 formaPago, string numeroCuenta, Int16 tipoRegimen, Int16 regimenPensionario, DateTime inicioRegimen, Int16 bancoRemuneracion,
                                       Int16 estadoPlanilla, Int16 modalidadContrato, Int16 periodicidad, DateTime inicioContrato, DateTime finContrato, DateTime fechaIngreso, float sueldo)
        {

            CENTrabajador data = new CENTrabajador();

            data.tipoPersona = tipoPersona;
            data.tipoDocumento = tipoDocumento;
            data.numeroDocumento = numeroDocumento;
            data.nombres = nombres;
            data.apellidoPaterno = apellidoPaterno;
            data.apellidoMaterno = apellidoMaterno;
            data.fechaNacimiento = fechaNacimiento;
            data.estadoCivil = estadoCivil;
            data.direccion = direccion;
            data.correo = correo;
            data.asignacionFamilia = asignacionFamilia;
            data.telefono = telefono;
            data.celular = celular;
            data.ruc = ruc;
            data.area = area;
            data.estadoTrabajador = estadoTrabajador;
            data.tipoTrabajador = tipoTrabajador;
            data.cargo = cargo;
            data.formaPago = formaPago;
            data.numeroCuenta = numeroCuenta;
            data.tipoRegimen = tipoRegimen;
            data.regimenPensionario = regimenPensionario;
            data.inicioRegimen = inicioRegimen;
            data.bancoRemuneracion = bancoRemuneracion;
            data.estadoPlanilla = estadoPlanilla;
            data.modalidadContrato = modalidadContrato;
            data.periodicidad = periodicidad;
            data.inicioContrato = inicioContrato;
            data.finContrato = finContrato;
            data.fechaIngreso = fechaIngreso;
            data.sueldo = sueldo;

            CLNTrabajador clnt = new CLNTrabajador();
            try
            {
                return clnt.registrarTrabajador(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static List<CENConcepto> CargarConceptos(int flag)
        {
            CLNConcepto clnConcepto = new CLNConcepto();
            List<CENConcepto> ListConcepto = new List<CENConcepto>();
            try
            {
                ListConcepto = clnConcepto.ListarConceptos(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListConcepto;
        }
    }
}