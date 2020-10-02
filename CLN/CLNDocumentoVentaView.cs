using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNDocumentoVentaView
    {
        public List<CENDocumentoVentaView> ListarDocumentosVenta(
            Int16 flagFiltro, int fechaActual, int codEstado, int codCliente,
            int codVendedor, string fechaInicial, string fechaFinal, int codTipoDoc, int ntraVenta, string serie, int numdoc)
        {
            CADDocumentoVentaView objDocVenta = null;
            try
            {
                objDocVenta = new CADDocumentoVentaView();

                return objDocVenta.ListarDocumentosVenta(flagFiltro, fechaActual, codEstado, codCliente, codVendedor, fechaInicial, fechaFinal, codTipoDoc, ntraVenta, serie, numdoc);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
