using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;


namespace CLN
{
    public class CLNParametrosGenerales
    {
        public CENParametrosGenerales ListarParametros(int flag, int codSucursal)
        {
            try
            {
                //Traer los datos de la web
                CENParametrosGenerales objPA = new CENParametrosGenerales();
                CADParametrosGenerales cadPA = new CADParametrosGenerales();

                //Enviar la clase a nuestra capa de acceso a datos
                objPA = cadPA.ListarParametros(flag, codSucursal);
                return objPA;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
