using CAD;
using CEN;
using System;
using System.Collections.Generic;

namespace CLN
{
    public class CLNTipoMovimiento
    {

        public List<CENTipoMovimiento> ListarTiposMovimientosCaja(int flag)
        {
            CADTipoMovimiento objTiposMov = null;
            try
            {
                objTiposMov = new CADTipoMovimiento();

                return objTiposMov.ListarTiposMovimientosCaja(flag);


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




       public int AltaBajaTipoMovimientoCaja(CENTipoMovimiento objtTipoMovAD, int flag)
        {

            CADTipoMovimiento objTiposMov = null;
            try
            {
                objTiposMov = new CADTipoMovimiento();
                return objTiposMov.AltaBajaTipoMovimientoCaja(objtTipoMovAD, flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int RegistrarTipoMovimientoCaja(CENTipoMovimiento objtTipoMovAD)
        {
            CADTipoMovimiento objTiposMov = null;

            try
            {
                objTiposMov = new CADTipoMovimiento();
                return objTiposMov.RegistrarTipoMovimientoCaja(objtTipoMovAD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ActualizarTipoMovimientoCaja(CENTipoMovimiento objtTipoMovAD)
        {
            CADTipoMovimiento objTiposMov = null;

            try
            {
                objTiposMov = new CADTipoMovimiento();
                return objTiposMov.ActualizarTipoMovimientoCaja(objtTipoMovAD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
