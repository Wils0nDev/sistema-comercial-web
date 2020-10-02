using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNPerfil
    {
        public int actualizarPerfil(CENPerfil perfil)
            //DESCRIPCION: Actualiza los datos de perfil
        {
            CADPerfil cdUsu = new CADPerfil();
            int codigo = 0;
            try
            {
                codigo = cdUsu.actualizarPerfil(perfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return codigo;
        }

        public List<CENPerfil> datosPerfil(int codUsuario, int codPersona)
            //DESCRIPCION: Recupera datos de perfil
        {
            List<CENPerfil> dataPerfil = new List<CENPerfil>();
            CADPerfil cp = new CADPerfil();
            try
            {
                dataPerfil = cp.DatosPerfil(codUsuario, codPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataPerfil;
        }
    }
}
