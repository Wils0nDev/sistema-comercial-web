using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
    public class CLNRutasAsignadas
    {
     


        public int InsertarRutasAsignadas(CENRutasAsignadas objtRutasAD)
        {
            CADRutasAsignadas objCLNRutasAsignadas = null;
            
            try
            {
                objCLNRutasAsignadas = new CADRutasAsignadas();
                return objCLNRutasAsignadas.InsertarRutasAsignadas(objtRutasAD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarRutasAsignadas(CENRutasAsignadas objtRutasAD, int codRutaAn)
        {
            CADRutasAsignadas objCLNRutasAsignadas = null;
            
            try
            {
                objCLNRutasAsignadas = new CADRutasAsignadas();
                return objCLNRutasAsignadas.ActualizarRutasAsignadas(objtRutasAD, codRutaAn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarRutasAsignadas(CENRutasAsignadas objtRutasAD)
        {

            CADRutasAsignadas objCLNRutasAsignadas = null;
            try
            {
                objCLNRutasAsignadas = new CADRutasAsignadas();
                return objCLNRutasAsignadas.EliminarRutasAsignadas(objtRutasAD);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return ok;
        }

        public int ActualizaOrdenRutasAsignadas(List<CENRutasAsignadas> arrayData)
        {
            CADRutasAsignadas objCLNRutasAsignadas = null;
            try
            {
                objCLNRutasAsignadas = new CADRutasAsignadas();
                return objCLNRutasAsignadas.ActualizaOrdenRutasAsignadas(arrayData);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
