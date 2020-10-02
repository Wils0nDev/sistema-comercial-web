using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
    public class CLNSucursalVIEW
    {

        public List<CENSucursalVIEW> cargarSucursal(int flag)
        {
            CADSucursalVIEW objCAD = null;
            //List<CENSucursalVIEW> ListSucursal = null ;
            try
            {
                objCAD = new CADSucursalVIEW();
                return objCAD.cargarSucursal(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
