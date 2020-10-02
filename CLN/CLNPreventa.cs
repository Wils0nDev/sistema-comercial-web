using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNPreventa
    {
        public CENMensajePreventa AnularPreventa(int npre)
        {
            CADPreventa objCADPreventa = null;
            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.AnularPreventa(npre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENDetallePreventa> ListarDetalle(int npre)
        {
            CADPreventa objCADPreventa = null;
            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.ListarDetalle(npre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENPreventaLista> ListarPreventa(CENPreventaDatos datos)
        {
            CADPreventa objCADPreventa = null;
            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.ListarPreventa(datos);
            }
            catch(Exception ex)
            {
                throw ex;
            } 
        }
        
        public List<CENCamposPreventa> ListarCampos(int flag)
        {
            CADPreventa objCADPreventa = null;
            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.ListarCampos(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENPreventaProducto> ListarProductos_Sku(string cadena)
        {
            CADPreventa objCADPreventa = null;
            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.listarProductos(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENConceptos> ListarConcepto(int flag)
        {
            CADPreventa objCADPreventa = null;
            
            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.ListarConcepto(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CENMensajePreventa validarFechaRegistro(string fechari, string fecharf)
        {
            CADPreventa objCADPreventa = null;
            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.validarFechaRegistro(fechari, fecharf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENPreventaCliente> buscarCliente(string cadena)
        {
            CADPreventa objCADPreventa = null;
            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.buscarCliente(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CENProductolista> ListarProductosCombo(int flag)
        {
            CADPreventa objCADPreventa = null;

            try
            {
                objCADPreventa = new CADPreventa();
                return objCADPreventa.ListarProductosCombo(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
