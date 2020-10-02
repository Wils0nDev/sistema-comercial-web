using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENPreventaFiltro
    {
        public int ntraPreventa { get; set; }
        public int codUsuario { get; set; }
        public int codCliente { get; set; }
        public string codfechaRegistroI { get; set; }
        public string codfechaRegistroF { get; set; }
        public DateTime codfechaRegistroIDate { get; set; }
        public DateTime codfechaRegistroFDate { get; set; }
        public CENPreventaFiltro()
        {
            ntraPreventa = CENConstante.g_const_0;
            codUsuario = CENConstante.g_const_0;
            codCliente = CENConstante.g_const_0;
            codfechaRegistroI = CENConstante.g_const_vacio;
            codfechaRegistroF = CENConstante.g_const_vacio;
        }
    }
    public class CENVentaFiltroPA
    {
        public int ntraVenta { get; set; }   //codigo de venta
        public string serie { get; set; } //Serie
        public int nroDocumento { get; set; } //Numero de la venta
        public string nroDocumentoCadena { get; set; } //Numero de la venta cadena
        public int codVendedor { get; set; } // codigo de vendedor
        public string vendedor { get; set; }    //nombre del vendedor
        public int codCliente { get; set; } //Codigo de cliente
        public string cliente { get; set; }     //nombre del cliente
        public string identificacion { get; set; } // numero de documento del cliente
        public string codUbigeo { get; set; } //Codigo de ubigeo
        public int tipoVenta { get; set; }
        public string tVenta { get; set; }        //descripcion de la ruta
        public string tDoc { get; set; }        //descripcion delpunto de entrega
        public string estPre { get; set; }        //descripcion tipo documento
        public string fechaPago { get; set; }        //descripcion origen venta
        public string fechaTransaccion { get; set; }      //descripcion del estado
        public double importeRecargo { get; set; }      //Fecha de registro
        public double IGV { get; set; }      //Fecha de entrega
        public double importeTotal { get; set; }    //Recargo de la preventa
        public int tipoMoneda { get; set; }        //IGV de la preventa
        public string moneda { get; set; }      //Total a pagar
        public int ntraSucursal { get; set; } //Numero de sucursal
        public string sucursal { get; set; }
        public int tipoDocumentoVenta { get; set; } //Tipo de documento de venta
        public int codPuntoEntrega { get; set; } // Punto de entrega
        public string direccion { get; set; } // Direccion
        public string ruta { get; set; } //  ruta
        public int tipoPersona { get; set; } // Tipo de persona
        public List<CENNotaCreditoDatosDetalleVenta> listaDetalle { get; set; } //Lista de detalle
        public List<CENPrevDescDetalle> listaPromociones { get; set; }
        public List<CENPrevDescDetalle> listaDescuentos { get; set; }
        public List<CENFechaTrnsaccion> listaPagosFechas { get; set; }
        public List<CENFechaTrnsaccion> listaNCFechas { get; set; }
        public CENFechaTrnsaccion anulacionVenta { get; set; }
        public CENVentaFiltroPA()
        {
            ntraVenta = CENConstante.g_const_0;
            codVendedor = CENConstante.g_const_0;
            codCliente = CENConstante.g_const_0;
            IGV = CENConstante.g_const_0;
            importeTotal = CENConstante.g_const_0;
            importeRecargo = CENConstante.g_const_0;
            listaDetalle = new List<CENNotaCreditoDatosDetalleVenta>();
            listaPromociones = new List<CENPrevDescDetalle>();
            listaDescuentos = new List<CENPrevDescDetalle>();
            anulacionVenta = new CENFechaTrnsaccion();
        }
    }

    public class CENPreventaFiltroPA
    {
        public int ntraPreventa { get; set; }   //numero de preventa
        public int ntraSucursal { get; set; } //Numero de sucursal
        public int codUsuario { get; set; }
        public string vendedor { get; set; }    //nombre del vendedor
        public int codCliente { get; set; }
        public string cliente { get; set; }     //nombre del cliente
        public int tipoVenta { get; set; }
        public string tVenta { get; set; }        //descripcion de la ruta
        public string tDoc { get; set; }        //descripcion delpunto de entrega

        public string oVenta { get; set; }      //descripcion tipo de venta
        public string estPre { get; set; }        //descripcion tipo documento
        public string fecha { get; set; }        //descripcion origen venta
        public string fechaEntrega { get; set; }      //descripcion del estado
        public double recargo { get; set; }      //Fecha de registro
        public double igv { get; set; }      //Fecha de entrega
        public double total { get; set; }    //Recargo de la preventa
        public int tipoMoneda { get; set; }        //IGV de la preventa
        public string moneda { get; set; }      //Total a pagar
        public int tipoDocumentoVenta { get; set; } //Tipo de documento de venta
        public int codPuntoEntrega { get; set; } // Punto de entrega

        public CENPreventaFiltroPA()
        {
            ntraPreventa = CENConstante.g_const_0;
            codUsuario = CENConstante.g_const_0;
            codCliente = CENConstante.g_const_0;
            igv = CENConstante.g_const_0;
            total = CENConstante.g_const_0;
            recargo = CENConstante.g_const_0;

        }
    }
    public class CEN_CuentaCobro
    {
        public int ntra { get; set; }
        public int codVenta { get; set; }
        public int codModulo { get; set; }
        public int prefijo { get; set; }
        public int correlativo { get; set; }
        public double importe { get; set; }
        public DateTime fechaTransaccion { get; set; }
        public string horaTransaccion { get; set; }
        public DateTime fechaCobro { get; set; }
        public int estado { get; set; }
        public string responsable { get; set; }

        public CEN_CuentaCobro()
        {
            ntra = CENConstante.g_const_0;
            codVenta = CENConstante.g_const_0;
            codModulo = CENConstante.g_const_0;
            prefijo = CENConstante.g_const_0;
            correlativo = CENConstante.g_const_0;
            importe = CENConstante.g_const_0;
            estado = CENConstante.g_const_0;
            responsable = CENConstante.g_const_vacio;
        }


    }

    public class CEN_DataVenta
    {
        public string serie { get; set; }
        public int nroDocumento { get; set; }
        public int sucursal { get; set; }
        public short tipoPago { get; set; }
        public int codPreventa { get; set; }
        public int codCliente { get; set; }
        public int codVendedor { get; set; }
        public int tipoVenta { get; set; }
        public DateTime fechaTransaccion { get; set; }
        public DateTime fechaPago { get; set; }
        public int tipoMoneda { get; set; }
        public short tipoCambio { get; set; }
        public short estado { get; set; }
        public double importeTotal { get; set; }
        public double importeRecargo { get; set; }
        public double IGV { get; set; }
        public string usuario { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
        public int proceso { get; set; }
        public int tipoDocumentoVenta { get; set; }
        public int codPuntoEntrega { get; set; }
        public int est_reg_cue_cob { get; set; }

        public CENPrestamo prestamo { get; set; }
        public List<CENCronograma> listCuotas { get; set; }
        public CEN_CuentaCobro cuentaCobro { get; set; }
        public CEN_DataVenta()
        {
            prestamo = new CENPrestamo();
            listCuotas = new List<CENCronograma>();
            ip = CENConstante.g_const_vacio;
            mac = CENConstante.g_const_vacio;
            usuario = CENConstante.g_const_vacio;
            cuentaCobro = new CEN_CuentaCobro();
            IGV = CENConstante.g_const_0;
            est_reg_cue_cob = CENConstante.g_const_0;
        }

    }

    public class CENPrestamo
    {
        public int codVenta { get; set; }
        public double importeTotal { get; set; }
        public double interesTotal { get; set; }
        public int plazo { get; set; }
        public int nroCuotas { get; set; }
        public DateTime fechaTransaccion { get; set; }
        public short tipoPrestamo { get; set; }
        public string usuario { get; set; }
        public int estado { get; set; }
        public CENPrestamo()
        {
            fechaTransaccion = DateTime.Now;
            codVenta = CENConstante.g_const_0;
            importeTotal = CENConstante.g_const_0;
            interesTotal = CENConstante.g_const_0;
            plazo = CENConstante.g_const_0;
            nroCuotas = CENConstante.g_const_0;
            tipoPrestamo = CENConstante.g_const_0;
            usuario = CENConstante.g_const_vacio;
            estado = CENConstante.g_const_0;
        }
    }
    public class CENCronograma
    {
        public int codPrestamo { get; set; }
        public DateTime fechaPago { get; set; }
        public int nroCuota { get; set; }
        public double importe { get; set; }
        public short estado { get; set; }
        public string usuario { get; set; }
        public string descestado { get; set; }  
    }

    public class CENRespVenta
    {
        public int flag { get; set; }
        public string msje { get; set; }
        public int venta { get; set; }
        public string serie { get; set; }
        public int nroDocumento { get; set; }
    }

    public class CENReqVenta
    {
        public int codPreventa { get; set; }
        public int codCliente { get; set; }
        public int codVendedor { get; set; }
        public DateTime fechaPago { get; set; }
        public int tipoVenta { get; set; }
        public int tipoMoneda { get; set; }
    }
    public class CENPrevDescDetalle
    {
        public int codVenta { get; set; }
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public CENPrevDescDetalle()
        {
            codVenta = CENConstante.g_const_0;
            codigo = CENConstante.g_const_0;
            descripcion = CENConstante.g_const_vacio;
        }
    }

    public class CENFechaTrnsaccion
    {
        public int codigo { get; set; }
        public string fechaTransaccion { get; set; }
        public string horaTransaccion { get; set; }
        public string vendedor { get; set; }

        public CENFechaTrnsaccion()
        {
            codigo = CENConstante.g_const_0;
            fechaTransaccion = CENConstante.g_const_vacio;
            horaTransaccion = CENConstante.g_const_vacio;
            vendedor = CENConstante.g_const_vacio;
        }
    }
}
