using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNRegistroStock
    {
        public CENDatosRegistrostock DatosRegistroStock(int stock, string codArticulo, int codAlmacen)
        {
            //CLASE DE REGISTRO DE STOCK
            CENDatosRegistrostock datosstock = new CENDatosRegistrostock();
            CADProducto consulta = new CADProducto();
            try
            {
                datosstock = consulta.CENregistrostock(stock, codArticulo, codAlmacen);
                return datosstock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
