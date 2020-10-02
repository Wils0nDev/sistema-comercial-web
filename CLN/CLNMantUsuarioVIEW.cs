using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
    public class CLNMantUsuarioVIEW
    {
      public List<CENMantUsuarioVIEW> ListarUsuario(
           int flagFiltro , int codEstado, int codUsuario )
        {
            CADMantUsuarioVIEW objUsuario = null;

            try
            {

                objUsuario = new CADMantUsuarioVIEW();
                return objUsuario.ListarUsuario(flagFiltro ,  codEstado, codUsuario);
            
            }

            catch (Exception ex)
            {
                throw ex;
            }  

        }

       /*
      public List <CENAutoUsuarioVIEW> buscarUsuario(string cadena)
      {    
           CADMantUsuarioVIEW objCAD = null;
          
            try
            {
                objCAD = new CADMantUsuarioVIEW();
                return objCAD.buscarUsuario(cadena);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
      }

    */
    }
}
