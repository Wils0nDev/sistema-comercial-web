using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNPermisos
    {
        public CLNPermisos() { }

        public List<CENUsuario> cargarPerfil(int flag)
        {
            //DESCRIPCION: carga todos lo perfiles
            List<CENUsuario> datos = new List<CENUsuario>();
            CADPermisos cad = new CADPermisos();
            try
            {
                return datos = cad.cargarPerfil(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENModulo> cargarModulos(int flag)
        {
            List<CENModulo> datos = new List<CENModulo>();
            CADPermisos cad = new CADPermisos();
            try
            {
                return datos = cad.cargarModulos(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENMenu> cargarMantenedores(int flag)

        {
            List<CENMenu> datos = new List<CENMenu>();
            CADPermisos cad = new CADPermisos();
            try
            {
                return datos = cad.cargarMantenedores(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int guardarPermiso(CENPermiso permiso, int flag)
        {
            //DESCRIPCION: Guarda una lista de perfiles
            CADPermisos cad = new CADPermisos();
            try
            {
                return cad.guardarPermiso(permiso, flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int modificiarPermiso(CENPermiso permiso, int flag)
        //DESCRIPCION: Actualiza la lista de permisos
        {
            CADPermisos cad = new CADPermisos();
            try
            {
                return cad.guardarPermiso(permiso, flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENMenu> DataMenus()
        {
            //DESCRIPCION: carga todos lo mantenedores guardados
            CADPermisos permisos = new CADPermisos();
            try
            {
                return permisos.DataMenus();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CENMenu> DataMenus(int perfil)
        //DESCRIPCION: carga todos lo mantenedores guardados POR PERFIL
        {
            CADPermisos permisos = new CADPermisos();
            try
            {
                return permisos.DataMenusPerfil(perfil);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CENMenu> DataMantenedoresNombre(string nombre)
        {
            //DESCRIPCION: Busca los mantenedores por nombre
            CADPermisos permisos = new CADPermisos();
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
