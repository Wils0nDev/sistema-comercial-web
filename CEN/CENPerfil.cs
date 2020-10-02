using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENPerfil
    {
        //para la vista edicion de perfil
        public string usuario { set; get; }
        public string nombre { set; get; }

        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string password { get; set; }
        public int codUsuario { get; set; }
        public int codPersona { get; set; }
    }
}
