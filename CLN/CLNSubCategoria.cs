using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNSubCategoria
    {
        public CENDatoSubscategoria Listadatossubcategorias(int codcategoria)
        {
            //CLASE DE LISTA DE SUBCATEGORIAS
            CENDatoSubscategoria listasubcategorias = new CENDatoSubscategoria();
            CADProducto consulta = new CADProducto();
            try
            {
                listasubcategorias = consulta.CENdatossubbcategoria(codcategoria);
                return listasubcategorias;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
  public List<CENSubcategoria> ListarSubCategoriasPorCategoria(int codCategoria)
        {

            CADProducto objSubcategoria = null;
            try
            {
                objSubcategoria = new CADProducto();
                return objSubcategoria.ListarSubCategoriaPorCategoria(codCategoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
