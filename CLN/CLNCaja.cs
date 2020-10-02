using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNCaja
    {
        public List<CENCaja> ListarCajas(
            int ntraCaja, int estadoCaja, int ntraUsuario, int ntraSucursal, 
            string fechaInicial, string fechaFinal)
        {
            CADCaja objCADCaja = null;
            try
            {
                objCADCaja = new CADCaja();

                return objCADCaja.ListarCajas(ntraCaja, estadoCaja, ntraUsuario, ntraSucursal, fechaInicial, fechaFinal);


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




        public CENCaja ListarTipos_Mov_Asig_Caja(CENCaja objCENCaja)
        {

            CADCaja objCADCaja = null;
            try
            {
                objCADCaja = new CADCaja();
                return objCADCaja.ListarTipos_Mov_Asig_Caja(objCENCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int RegistrarCaja(CENCaja objCENCaja)
        {
            CADCaja objCADCaja = null;

            try
            {
                objCADCaja = new CADCaja();
                return objCADCaja.RegistrarCaja(objCENCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ActualizarCaja(CENCaja objCENCaja)
        {
            CADCaja objCADCaja = null;

            try
            {
                objCADCaja = new CADCaja();
                return objCADCaja.ActualizarCaja(objCENCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENAperturaCaja> ListarCajasAperturadas(int ntraSucursal, int ntraCaja, int flag)
        {
            CADCaja objCADCaja = null;
            try
            {
                objCADCaja = new CADCaja();

                return objCADCaja.ListarCajasAperturadas(ntraSucursal, ntraCaja, flag);


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int RegistrarAperturaCaja(CENAperturaCaja objCENAperturaCaja)
        {
            CADCaja objCADCaja = null;

            try
            {
                objCADCaja = new CADCaja();
                return objCADCaja.RegistrarAperturaCaja(objCENAperturaCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ActualizarAperturaCaja(CENAperturaCaja objCENAperturaCaja)
        {
            CADCaja objCADCaja = null;

            try
            {
                objCADCaja = new CADCaja();
                return objCADCaja.ActualizarAperturaCaja(objCENAperturaCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENCierreCaja> ListarCajasCerradas(int ntraSucursal, int ntraCaja, int flag)
        {
            CADCaja objCADCaja = null;
            try
            {
                objCADCaja = new CADCaja();

                return objCADCaja.ListarCajasCerradas(ntraSucursal, ntraCaja, flag);


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<CENTransaccionCaja> ListarTransaccionesCajas(int ntraSucursal, int ntraCaja, string fechaTransaccion, int flag)
        {
            CADCaja objCADCaja = null;
            try
            {
                objCADCaja = new CADCaja();

                return objCADCaja.ListarTransaccionesCajas(ntraSucursal, ntraCaja, fechaTransaccion, flag);


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
