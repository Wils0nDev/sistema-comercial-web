using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENPermiso : CENMenu
    {
        // para listar nuevo permiso
        public int codPermiso { get; set; }

        public int codResponsable { get; set; }

        public int opcion { get; set; }



        // para insertar los permisos

        public List<CENPermiso> listPermiso { get; set; }

        public CENPermiso()
        {
            listPermiso = new List<CENPermiso>();
        }
    }
}
