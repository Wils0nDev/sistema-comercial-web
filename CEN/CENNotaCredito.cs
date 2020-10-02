using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENNotaCredito
    {

        public short flagReversion { get; set; }
        public int codVenta { get; set; }
        public short tipoVenta { get; set; }
        public string codMotivo { get; set; }
        public string fecha { get; set; }
        public short tipo { get; set; }
        public double importe { get; set; }
        public string usuario { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
        public int codSucursal { get; set; }
        public int codUsuario { get; set; }
        public List<CENListaDevueltos> listaDevueltos { get; set; }

        public CENNotaCredito()
        {
            listaDevueltos = new List<CENListaDevueltos>();
        }
    }

    public class CENListaDevueltos
    {
        public int itemVenta { get; set; }
        public string codProducto { get; set; }
        public int cantidad { get; set; }
        public int cantidad_ub { get; set; }
        public double precioVenta { get; set; }
        public int flag_des { get; set; }
        public int flag_pro { get; set; }
    }

    public class CENNotaCreditoParametroBuscarVenta
    {
        public string codVenta { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string codCliente { get; set; }
        public string codVendedor { get; set; }
    }

    public class CENNotaCreditoVenta
    {
        public int ntraVenta { get; set; }
        public string nombres { get; set; }
    }

    public class CENNotaCreditoDatosVenta
    {
        public int ntraVenta { get; set; }
        public string nomCliente { get; set; }
        public double tipoCambio { get; set; }
        public string serie { get; set; }
        public int nroDocumento { get; set; }
        public string nomVendedor { get; set; }
        public double importeTotal { get; set; }
        public double importeRecargo { get; set; }
        public int tipoVenta { get; set; }
    }

    public class CENNotaCreditoDatosDetalleVenta
    {
        public int itemVenta { get; set; }
        public string codProducto { get; set; }
        public string descProducto { get; set; }
        public int cantidadPresentacion { get; set; }
        public int cantidadUnidadBase { get; set; }
        public double precioVenta { get; set; }
        public string descAlmacen { get; set; }
        public string descUnidadBase { get; set; }
        public int tipoProducto { get; set; }
        public string descTipoProducto { get; set; }
        public double descuento { get; set; }
        public double descuento_disponible { get; set; }
        public int can_disponible { get; set; }
        public int can_devueltos { get; set; }
    }

    public class CENNotaCreditoMotivoNC
    {
        public string codigoMotivo { get; set; }
        public string descripcion { get; set; }
    }

    public class CENNotaCreditoVentaPromocion
    {
        public int codPromocion { get; set; }
        public int itemVenta { get; set; }
        public int itemPromocionado { get; set; }
    }

    public class CENNotaCreditoVentaDescuento
    {
        public int codDescuento { get; set; }
        public int itemVenta { get; set; }
        public double importe { get; set; }
    }

    public class CENNotaCreditoDatosPromocion
    {
        public double valor { get; set; }
        public int tipo { get; set; }
    }

    public class CENNotaCreditoDatosDescuento
    {
        public double valor { get; set; }
        public int tipo { get; set; }
        public double valorDescuento { get; set; }
        public int tipoDescuento { get; set; }
    }


    public class CENNotaCreditoRptaRegistroNC
    {
        public int ntraNC { get; set; }
    }

    public class CENNotaCreditoCabeceraImpresion
    {
        public string serieNC { get; set; }
        public int numeroNC { get; set; }
        public double tipoCambioNC { get; set; }
        public string fechaNC { get; set; }
        public string tipoNC { get; set; }
        public string motivoNC { get; set; }

        public string serieV { get; set; }
        public int numeroV { get; set; }
        public double importeTotalV { get; set; }
        public double importeIgvV { get; set; }
        public double importeSubTotalV { get; set; }
        public string nombreC { get; set; }
        public string nroDocumentoC { get; set; }
        public List<CENNotaCreditoDetalleImpresion> listaDetalle { get; set; }
        public CENNotaCreditoCabeceraImpresion()
        {
            listaDetalle = new List<CENNotaCreditoDetalleImpresion>();
        }
    }

    public class CENNotaCreditoDetalleImpresion
    {
        public int itemVenta { get; set; }
        public string codProducto { get; set; }
        public string descProducto { get; set; }
        public int cantidad { get; set; }
        public string descUnidad { get; set; }
        public double precioVenta { get; set; }
        public string descTipoProducto { get; set; }
        public double subTotal { get; set; }
    }

    public class CENNotaCreditoRptaValidacion
    {
        public int flag { get; set; }
        public string msje { get; set; }
    }

    public class CENNotaCreditoParametrosRpta
    {
        public double igv { get; set; }
    }

    public class CENNotaCreditoParametros
    {
        public int flag { get; set; }
        public int codSucursal { get; set; }
    }
}
