using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CEN
{
    [Serializable]

    public class CENPuntoEntrega
    {
        public List<CENPuntoEntrega> lpent = new List<CENPuntoEntrega>();

        public Int32 ntraPuntoEntrega { get; set; }
        public string coordenadaX { get; set; }
        public string coordenadaY { get; set; }
        public string codUbigeo { get; set; }
        public string descDepartamento { get; set; }
        public string descProvincia { get; set; }
        public string descDistrito { get; set; }
        public string direccion { get; set; }
        public string referencia { get; set; }
        public Int16 ordenEntrega { get; set; }
        public Int32 codPersona { get; set; }
        public string usuario { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
    }
}
