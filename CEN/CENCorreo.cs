using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENCorreo
    {
        //credencilaes del servidor de correo
        public string host { set; get; }
        public string puerto { set; get; }
        public string user { set; get; }
        public string password { set; get; }
        public string asunto { set; get; }

        //credenciales del receptor
        public string correoDestino { set; get; }
        public string contraseña { set; get; }

        //codigo de respuesta

        public int respuesta { set; get; }
        public string error { set; get; }
    }
}
