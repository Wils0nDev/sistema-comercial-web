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
    public partial class frmMantPermisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<CENUsuario> cargaPerfil(int flag)
        {
            //DESCRIPION: Cargar datos de perfiles
            CLNPermisos permisos = new CLNPermisos();
            try
            {
                return permisos.cargarPerfil(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<CENModulo> cargaModulo(int flag)
        {

            CLNPermisos permisos = new CLNPermisos();
            try
            {
                return permisos.cargarModulos(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<CENMenu> cargaMantenedores(int flag)
        {

            CLNPermisos permisos = new CLNPermisos();
            try
            {
                return permisos.cargarMantenedores(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<CENMenu> DataMenus()
        //DESCRIPCION: carga todos lo mantenedores guardados
        {

            CLNPermisos permisos = new CLNPermisos();
            try
            {
                return permisos.DataMenus();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [WebMethod]
        public static List<CENMenu> DataMenusPorPerfil(int perfil)
        //DESCRIPCION: carga todos lo mantenedores guardados POR PERFIL
        {

            CLNPermisos permisos = new CLNPermisos();
            try
            {
                return permisos.DataMenus(perfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [WebMethod]
        public static int InsertarPermisos(List<CENPermiso> permisos)
        {
            //DESCRIPCION: Inserta la lista de permisos
            try
            {
                CENPermiso permiso = new CENPermiso();
                permiso.listPermiso = permisos;
                int flag = CENConstante.g_const_1;
                CLNPermisos per = new CLNPermisos();
                return per.guardarPermiso(permiso, flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static int actualizarPermisos(List<CENPermiso> permisos)
        {
            //DESCRIPCION: Actualiza la lista de permisos
            try
            {
                CENPermiso permiso = new CENPermiso();
                permiso.listPermiso = permisos;
                int flag = CENConstante.g_const_2;
                CLNPermisos per = new CLNPermisos();
                return per.modificiarPermiso(permiso, flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CENMenu> DataMantenedoresNombre(string nombre)
        {
            //DESCRIPCION: Busca los mantenedores por nombre
            CLNPermisos permisos = new CLNPermisos();
            try
            {
                return permisos.DataMantenedoresNombre(nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}