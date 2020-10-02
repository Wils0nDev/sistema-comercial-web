using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
    public class CLNCronograma
    {

        public List<CENCronograma> ListarCronograma(int codVenta, int flag)
        {
            CADCronograma objCADCro = null;
            try
            {
                objCADCro = new CADCronograma();
                return objCADCro.ListarCronograma(codVenta, flag);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
