using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENConceptoDescuento
    {
        public int correlativo { get; set; }
        public string descripcion { get; set; }
    }

    public class CENMensajeDescuento
    {
        public int flag { get; set; }
        public string mensaje { get; set; }
        public int ntraDescuento { get; set; }

    }

    public class CENRegistrarDescuento
    {
        public int proceso { get; set; }
        public string descripcion { get; set; }
        public string fechaVigenciaI { get; set; }
        public string fechaVigenciaF { get; set; }
        public string horaI { get; set; }
        public string horaF { get; set; }
        public int flagestado { get; set; }
        public int codTipo_venta { get; set; }
        public string codProducto { get; set; }
        public int codCantidad { get; set; }
        public int tipoCant { get; set; }
        public int codUnidadBase { get; set; }
        public decimal codMonto { get; set; }
        public int codTipoMonto { get; set; }
        public int codVendedorReg { get; set; }
        public int codCliente_reg { get; set; }
        public int cod_veces_dec { get; set; }
        public int cod_veces_vend { get; set; }
        public int cod_veces_clie { get; set; }
        public int ntraDescuento { get; set; }
    }

    public class CENListarDescuento
    {
        public int ntraDescuento { get; set; }  //numero id del descuento
        public string descripcion { get; set; } //descripcion del descuento
        public string codProd { get; set; } //codigo del producto
        public string desProd { get; set; } //descripcion del producto
        public int codUnidad { get; set; }  //codigo de unidad base
        public string desUnidad { get; set; }   //descripcion de la unidad base
        public string fechaInicial { get; set; }    //fecha de inicio
        public string fechaFin { get; set; }    //fecha de fin
        public string horaInicial { get; set; }     //hora inicio
        public string horaFin { get; set; }     //hora fin
        public int codEstado { get; set; }  //codigo estado del descuento
        public string desEstado { get; set; } //estado del descuento
        public decimal cant { get; set; }   //cantidad
        public int tipoCant { get; set; }   //tipo de cantidad
        public decimal descuento { get; set; }  //monto del descuento
        public int tipodesc { get; set; }   //tipo de descuento
        public int codVen { get; set; }     //codigo del vendedor
        public string vendedor { get; set; }    //descripcion del vendedor
        public int codCli { get; set; }     //codigo del cliente
        public string cliente { get; set; }     //descripcion del cliente
        public int vecesDes { get; set; }   //numero de veces del descuento
        public int vecesVen { get; set; }   //numero de veces que el vendedor utilizara el descuento
        public int vecesCli { get; set; }   //numero de veces que el cliente utilizara el descuento



    }
}
