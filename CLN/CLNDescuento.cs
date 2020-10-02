using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNDescuento
    {
        public List<CENConceptoDescuento> ListarCoceptos(int flag)
        {
            CADDescuento objCADDescuento = null;

            try
            {
                objCADDescuento = new CADDescuento();
                return objCADDescuento.ListarCoceptos(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENConceptoDescuento> ListarEstado(int flag)
        {
            CADDescuento objCADDescuento = null;

            try
            {
                objCADDescuento = new CADDescuento();
                return objCADDescuento.ListarEstado(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENProductolista> ListarProductosTipo(string cadena)
        {
            CADDescuento objCADDescuento = null;

            try
            {
                objCADDescuento = new CADDescuento();
                return objCADDescuento.ListarProductosTipo(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CENConceptoDescuento obtenerUnidadBaseProducto(string codProducto)
        {
            CADDescuento objCADDescuento = null;

            try
            {
                objCADDescuento = new CADDescuento();
                return objCADDescuento.obtenerUnidadBaseProducto(codProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENListarDescuento> ListarDescuento(string codProd, int codVendedor, int codCliente, int codEstado, string codFechaI, string codFechaF)
        {
            CADDescuento objCADDescuento = null;
            try
            {
                objCADDescuento = new CADDescuento();
                return objCADDescuento.ListarDescuento(codProd, codVendedor, codCliente, codEstado, codFechaI, codFechaF);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CENMensajeDescuento registrarDescuento(CENRegistrarDescuento datos)
        {
            CADDescuento objCADDescuento = null;

            try
            {
                objCADDescuento = new CADDescuento();
                return objCADDescuento.registrarDescuento(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CENMensajeDescuento cambiarEstado(int idDesc, int estado)
        {
            CADDescuento objCADDescuento = null;

            try
            {
                objCADDescuento = new CADDescuento();
                return objCADDescuento.cambiarEstado(idDesc, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<CENProductolista> ListarProductosTipo2(string cadena)
        {
            CADDescuento objCADDescuento = null;

            try
            {
                objCADDescuento = new CADDescuento();
                return objCADDescuento.ListarProductosTipo2(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
