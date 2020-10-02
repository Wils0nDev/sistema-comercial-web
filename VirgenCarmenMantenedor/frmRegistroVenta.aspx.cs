using CAD;
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
    public partial class frmRegistroFacturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CENUsuario> ListarVendedores(int flag)
        {
            CLNUsuario uvendedor = null;
            List<CENUsuario> ListVE = null;
            try
            {
                uvendedor = new CLNUsuario();
                ListVE = uvendedor.ListarVendedores(flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ListVE;
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
        public static List<CENPreventaFiltroPA> ListarPreventa(string codPreventa, string codCliente, string codVendedor, string codFechaI, string codFechaF)
        {
            CLN_Venta clnVenta = new CLN_Venta();
            CLNConsultas consulta = new CLNConsultas();
            CENPreventaFiltro data = new CENPreventaFiltro();
            List<CENPreventaFiltroPA> lista = new List<CENPreventaFiltroPA>();

            try
            {

                if (consulta.ValidarNumero(codCliente))
                {
                    data.codCliente = Int32.Parse(codCliente);
                }
                else
                {
                    data.codCliente = CENConstante.g_const_0;
                }

                if (consulta.ValidarNumero(codVendedor))
                {
                    data.codUsuario = Int32.Parse(codVendedor);
                }
                else
                {
                    data.codUsuario = CENConstante.g_const_0;
                }

                if (consulta.ValidarNumero(codPreventa))
                {
                    data.ntraPreventa = Int32.Parse(codPreventa);
                }
                else
                {
                    data.ntraPreventa = CENConstante.g_const_0;
                }

                if (codFechaI != CENConstante.g_const_vacio)
                {

                    data.codfechaRegistroIDate = consulta.ConvertFechaStringToDate(codFechaI);
                }
                else
                {
                    data.codfechaRegistroIDate = DateTime.Today.AddDays(-30);
                }

                if (codFechaF != CENConstante.g_const_vacio)
                {
                    data.codfechaRegistroFDate = consulta.ConvertFechaStringToDate(codFechaF);
                }
                else
                {
                    data.codfechaRegistroFDate = DateTime.Now;
                }
                lista = clnVenta.listarPreventaFiltro(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }


        [WebMethod]
        public static List<CENDetallePreventa> ListarDetalleProductos(int npre)
        {
            List<CENDetallePreventa> listaDetalle = null;
            CLNPreventa objCLNPreventa = null;

            try
            {
                objCLNPreventa = new CLNPreventa();
                listaDetalle = objCLNPreventa.ListarDetalle(npre);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaDetalle;

        }

        [WebMethod]
        public static CENRespVenta RegistrarVenta(int codPreventa, int codCliente, int codVendedor, string fechPag, int tipoVenta, int tipoMoneda,
                                        double recargo, double IGV, double total, int sucursal, int tipoDocumentoVenta, int codPuntoEntrega)
        {
            CLN_Venta clnVenta = new CLN_Venta();
            CLNConcepto clnConcepto = new CLNConcepto();
            CLNConsultas consulta = new CLNConsultas();
            CENRespVenta respuesta = new CENRespVenta();
            try
            {
                respuesta = clnVenta.RegistrarVenta(codPreventa, codCliente, codVendedor, fechPag, tipoVenta, tipoMoneda,
                    recargo, IGV, total, sucursal, tipoDocumentoVenta, codPuntoEntrega);
            }
            catch (Exception ex)
            {
                //throw ex;
                respuesta.flag = -1;
                respuesta.venta = 0;
                respuesta.msje = clnConcepto.obtener_descripcion_concepto(CENConstante.g_const_100, CENConstante.g_const_1046);
            }

            return respuesta;
        }


    }
}