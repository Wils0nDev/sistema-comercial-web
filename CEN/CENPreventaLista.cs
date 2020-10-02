using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENObtenerPreventa
    {
        public int ntraPreventa { get; set; }
        public int codUsuario { get; set; }
        public int codCliente { get; set; }
        public int tipoVenta { get; set; }
        public int tipoDocumentoVenta { get; set; }
        public string fechaEntrega { get; set; }
        public string horaEntrega { get; set; }
        public int codPuntoEntrega { get; set; }
        public string cliente { get; set; }
        public string identificacion { get; set; }
        public string direccion { get; set; }
        public int tipoListaPrecio { get; set; }
        public int flagRecargo { get; set; }
    }

    public class CENPreventaDatos
    {
        public int ntraPreventa { get; set; }
        public int codUsuario { get; set; }
        public string codProducto { get; set; }
        public int codCliente { get; set; }
        public int codProveedor { get; set; }
        public int codRuta { get; set; }
        public int estado { get; set; }
        public int codTipo_venta { get; set; }
        public int codTipo_doc { get; set; }
        public int codOrigen_venta { get; set; }
        public string codfechaEntregaI { get; set; }
        public string codfechaEntregaF { get; set; }
        public string codfechaRegistroI { get; set; }
        public string codfechaRegistroF { get; set; }

        public CENPreventaDatos()
        {

        }

        public CENPreventaDatos(int ntraPreventa, int codUsuario, string codProducto, int codCliente, int codProveedor, int codRuta, int estado, int codTipo_venta, int codTipo_doc, int codOrigen_venta, string codfechaEntregaI, string codfechaEntregaF, string codfechaRegistroI, string codfechaRegistroF)
        {
            this.ntraPreventa = ntraPreventa;
            this.codUsuario = codUsuario;
            this.codProducto = codProducto;
            this.codCliente = codCliente;
            this.codProveedor = codProveedor;
            this.codRuta = codRuta;
            this.estado = estado;
            this.codTipo_venta = codTipo_venta;
            this.codTipo_doc = codTipo_doc;
            this.codOrigen_venta = codOrigen_venta;
            this.codfechaEntregaI = codfechaEntregaI;
            this.codfechaEntregaF = codfechaEntregaF;
            this.codfechaRegistroI = codfechaRegistroI;
            this.codfechaRegistroF = codfechaRegistroF;
        }
    }

    public class CENPreventaLista
    {
        public int ntraPreventa { get; set; }   //numero de preventa
        public string vendedor { get; set; }    //nombre del vendedor
        public string cliente { get; set; }     //nombre del cliente
        public string ruta { get; set; }        //descripcion de la ruta
        public string PuntoEntrega { get; set; }    //descripcion delpunto de entrega
        public string Tventa { get; set; }      //descripcion tipo de venta
        public string Tdoc { get; set; }        //descripcion tipo documento
        public string Oven { get; set; }        //descripcion origen venta
        public string estado { get; set; }      //descripcion del estado
        public string FechaR { get; set; }      //Fecha de registro
        public string FechaE { get; set; }      //Fecha de entrega
        public decimal recargo { get; set; }    //Recargo de la preventa
        public decimal igv { get; set; }        //IGV de la preventa
        public string moneda { get; set; }      //Tipo de moneda
        public decimal total { get; set; }      //Total a pagar
        public string sucursal { get; set; }      //Sucursal
        public int tipoPersona { get; set; }      //tipo de persona del cliente
        public string identificacion { get; set; }      //documento del cliente
        public int codestado { get; set; }      //codigo del estado
        public string codUbigeo { get; set; }      //codigo del ubigeo
        public int codUsuario { get; set; }      //codigo del vendedor
        public int codCliente { get; set; }      //codigo del cliente
        public int codPuntoEntrega { get; set; }      //codigo punto de entrega
    }

    public class CENDetallePreventa
    {
        public int item { get; set; }
        public string codProducto { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public int cantidadUnidadBase { get; set; }
        public string descAlmacen { get; set; }
        public int codAlmacen { get; set; }
        public string um { get; set; }
        public int codUnidad { get; set; }
        public string tipo { get; set; }
        public int codTipo { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }
        public int codDec { get; set; }
        public int codPro { get; set; }
        public string descrDesc { get; set; }
        public string descrPro { get; set; }
        public string codProdPrincipal { get; set; }
        public int itempreventa { get; set; }
    }

    public class CENConceptos
    {
        public int correlativo { get; set; }
        public string descripcion { get; set; }
    }

    public class CENProductolista
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class CENCamposPreventa
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class CENMensajePreventa
    {
        public int codigo { get; set; }
        public string mensaje { get; set; }
    }
}
