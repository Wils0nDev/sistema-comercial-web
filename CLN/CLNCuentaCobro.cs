using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
    public class CLNCuentaCobro
    {
        public CENCuentaCobro BuscarCuentaPorCobrar(int codVenta, int flag)
        {
            CADCuentaCobro objCADCxC = null;
            try
            {
                objCADCxC = new CADCuentaCobro();
                return objCADCxC.BuscarCuentaPorCobrar(codVenta, flag);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
