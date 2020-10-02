using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNDetalleAlmacen
    {
        public CENDatosDetalleAlmacen Listadatosdetallealmacen(string codArticulo)
        {
            //CLASE DE LISTA DE DETALLE DE ALMACENES
            CENDatosDetalleAlmacen listaalmacenes = new CENDatosDetalleAlmacen();
            CADProducto consulta = new CADProducto();
            try
            {
                listaalmacenes = consulta.CENdatosdetallealmacen(codArticulo);
                return listaalmacenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
