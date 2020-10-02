using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENDPrecio
    {
        int tipoListaPrecio;
        string precioVenta;

        public CENDPrecio()
        {
            tipoListaPrecio = 0;
            precioVenta = "";
        }
        public int TipoListaPrecio
        {
            get { return tipoListaPrecio; }
            set { tipoListaPrecio = value; }
        }

        public string PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }


    }
}
