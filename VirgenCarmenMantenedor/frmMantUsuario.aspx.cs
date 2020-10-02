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
    public partial class frmMantUsuario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<CENMantUsuarioVIEW> CargarTabla(
                int flagFiltro, int codEstado, int codUsuario)
        {
            CLNMantUsuarioVIEW nusuario = null;
            List<CENMantUsuarioVIEW> ListUsuario = null;
            try
            {
                nusuario = new CLNMantUsuarioVIEW();
                ListUsuario = nusuario.ListarUsuario(flagFiltro, codEstado, codUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListUsuario;
        }

        [WebMethod]
        public static List<CENAutoUsuarioVIEW> buscarUsuario(string cadena)
        {
            CADMantUsuarioVIEW objCAD = null;
            List<CENAutoUsuarioVIEW> ListObj = null;
            try
            {
                objCAD = new CADMantUsuarioVIEW();
                ListObj = objCAD.buscarUsuario(cadena);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ListObj;
        }



        [WebMethod]
        public static List<CENPerfilVIEW> CargarPerfil(int flag)
        {
            CLNPerfilVIEW nusuario = null;
            List<CENPerfilVIEW> ListUsuario = null;
            try
            {
                nusuario = new CLNPerfilVIEW();
                ListUsuario = nusuario.CargarPerfil(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListUsuario;
        }





        //reutilizando webmetodo listar dias por tabla concepto para estadod de usuarios
        [WebMethod]
        public static List<CENConcepto> ListarEstado(int flag)
        {
            List<CENConcepto> listDI = null;
            CLNConcepto dias = null;
            try
            {
                dias = new CLNConcepto();
                listDI = dias.ListarDias(flag);


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listDI;
        }


        [WebMethod]
        public static List<CENSucursalVIEW> cargarSucursal(int flag)
        {
            List<CENSucursalVIEW> ListSucursal = null;
            CLNSucursalVIEW objSucursal = null;
            try
            {
                objSucursal = new CLNSucursalVIEW();
                ListSucursal = objSucursal.cargarSucursal(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ListSucursal;
        }

    }
}