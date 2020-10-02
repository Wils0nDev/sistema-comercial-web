using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
    public class CLNAlmacen
    {
        public CENDatosCodigoAlmacen CodigoAlmacen(string DescAlmacen)
        {
            //DESCRIPCION:CLASE DE OBTENER CODIGO DE ALMACEN
            CENDatosCodigoAlmacen CodigoAlmacen = new CENDatosCodigoAlmacen();
            CADProducto consulta = new CADProducto();
            try
            {
                CodigoAlmacen = consulta.CENCodigoAlmacen(DescAlmacen);
                return CodigoAlmacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CENHAlmacen> ObtenerDetalleAlmacen(List<CENHAlmacen> listacabecera)
        {
            //DESCRIPCION:Lista para obtener data del detalle del almacen
            List<CENHAlmacen> listaCabecera = new List<CENHAlmacen>();
            List<CENDAlmacen> listDetalle = new List<CENDAlmacen>();
            CADProducto producto = new CADProducto();
            try
            {
                for (int i = CENConstante.g_const_0; i < listacabecera.Count; i++)
                {
                    CENHAlmacen cabecera = new CENHAlmacen();
                    cabecera.CodProducto = listacabecera[i].CodProducto;
                    cabecera.Categoria = listacabecera[i].Categoria;
                    cabecera.SubCategoria = listacabecera[i].SubCategoria;
                    cabecera.Fabricante = listacabecera[i].Fabricante;
                    cabecera.DescProducto = listacabecera[i].DescProducto;
                    cabecera.fechavencimiento = listacabecera[i].fechavencimiento;
                    listDetalle = producto.ObtenerDetalleAlmacen(listacabecera[i].CodProducto);
                    cabecera.DatosAlmacen = listDetalle;
                    cabecera.TotalStock = producto.CalcularMontoInventario(listacabecera[i].CodProducto).ToString();
                    listaCabecera.Add(cabecera);
                }
                return listaCabecera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
