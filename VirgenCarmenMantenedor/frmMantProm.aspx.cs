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
    public partial class frmMantProm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<CENPromociones> ListarEstadoPrmocion(int flag)
        {
            List<CENPromociones> listaCampos = null;
            CLNPromociones objCLNPromociones = null;
            try
            {
                objCLNPromociones = new CLNPromociones();
                listaCampos = objCLNPromociones.ListarEstadoPrmocion(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaCampos;
        }



        [WebMethod]
        public static List<CENPromocionesLista> ListarPromociones(string codfechaI, string codfechaF, int codProveedor, int codTipoVenta, string codProducto, int codVendedor, int codCliente, int codEstado)
        {
            List<CENPromocionesLista> lista_promociones = null;
            CENPromociones objCENPromocionesDatos = null;
            CLNPromociones objCLNPromociones = null;

            try
            {
                objCLNPromociones = new CLNPromociones();
                objCENPromocionesDatos = new CENPromociones(codfechaI, codfechaF, codProveedor, codTipoVenta, codProducto, codVendedor, codCliente, codEstado);
                lista_promociones = objCLNPromociones.ListarPromociones(objCENPromocionesDatos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista_promociones;
        }


        [WebMethod]
        public static int ElimiarPromocion(int codPromocion)
        {
            CLNPromociones objCLNPromocion = null;

            CENPromocionesLista objtPromociones = new CENPromocionesLista()
            {
                codPromocion = codPromocion,
            };
            try
            {
                objCLNPromocion = new CLNPromociones();
                int ok = objCLNPromocion.ElimiarPromocion(objtPromociones);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        public static List<CENDetallePromocion> ListarDetalle(int codPromocion)
        {
            List<CENDetallePromocion> listaDetalle = null;
            CLNPromociones objCLNPreventa = null;

            try
            {
                objCLNPreventa = new CLNPromociones();
                listaDetalle = objCLNPreventa.ListarDetalle(codPromocion);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listaDetalle;
        }




        [WebMethod]
        public static List<string> InsertarPromocion(string promocion, string fechaInicial, string fechaFinal, string horaInicio, string horaFin, int activarProm,
                string descProductoPrin, string codProductoPrin, string cantidadPrincipal, string descUnidadBase, string unidadBasePrincipal, string desvendedorAplica, string vendedorAplica,
                string desclienteAplica, string codclienteAplica, string cantMaxProm, string cantMaxVend, string cantMaxCliente, string contadoCredito, string codContadoCredito)
        {

            CLNPromociones objCLNProduct = null;
            CENPromocionesInsert objProduc = new CENPromocionesInsert()
            {
                nomPromo = Convert.ToString(promocion),
                fechaI = Convert.ToString(fechaInicial),
                fechaF = Convert.ToString(fechaFinal),
                horaI = Convert.ToString(horaInicio),
                horaF = Convert.ToString(horaFin),
                activoInactivo = Convert.ToInt32(activarProm),
                decPrdPrin = Convert.ToString(descProductoPrin),
                codProdPrin = Convert.ToString(codProductoPrin),
                monto = Convert.ToString(cantidadPrincipal),
                desCantdadSoles = Convert.ToString(descUnidadBase),
                codCantdadSoles = Convert.ToString(unidadBasePrincipal),
                desVendedorAplica = Convert.ToString(desvendedorAplica),
                codVendedorAplica = Convert.ToString(vendedorAplica),
                desClienteAplica = Convert.ToString(desclienteAplica),
                codClienteAplica = Convert.ToString(codclienteAplica),
                vecesUsarProm = Convert.ToString(cantMaxProm),
                vecesUsarPromXvendedor = Convert.ToString(cantMaxVend),
                vecesUsarPromXcliente = Convert.ToString(cantMaxCliente),
                desContadoCredito = Convert.ToString(contadoCredito),
                codContadoCredito = Convert.ToString(codContadoCredito)


            };
            try
            {
                objCLNProduct = new CLNPromociones();
                List<string> ok = objCLNProduct.InsertarPromociones(objProduc);
                return ok;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [WebMethod]
        public static int InsertDetallePromocion(string descProductoReg, int cantProductoRegalar, string costoProdRegalar, string codProductoRegalar, string idUnidadBaseProdReg)
        {
            CLNPromociones objCLNProduc = null;
            CEN_Detalle_Flag_Promocion objCENdetalle = new CEN_Detalle_Flag_Promocion()
            {
                descPrdoReg = Convert.ToString(descProductoReg),
                cantProductoReg = Convert.ToInt32(cantProductoRegalar),
                costoProdReg = Convert.ToString(costoProdRegalar),
                codProductoReg = Convert.ToString(codProductoRegalar),
                idUnidBaseProdReg = Convert.ToString(idUnidadBaseProdReg)

            };
            try
            {
                objCLNProduc = new CLNPromociones();
                int ok = objCLNProduc.InsertarDetPrmocion(objCENdetalle);
                return ok;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



    }
}