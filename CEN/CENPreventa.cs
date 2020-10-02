using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENPreventa
    {
        public short proceso { get; set; }
        public int ntraPreventa { get; set; }
        public int codCliente { get; set; }
        public int codUsuario { get; set; }
        public int codPuntoEntrega { get; set; }
        public short tipoMoneda { get; set; }
        public short tipoVenta { get; set; }
        public short tipoDocumentoVenta { get; set; }
        public string fecha { get; set; }
        public string fechaEntrega { get; set; }
        public string fechaPago { get; set; }
        public short flagRecargo { get; set; }
        public double recargo { get; set; }
        public double igv { get; set; }
        public double isc { get; set; }
        public double total { get; set; }
        public short estado { get; set; }
        public string usuario { get; set; }         
        public string ip { get; set; }              
        public string mac { get; set; }             
        public short origenVenta { get; set; }
        public string horaEntrega { get; set; }
        public int codSucursal { get; set; }

        public List<CEN_Detalle_Preventa> listDetPreventa { get; set; }
        public List<CEN_Preventa_Promocion> listPrevPromocion { get; set; }
        public List<CEN_Preventa_Descuento> listPrevDescuento { get; set; }

        public CENPreventa()
        {
            listDetPreventa = new List<CEN_Detalle_Preventa>();
            listPrevPromocion = new List<CEN_Preventa_Promocion>();
            listPrevDescuento = new List<CEN_Preventa_Descuento>();
        }
    }

    public class CEN_Detalle_Preventa
    {
        public int codPreventa { get; set; }
        public short itemPreventa { get; set; }
        public int codPresentacion { get; set; }
        public string codProducto { get; set; }
        public int codAlmacen { get; set; }
        public int cantidadPresentacion { get; set; }
        public int cantidadUnidadBase { get; set; }
        public double precioVenta { get; set; }
        public short TipoProducto { get; set; }
    }

    public class CEN_Preventa_Promocion
    {
        public int codPreventa { get; set; }
        public int codPromocion { get; set; }
        public short itemPreventa { get; set; }
        public short itemPromocionado { get; set; }
    }

    public class CEN_Preventa_Descuento
    {
        public int codPreventa { get; set; }
        public int codDescuento { get; set; }
        public short itemPreventa { get; set; }
        public double importe { get; set; }
    }

    public class CENPreventaRegistro
    {
        public int ntraPreventa { get; set; } //numero de transaccion preventa
        //public int codPersona { get; set; } //codigo persona
        //public int ntraPuntoEntrega { get; set; } //numero de transaccion punto entrega
    }

    public class CENPreventaCliente
    {
        public int codCliente { get; set; }
        public string nombres { get; set; }
        public int tipoListaPrecio { get; set; }
        public string numDocumento { get; set; }

    }

    public class CENPreventaPuntoEntrega
    {
        public int codPuntoEntrega { get; set; }
        public string descripcion { get; set; }
    }

    public class CENPreventaProducto
    {
        public string codProducto { get; set; }
        public string descripcion { get; set; }
    }

    public class CENPreventaProductoPrecio
    {
        public double precio { get; set; }
        public int tipoProducto { get; set; }
    }

    public class CENPreventaProductoPresentacion
    {
        public int codPresentacion { get; set; }
        public string descripcion { get; set; }
        public int cantidadUnidadBase { get; set; }
    }

    public class CENPreventaProductoAlmacen
    {
        public int codAlmacen { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
    }

    public class CENPreventaParametros
    {
        public double igv { get; set; }
        public int flagRecargo { get; set; }
        public double porcentajeRecargo { get; set; }
        //public int stock { get; set; }
    }

    public class CENPreventaPromocionProducto
    {
        public int ntraPromocion { get; set; }
        public string descPromocion { get; set; }
        public double valor { get; set; }
        public int tipo { get; set; }
    }

    public class CENPreventaPromocionParametro
    {
        public string codProducto { get; set; }
        public int codUsuario { get; set; }
        public int codCliente { get; set; }
        public int tipoVenta { get; set; }
    }

    public class CENPreventaProductosRegalo
    {
        public int valorEntero1 { get; set; }
        public int valorEntero2 { get; set; }
        public double valorMoneda1 { get; set; }
        public double valorMoneda2 { get; set; }
        public string valorCadena1 { get; set; }
        public string valorCadena2 { get; set; }
        public string valorFecha1 { get; set; }
        public string valorFecha2 { get; set; }
        public int codUnidadBase { get; set; }
        public string descUnidadBase { get; set; }
        public string descProducto { get; set; }
        public string descAlmacen { get; set; }
    }

    //DESCUENTOS
    public class CENPreventaDescuentosProducto
    {
        public int ntraDescuento { get; set; }
        public string descDescuento { get; set; }
        public double valor { get; set; }
        public int tipo { get; set; }
        public double valorDescuento { get; set; }
        public int tipoDescuento { get; set; }
    }

    public class CENPreventaDescuentoParametro
    {
        public string codProducto { get; set; }
        public int codUsuario { get; set; }
        public int codCliente { get; set; }
        public int tipoVenta { get; set; }
        public int tipoDescuento { get; set; }
    }

}
