        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
   public  class CLNPerfilVIEW
    {
          public List<CENPerfilVIEW> CargarPerfil(int flag)
        {
            CADPerfilVIEW objPerfil = null;

            try
            {

                objPerfil = new CADPerfilVIEW();
                return objPerfil.CargarPerfil(flag);
            
            }

            catch (Exception ex)
            {
                throw ex;
            }  

        }




    }
}
