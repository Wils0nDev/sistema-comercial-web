using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNCategoria
    {
        public CENDatoscategoria Listadatoscategoria()
        {
            //CLASE DE LISTA DE CATEGORIAS
            CENDatoscategoria listacategoria = new CENDatoscategoria();
            CADProducto consulta = new CADProducto();
            try
            {
                listacategoria = consulta.CENdatoscategoria();
                return listacategoria;
            }
            catch (Exception ex)
            {
    			 throw ex;
            }
        }

        public List<CENProducto> ListarCategorias(int flag)
        {
            CADProducto categoria = null;
            try
            {
                categoria = new CADProducto();
                return categoria.ListarCategoria(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
