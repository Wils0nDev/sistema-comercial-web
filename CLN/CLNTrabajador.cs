using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNTrabajador
    {
        public Byte buscarDniTrabajador(int dni)
        {
            try
            {
                Byte val;

                CADTrabajador consulta = new CADTrabajador();
                val = consulta.buscarDniCliente(dni);
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int registrarTrabajador(CENTrabajador data)
        {
            try
            {
                int codPersona;

                CADTrabajador consulta = new CADTrabajador();
                codPersona = consulta.registrarTrabajador(data);
                return codPersona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
