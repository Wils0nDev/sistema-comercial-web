using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENPromociones
    {
        public string codProducto { get; set; }
        public int estado { get; set; }
        public string desEstado { get; set; }
        public int codCliente { get; set; }
        public int codVendedor { get; set; }
        public int codTipoVenta { get; set; }
        public int codProveedor { get; set; }
        public string codfechaI { get; set; }
        public string codfechaF { get; set; }


        public CENPromociones()
        {

        }

        public CENPromociones(string codfechaI, string codfechaF, int codProveedor, int codTipoVenta, string codProducto, int codVendedor, int codCliente, int estado)
        {
            this.codfechaI = codfechaI;
            this.codfechaF = codfechaF;
            this.codProveedor = codProveedor;
            this.codTipoVenta = codTipoVenta;
            this.codProducto = codProducto;
            this.codVendedor = codVendedor;
            this.codCliente = codCliente;
            this.estado = estado;
        }

    }


    public class CENPromocionesLista
    {
        public int codPromocion { get; set; }
        public string codProducto { get; set; }
        public string producto { get; set; }
        public string cliente { get; set; }
        public string vendedor { get; set; }
        public string estado { get; set; }
        public int codProveedor { get; set; }
        public string proveedor { get; set; }
        public string codfechaI { get; set; }
        public string codfechaF { get; set; }
        public string promocion { get; set; }
        public string codhoraI { get; set; }
        public string codhoraF { get; set; }
        public int codEstado { get; set; }
        public string cantidadProd { get; set; }
        public int codUnidadBase { get; set; }
        public string desUnidadBase { get; set; }
        public string codProdProm { get; set; }
        public string desProdProm { get; set; }
        public int cantidadProdPromo { get; set; }
        public int codUnidadBaseProdProm { get; set; }
        public string desUnidadBaseProdProm { get; set; }
        public float costoProdProm { get; set; }
        public int tipoProm { get; set; }
        public string detTipoProm { get; set; }
        public int codVendAplica { get; set; }
        public string desVendAplica { get; set; }
        public int codClienteAplica { get; set; }
        public string desClienetAplica { get; set; }
        public int vecesUsarProm { get; set; }
        public int vecesUsarPromXvend { get; set; }
        public int vecesUsarPromXcliente { get; set; }

        public CENPromocionesLista()
        {

        }
    }


    public class CENDetallePromocion
    {
        public int item { get; set; }
        public string codProductoProm { get; set; }
        public string descripcionProd { get; set; }
        public int cantidad { get; set; }
        public string presentacion { get; set; }
        public string precio { get; set; }
    }


    public class CENPromocionesInsert
    {
        public string nomPromo { get; set; }
        public string fechaI { get; set; }
        public string fechaF { get; set; }
        public string horaI { get; set; }
        public string horaF { get; set; }
        public int activoInactivo { get; set; }
        public string decPrdPrin { get; set; }
        public string codProdPrin { get; set; }
        public string desCantdadSoles { get; set; }
        public string monto { get; set; }
        public string codCantdadSoles { get; set; }
        public string desVendedorAplica { get; set; }
        public string codVendedorAplica { get; set; }
        public string desClienteAplica { get; set; }
        public string codClienteAplica { get; set; }
        public string vecesUsarProm { get; set; }
        public string vecesUsarPromXvendedor { get; set; }
        public string vecesUsarPromXcliente { get; set; }
        public string desContadoCredito { get; set; }
        public string codContadoCredito { get; set; }

    }




    public class CEN_Detalle_Flag_Promocion
    {
        public string descPrdoReg { get; set; }
        public int cantProductoReg { get; set; }
        public string costoProdReg { get; set; }
        public string codProductoReg { get; set; }
        public string idUnidBaseProdReg { get; set; }

    }




}
