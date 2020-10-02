using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace CLN
{
    public class CLNProducto
    {
        public CENDatosProducto ListaDatosProducto(int codCategoria, int codSubCategoria, int codProveedor, int codFabricante, string descripcion)
        {
            //DESCRIPCION: CLASE DE LISTA PRODUCTOS
            CENDatosProducto listaproductos = new CENDatosProducto();
            CADProducto consulta = new CADProducto();
            try
            {
                listaproductos = consulta.CENdatosproductos(codCategoria, codSubCategoria, codProveedor, codFabricante, descripcion);
                return listaproductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerCantidad(string CodArticulo)
        {
            //DESCRIPCION: Validar la existencia del articulo para la carga masiva
            CADProducto consulta = new CADProducto();
            int cant = CENConstante.g_const_0;
            try
            {
                cant = consulta.ObtenerProducto(CodArticulo);
                return cant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerMontoTotalAlmacen(string CodArticulo)
        {
            // DESCRIPCION: Obtener monto total de almacen de cada articulo
            CADProducto consulta = new CADProducto();
            int cant = CENConstante.g_const_0;
            try
            {
                cant = consulta.CalcularMontoInventario(CodArticulo);
                return cant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ObtenerDataTableReporte(List<CENHAlmacen> listacabecera)
        {
            //DESCRIPCION: OBTENER DATA TABLE
            List<CENConcepto> listaconcepto = new List<CENConcepto>();
            CLNConcepto concepto = new CLNConcepto();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            StringWriter sw = new StringWriter(sb);
            //LLENAR CABECERAS ESTATICAS
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add(("CodigoProducto").ToUpper());
            dt.Columns.Add(("Categoria").ToUpper());
            dt.Columns.Add(("Subcategoria").ToUpper());
            dt.Columns.Add(("Fabricante").ToUpper());
            dt.Columns.Add(("Descripcion").ToUpper());
            // dt.Columns.Add(("FechaVencimiento").ToUpper());
            //LLENAR CABECERAS DINAMICAS
            listaconcepto = concepto.ListarConceptos(CENConstante.g_const_17);
            for (int i = CENConstante.g_const_0; i < listaconcepto.Count; i++)
            {
                dt.Columns.Add(listaconcepto[i].descripcion);
            }
            dt.Columns.Add(("TotalStock").ToUpper());
            //CARGAR DATA EN DATA TABLE
            foreach (CENHAlmacen c in listacabecera)
            {
                System.Data.DataRow dr = dt.NewRow();
                dr["CodigoProducto"] = c.CodProducto;
                dr["Categoria"] = c.Categoria;
                dr["Subcategoria"] = c.SubCategoria;
                dr["Fabricante"] = c.Fabricante;
                dr["Descripcion"] = c.DescProducto;
                // dr["FechaVencimiento"] = c.fechavencimiento;
                int k = CENConstante.g_const_6; //Indice a partir de donde se van Obtener las Columnas Dinamicas
                foreach (CENDAlmacen d in c.DatosAlmacen)
                {
                    string columna = dt.Columns[k].ToString();
                    dr[columna] = d.stock;
                    k++;
                }
                dr["TotalStock"] = c.TotalStock;
                dt.Rows.Add(dr);
            }
            return dt;
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


        public List<CENProductoLista> ListarProductos(CENProducto datos)
        {
            CADProducto objCADProducto = null;

            try
            {
                objCADProducto = new CADProducto();
                return objCADProducto.ListaProductoPorFiltro(datos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int EliminarProducto(string Cod)
        {
            CADProducto objCLNEliminarProduc = null;
            try
            {
                objCLNEliminarProduc = new CADProducto();
                return objCLNEliminarProduc.EliminarProducto(Cod);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> InsertarProduct(CENProductosInsert objProduct)
        {
            CADProducto objCLNProduct = null;

            try
            {
                objCLNProduct = new CADProducto();
                return objCLNProduct.InsertarProducto(objProduct);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENProductoListaDetalle> ListaProductoCodCategoria(string codProducto)
        {
            CADProducto objProducCod = null;
            try
            {
                objProducCod = new CADProducto();
                return objProducCod.ListaProductoCodCategoria(codProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int InsertarDetProducto(CEN_Detalle_Presentacion_Product objDetProducto)
        {
            CADProductoView objCADdetProduct = null;
            try
            {
                objCADdetProduct = new CADProductoView();
                return objCADdetProduct.InsertarProductoView(objDetProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ActulizarProducto(CENProducto objProducto, string codProducto)
        {
            CADProducto objCLNProducto = null;
            try
            {
                objCLNProducto = new CADProducto();
                return objCLNProducto.ActualizarProducto(objProducto, codProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int ActualizarDetalleProduct(CEN_Detalle_Presentacion_Product objDet, string codProducto, int codDetProd)
        {
            CADProductoView objCLNDetProduct = null;
            try
            {
                objCLNDetProduct = new CADProductoView();
                return objCLNDetProduct.ActualizarDetProduct(objDet, codProducto, codDetProd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CEN_Detalle_Presentacion_Product> ListarPresentacionProduc(string codProductos)
        {

            CADProducto objProducCod = null;
            try
            {
                objProducCod = new CADProducto();
                return objProducCod.ListarDetallePresentacionProduct(codProductos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int EliminarPresentacionProductActualizar(string cod, int codP)
        {
            CADProducto objCLNEeliminarDetalle = null;
            try
            {
                objCLNEeliminarDetalle = new CADProducto();
                return objCLNEeliminarDetalle.EliminarDetallePresentacionActualizarProduct(cod,codP);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
