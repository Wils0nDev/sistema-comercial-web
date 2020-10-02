using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;


namespace CLN
{
    public class CLNPagoTransaccion
    {

         public int InsertarTransaccionPago(int flag, CENTransaccionPago objTP, CENPagoEfectivo objPE, CENPagoTransferencia objePT)
        {

            CADTransaccionPago objCADTP = null;
            try
            {
                objCADTP = new CADTransaccionPago();
                return objCADTP.InsertarTransaccionPago(flag,  objTP,  objPE, objePT);

            } catch(Exception ex)
            {
                throw ex;
            }
        }   
    }
}
