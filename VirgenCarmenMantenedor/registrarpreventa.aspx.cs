using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirgenCarmenMantenedor
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static CENObtenerPreventa obtenerPreventa(string npre)
        {
            CENObtenerPreventa objCENObtenerPreventa = null;
            CADPreventa cadPreventa = null;
            try
            {
                cadPreventa = new CADPreventa();
                objCENObtenerPreventa = cadPreventa.obtenerPreventa(npre);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return objCENObtenerPreventa;
        }

        [WebMethod]
        public static List<CENPreventaCliente> buscarCliente(string cadena)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaCliente> lista = null;
            try
            {
                lista = cadPreventa.buscarCliente(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static List<CENPreventaPuntoEntrega> listarPuntosEntregaCliente(int codCliente)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaPuntoEntrega> lista = null;
            try
            {
                lista = cadPreventa.listarPuntosEntregaCliente(codCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static List<CENPreventaProducto> listarProductos(string cadena)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaProducto> lista = null;
            try
            {
                lista = cadPreventa.listarProductos(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static CENPreventaProductoPrecio precioProducto(string codProducto, int tipoListaPrecio)
        {
            CADPreventa cadPreventa = new CADPreventa();
            CENPreventaProductoPrecio lista = null;
            try
            {
                lista = cadPreventa.precioProducto(codProducto, tipoListaPrecio);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static List<CENPreventaProductoPresentacion> presentacionProductos(string codProducto)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaProductoPresentacion> lista = null;
            try
            {
                lista = cadPreventa.presentacionProductos(codProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static List<CENPreventaProductoAlmacen> almacenProductos(string codProducto)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaProductoAlmacen> lista = null;
            try
            {
                lista = cadPreventa.almacenProductos(codProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static CENPreventaRegistro registrarPreventa(CENPreventa preventa)
        {
            CADPreventa cadPreventa = new CADPreventa();
            CENPreventaRegistro obj = null;
            try
            {
                obj = cadPreventa.registrarpreventa(preventa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        [WebMethod]
        public static CENPreventaParametros obtenerParametrosPreventa()
        {
            CADPreventa cadPreventa = new CADPreventa();
            CENPreventaParametros obj = null;
            try
            {
                obj = cadPreventa.parametrosPreventa();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        [WebMethod]
        public static List<CENPreventaPromocionProducto> obtenerPromocionesProducto(CENPreventaPromocionParametro parametro)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaPromocionProducto> lista = null;
            try
            {
                lista = cadPreventa.obtenerPromocionesProducto(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static List<CENPreventaProductosRegalo> obtenerProductosRegalo(int ntraPromocion)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaProductosRegalo> lista = null;
            try
            {
                lista = cadPreventa.obtenerProductosRegalo(ntraPromocion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        [WebMethod]
        public static List<CENPreventaDescuentosProducto> obtenerDescuentosProducto(CENPreventaDescuentoParametro parametro)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaDescuentosProducto> lista = null;
            try
            {
                lista = cadPreventa.obtenerDescuentosProducto(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }
    }
}