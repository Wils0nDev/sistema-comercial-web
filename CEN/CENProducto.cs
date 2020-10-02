using System.Collections.Generic;

namespace CEN
{
    public class CENDatosProducto
    {
        //DESCRIPCION : Clase de respuesta de datos de producto
        public List<CENProducto> DatosProducto { get; set; } //Datos de clase producto
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENDatosProducto()
        {
            DatosProducto = new List<CENProducto>();
            ErrorWebSer = new CENErrorWebSer();
        }
    }
    public class CENProducto
    {
        //DESCRIPCION: ENTIDAD PRODUCTO
        public string codProducto { get; set; }
        public int codCategoria { get; set; }
        public string descCategoria { get; set; }
        public int codSubCategoria { get; set; }
        public string descSubCategoria { get; set; }
        public int codProveedor { get; set; }
        public string descProveedor { get; set; }
        public int codFabricante { get; set; }
        public string descFabricante { get; set; }
        public string descProducto { get; set; }
        public string fechavencimiento { get; set; }
        public short cantAlmPrincipal { get; set; }
        public int undBase { get; set; }
        public string descUndBase { get; set; }
        public int tipoProducto { get; set; }
        public string desctipoProducto { get; set; }
        public int flagVenta { get; set; }
        public int cantUnidBase { get; set; }

        public CENProducto()
        {

        }

        public CENProducto(int codCategoria, int codSubCategoria, int codProveedor, int codFabricante, string descripcion)
        {
            this.codCategoria = codCategoria;
            this.codSubCategoria = codSubCategoria;
            this.codProveedor = codProveedor;
            this.codFabricante = codFabricante;
            this.desctipoProducto = descripcion;

        }
    }

    public class CENProductosInsert
    {

        public int codCategoria { get; set; }
        public int codSubCategoria { get; set; }
        public int codProveedor { get; set; }
        public int codFabricante { get; set; }
        public string descProducto { get; set; }
        public int undBase { get; set; }
        public int tipoProducto { get; set; }
        public int flagVenta { get; set; }

    }

    public class CENProductoListaDetalle
    {
        public string codProducto { get; set; }
        public int descCategoria { get; set; }
        public int descSubCategoria { get; set; }
        public int descProveedor { get; set; }
        public int descFabricante { get; set; }
        public string descProducto { get; set; }
        public int descUndBase { get; set; }
        public int tipoProducto { get; set; }
        public int flagVenta { get; set; }
       public string codProductov2 { get; set; }
        public int descPresentacion { get; set; }
        public int cantUnidBase { get; set; }

        public CENProductoListaDetalle(string codProducto)
        {
            this.codProducto = codProducto;
        }
        public CENProductoListaDetalle()
        {

        }
    }
    public class CEN_Detalle_Presentacion_Product
    {
        public string codProductos { get; set; }
        public int codDetPresents { get; set; }

        public string nom { get; set; }
        public int cantUniBases { get; set; }

    }
    public class CENDatoscategoria
    {
        //DESCRIPCION : Clase de respuesta de datos de categoria
        public List<CENCategoria> DatosCategoria { get; set; } //Datos de clase Categoria
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENDatoscategoria()
        {
            DatosCategoria = new List<CENCategoria>();
            ErrorWebSer = new CENErrorWebSer();
        }
    }

    public class CENDatoSubscategoria
    {
        //DESCRIPCION : Clase de respuesta de datos de sub categoria
        public List<CENSubCategoria> DatosSubCategoria { get; set; } //Datos de clase sub categoria
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENDatoSubscategoria()
        {
            DatosSubCategoria = new List<CENSubCategoria>();
            ErrorWebSer = new CENErrorWebSer();
        }
    }
    public class CENDatosProveedor
    {
        //DESCRIPCION : Clase de respuesta de datos de proveedores
        public List<CENProveedor> DatosProveedor { get; set; } //Datos de clase sub proveedor
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENDatosProveedor()
        {
            DatosProveedor = new List<CENProveedor>();
            ErrorWebSer = new CENErrorWebSer();
        }
    }

    public class CENDatosFabricante
    {
        //DESCRIPCION : Clase de respuesta de datos de proveedores
        public List<CENFabricante> DatosFabricante { get; set; } //Datos de clase sub proveedor
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENDatosFabricante()
        {
            DatosFabricante = new List<CENFabricante>();
            ErrorWebSer = new CENErrorWebSer();
        }
    }

