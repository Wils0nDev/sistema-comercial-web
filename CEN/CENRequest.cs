using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENFrmMantCliente
    {
        public Int32 codPersona { get; set; }  //cliente
        public Int16 perfilCliente { get; set; } //cliente
        public Int16 categoriaCliente { get; set; } //cliente
        public Int16 clasificacionCliente { get; set; } //cliente
        public Int16 frecuenciaCliente { get; set; }  //cliente
        public Int16 tipoPersona { get; set; }
        public Int16 tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string ruc { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public Int16 marcaBaja { get; set; } //cliente

        public List<CENCliente> lc = new List<CENCliente>();
    }

    public class Salida
    {
        public bool estado { get; set; }
        public string mensajes { get; set; }
    }

}
