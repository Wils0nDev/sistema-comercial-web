using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    //Para mantener la persistencia , se serializa
    [Serializable]

    public class CENCliente : CENPersona
    {
        public List<CENCliente> lcli = new List<CENCliente>();
        public Int16 ordenAtencion { get; set; }
        public Byte perfilCliente { get; set; }
        public string descPerfilCliente { get; set; }
        public Byte clasificacionCliente { get; set; } 
        public string descClasificacion { get; set; }
        public Byte frecuenciaCliente { get; set; }
        public string descFrecuencia { get; set; }
        public Byte tipoListaPrecio { get; set; }
        public string descTipoListaPrecio { get; set; }
        public Int32 codRuta { get; set; }
        public string descCodRuta { get; set; }
        public string coordenadaX { get; set; }
        public string coordenadaY { get; set; }
    }

}