    public class CENDatosDetalleAlmacen
    {
        //DESCRIPCION: DATOS DE DETALLE DE ALMACEN
        public List<CENDetalleAlmacen> DatosDetalleAlmacen { get; set; } //Lista de detalle de almacenes
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENDatosDetalleAlmacen()
        {
            DatosDetalleAlmacen = new List<CENDetalleAlmacen>();
            ErrorWebSer = new CENErrorWebSer();
        }
    }
    public class CENDatosRegistrostock
    {
        //DESCRIPCION : CLASE DE REGISTRO DE STOCK
        public string mensaje { get; set; } //mensaje
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENDatosRegistrostock()
        {
            ErrorWebSer = new CENErrorWebSer();
        }

    }
    public class CENDatosCodigoAlmacen
    {
        //DESCRIPCION: Class para obtener el codigo de almacen
        public int CodAlmacen { get; set; } //Codigo de almacen
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENDatosCodigoAlmacen()
        {
            ErrorWebSer = new CENErrorWebSer();
        }
    }
    public class CENCategoria
    {
        //DESCRIPCION : Clase de lista de categoria
        public int codigoCategoria { get; set; } // Codigo de categoria
        public int correlativo { get; set; } //flag de correlativo
        public string descCategoria { get; set; } //Descripcion de categoria
    }

    public class CENSubCategoria
    {
        //DESCRIPCION : Clase de lista de sub categorias
        public int codigoSubCategoria { get; set; } // Codigo de subcategoria
        public string descSubCategoria { get; set; } //Descripcion de subcategoria
    }
    public class CENProveedor
    {
        //DESCRIPCION : Clase de lista de proveedores
        public int codigoProveedor { get; set; } //Codigo de Proveedor
        public string descproveedor { get; set; } //descripcion de Proveedor
    }
    public class CENFabricante
    {
        //DESCRIPCION : Clase de lista de Fabricantes
        public int codigoFabricante { get; set; } //Codigo de Fabricante
        public string descFabricante { get; set; } //descripcion de Fabricante
    }

    public class CENProductoLista
    {
        //DESCRIPCION: ENTIDAD PRODUCTO
        public string codProducto { get; set; }
        public int codCategoria { get; set; }
        public string descCategoria { get; set; }
        public int codSubCategoria { get; set; }
        public string descSubCategoria { get; set; }
        public int codProveedor { get; set; }
        public string descProveedor { get; set; }
        public int codFabricante { get; set; }
        public string descFabricante { get; set; }
        public string descProducto { get; set; }

        //public short undBase { get; set; }
        public string descUndBase { get; set; }

        public int tipoProducto { get; set; }

        public string desctipoProducto { get; set; }

        public int flagVenta { get; set; }
    }
    public class CENDetalleAlmacen
    {
        //DESCRIPCION : Clase de lista de Detalle Almacen
        public int transaccion { get; set; } //Codigo de almacen
        public string descAlmacen { get; set; } //Descripcion de almacen
        public string codProducto { get; set; } //Codigo de articulo
        public int stock { get; set; } //Monto de Stock de almacen
    }

    public class CENHAlmacen
    {
        //DESCRIPCION: CLASE DE CABECERA DE ALMACEN
        public string CodProducto { get; set; } //Codigo de Producto       
        public string Categoria { get; set; } //Categoria
        public string SubCategoria { get; set; } //Subcategoria
        public string Fabricante { get; set; } //Subcategoria
        public string DescProducto { get; set; } //Descripcion de producto
        public string fechavencimiento { get; set; } //Fecha de vencimiento
        public List<CENDAlmacen> DatosAlmacen { get; set; } //Lista de detalle de almacenes
        public string TotalStock { get; set; }
        public CENErrorWebSer ErrorWebSer { get; set; } //Error de web service
        public CENHAlmacen()
        {
            DatosAlmacen = new List<CENDAlmacen>();
            ErrorWebSer = new CENErrorWebSer();
        }
    }

    public class CENDAlmacen
    {
        //DESCRIPCION: CLASE DE DETALLE DE ALMACEN
        public int codAlmacen { get; set; } //Codigo de almacen     
        public int stock { get; set; } //Monto de stock
    }

    public class CENErrorWebSer
    {
        //DESCRIPCION : CLASE DE ERROR
        public short TipoErr { get; set; } // tipo de error 
        public int CodigoErr { get; set; } // codigo de error 
        public string DescripcionErr { get; set; } // descripcion de error 
        public CENErrorWebSer()
        {
            TipoErr = CENConstante.g_const_0;
            CodigoErr = CENConstante.g_const_0;
            DescripcionErr = CENConstante.g_const_vacio;
        }
    }

}
