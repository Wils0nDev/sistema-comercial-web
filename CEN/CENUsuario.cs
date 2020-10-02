using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENUsuario
    {
        //Para mi select de vendedores
        public int ntraUsuario { get; set; }
        public string vendedor { get; set; }

        //para el listado de credenciales de usuario
        public string password { get; set; }

        public string nombre { get; set; }

        public string perfil { get; set; }

        public int respuesta { get; set; }

        public string mensaje { get; set; }
        public string sucursal { get; set; }

        public string telefono { get; set; }

        public int fkcodPersona { get; set; }
        //nuevo
        public int codPerfil { get; set; }
    }
}
