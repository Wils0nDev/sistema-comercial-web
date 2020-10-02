using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNRutasBitacora
    {


        public List<CENRutasBitacora> ListarRutasBitacora(int codVendedor, int fechaActual, Int16 flagFiltro, DateTime fechaIncio, DateTime fechaFin)
        {
            CADRutasBitacoras objRutasBitacora = null;
            try
            {
                objRutasBitacora = new CADRutasBitacoras();

                return objRutasBitacora.ListarRutasBitacora(codVendedor, fechaActual, flagFiltro, fechaIncio, fechaFin);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
