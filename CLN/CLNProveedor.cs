using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNProveedor
    {
        public CENDatosProveedor Listadatosproveedor()
        {
            //CLASE DE LISTA DE PROVEEDOR
            CENDatosProveedor listaproveedor = new CENDatosProveedor();
            CADProducto consulta = new CADProducto();
            try
            {
                listaproveedor = consulta.CENdatosproveedor();
                return listaproveedor;
            }
            catch (Exception ex)
            {
 				throw ex;
            }
        }

        public List<CENProveedor> ListaProveedores(int flag)
        {
            try
            {
                List<CENProveedor> Listproveedor = new List<CENProveedor>();
                CADProducto proveedor = new CADProducto();

                Listproveedor = proveedor.ListarProveedor(flag);
                return Listproveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
