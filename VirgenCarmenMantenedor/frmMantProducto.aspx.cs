using CEN;
using CLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirgenCarmenMantenedor
{
    public partial class frmMantProducto1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CENProducto> ListarCategorias(int flag)
        {
            CLNProducto categoria = null;
            List<CENProducto> ListaCategorias = null;

            try
            {
                categoria = new CLNProducto();
                ListaCategorias = categoria.ListarCategorias(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaCategorias;
        }
        [WebMethod]
        public static List<CENSubcategoria> ListarSubCategoria(int codCat)
        {
            CLNSubCategoria subCategoria = null;
            List<CENSubcategoria> ListaSubCategoria = null;
            try
            {
                subCategoria = new CLNSubCategoria();
                ListaSubCategoria = subCategoria.ListarSubCategoriasPorCategoria(codCat);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaSubCategoria;
        }

        [WebMethod]
        public static List<CENFabricante> ListaFabricante(int flag)
        {
            CLNFabricante fabricante = null;
            List<CENFabricante> ListFabr = null;

            try
            {
                fabricante = new CLNFabricante();
                ListFabr = fabricante.ListaFabricante(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListFabr;
        }
        [WebMethod]
        public static List<CENProveedor> ListaProveedor(int flag)
        {
            CLNProveedor proveedor = null;
            List<CENProveedor> ListProv = null;
            try
            {
                proveedor = new CLNProveedor();
                ListProv = proveedor.ListaProveedores(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListProv;
        }

        [WebMethod]
        public static List<CENConcepto> ListaCampos(int flag)
        {
            CLNConcepto concepto = null;
            List<CENConcepto> ListaCampos = null;

            try
            {
                concepto = new CLNConcepto();
                ListaCampos = concepto.ListarConceptos(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaCampos;
        }

        [WebMethod]
        public static List<CENProductoLista> ListaProductos(int codCategoria, int codSubcategoria, int codigoFabricante, int codigoProveedor, string descripcion)
        {
            List<CENProductoLista> ListaProduc = null;
            CENProducto objCENProducto = null;
            CLNProducto objCLNProduc = null;

            try
            {
                objCLNProduc = new CLNProducto();
                objCENProducto = new CENProducto(codCategoria, codSubcategoria, codigoProveedor, codigoFabricante, descripcion);
                ListaProduc = objCLNProduc.ListarProductos(objCENProducto);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaProduc;
        }
        [WebMethod]
        public static List<CENProductoListaDetalle> ListaProductoByCod(string codProducto)
        {
            List<CENProductoListaDetalle> ListaProducCod = null;
            CLNProducto objCLNProducCod = null;

            try
            {
                objCLNProducCod = new CLNProducto();
                ListaProducCod = objCLNProducCod.ListaProductoCodCategoria(codProducto);
                //    Console.WriteLine("esto es la lista " + ListaProducCod);


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaProducCod;

        }

        [WebMethod]
        public static int EliminarProducto(string Cod)
        {
            CLNProducto objCLNProducto = null;
            try
            {
                objCLNProducto = new CLNProducto();
                int ok = objCLNProducto.EliminarProducto(Cod);
                return ok;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public static List<string> InsertarProduct(string descripcion, int codUnidadBase, int codCategoria, int codsubcat, int tipoProduct, int flag,
                int codFabricant, int codProveedor)
        {

            CLNProducto objCLNProduct = null;
            CENProductosInsert objProduc = new CENProductosInsert()
            {
                descProducto = Convert.ToString(descripcion),
                undBase = Convert.ToInt16(codUnidadBase),
                codCategoria = Convert.ToInt32(codCategoria),
                codSubCategoria = Convert.ToInt32(codsubcat),
                tipoProducto = Convert.ToInt32(tipoProduct),
                flagVenta = Convert.ToInt32(flag),
                codFabricante = Convert.ToInt32(codFabricant),
                codProveedor = Convert.ToInt32(codProveedor),

            };
            try
            {
                objCLNProduct = new CLNProducto();
                List<string> ok = objCLNProduct.InsertarProduct(objProduc);
                return ok;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static int InsertDetalleProducto(string codProducto, int codPresentacion, int cantUB)
        {
            CLNProducto objCLNProduc = null;
            CEN_Detalle_Presentacion_Product objCENdetalle = new CEN_Detalle_Presentacion_Product()
            {
                codProductos = codProducto,
                codDetPresents = Convert.ToInt32(codPresentacion),
                cantUniBases = Convert.ToInt32(cantUB)


            };
            try
            {
                objCLNProduc = new CLNProducto();
                int ok = objCLNProduc.InsertarDetProducto(objCENdetalle);
                return ok;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public static int ActualizarProduct(string descripcion, int codUnidadBase, int codCategoria, int codsubcat, int tipoProduct, int flag,
                int codFabricant, int codProveedor, string codProducto)
        {
            //
            //
            CENProducto objProductAct = new CENProducto()
            {
                descProducto = Convert.ToString(descripcion),
                undBase = Convert.ToInt16(codUnidadBase),
                codCategoria = Convert.ToInt32(codCategoria),
                codSubCategoria = Convert.ToInt32(codsubcat),
                tipoProducto = Convert.ToInt32(tipoProduct),
                flagVenta = Convert.ToInt32(flag),
                codFabricante = Convert.ToInt32(codFabricant),
                codProveedor = Convert.ToInt32(codProveedor),
                codProducto = Convert.ToString(codProducto)
            };
            CLNProducto objCLNProducto = null;

            try
            {
                objCLNProducto = new CLNProducto();
                int ok = objCLNProducto.ActulizarProducto(objProductAct, codProducto);
                return ok;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public static int ActualizarDetProduct(int codPresentacion, int cantidad, string codProducto)
        {
            CEN_Detalle_Presentacion_Product objCENPresentacion = new CEN_Detalle_Presentacion_Product()
            {
                codDetPresents = Convert.ToInt16(codPresentacion),
                cantUniBases = Convert.ToInt32(cantidad),
                codProductos = Convert.ToString(codProducto)
            };
            CLNProducto objCLNProductoPresentacion = null;
            string codProduct = codProducto;

            try
            {
                objCLNProductoPresentacion = new CLNProducto();
                int ok = objCLNProductoPresentacion.ActualizarDetalleProduct(objCENPresentacion, codProduct, codPresentacion);
                return ok;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public static List<CEN_Detalle_Presentacion_Product> ListaDetallePresentacionProduct(string codProductos)
        {
            List<CEN_Detalle_Presentacion_Product> ListaProducCod = null;
            CLNProducto objCLNProducCod = null;

            try
            {
                objCLNProducCod = new CLNProducto();
                ListaProducCod = objCLNProducCod.ListarPresentacionProduc(codProductos);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaProducCod;

        }

        [WebMethod]
        public static int EliminarPresentacionProductActualizar(string cod, int codP)
        {

            CLNProducto objCLNProductoEliminarDetalle = null;
            try
            {
                objCLNProductoEliminarDetalle = new CLNProducto();
                int ok = objCLNProductoEliminarDetalle.EliminarPresentacionProductActualizar(cod, codP);
                return ok;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}