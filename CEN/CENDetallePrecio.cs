using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENDetallePrecio
    {
        int correlativo;
        string descripcion;
        decimal precioVenta;

        public int Correlativo
        {
            get { return correlativo; }
            set { correlativo = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public decimal PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
    }
}
