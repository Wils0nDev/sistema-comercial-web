using CAD;
using CEN;
using System;
using System.Collections.Generic;

namespace CLN
{
    public class CLNRutas
    {
       
        public List<CENRutas> ListarRutas(int flag)
        {
            CADRutas objRutas = null;
            try
            {
                objRutas = new CADRutas();

                return objRutas.ListarRutas(flag);


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




        public int EliminarRutas(CENRutas objtRutasAD)
        {

            CADRutas objCLNRutas = null;
            try
            {
                objCLNRutas = new CADRutas();
                return objCLNRutas.EliminarRutas(objtRutasAD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int InsertarRutas(CENRutas objtRutasAD)
        {
            CADRutas objCLNRutas = null;

            try
            {
                objCLNRutas = new CADRutas();
                return objCLNRutas.InsertarRutas(objtRutasAD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ActualizarRutas(CENRutas objtRutasAD, int codRuta)
        {
            CADRutas objCLNRutas = null;

            try
            {
                objCLNRutas = new CADRutas();
                return objCLNRutas.ActualizarRutas(objtRutasAD, codRuta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
