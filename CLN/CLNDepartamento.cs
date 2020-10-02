using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNDepartamento
    {
        public List<CENDepartamento> ListarDepartamentos(int auxflag)
        {
            try
            {
                List<CENDepartamento> salida = new List<CENDepartamento>();
                CADCliente consulta = new CADCliente();

                salida = consulta.ListarDepartamentos(auxflag);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
