using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNRutasAsignadasView
    {
       

        public List<CENRutasAsignadasView> ListarRutasAsignadasPorVendedor(int codUsuario)
        {
            CADRutasAsignadasView objRutasView = null;
            try
            {
                objRutasView = new CADRutasAsignadasView();

                return objRutasView.ListarRutasAsignadasPorVendedor(codUsuario);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }

   

}
