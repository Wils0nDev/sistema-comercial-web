using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNProvincia
    {
        public List<CENProvincia> ListarProvincias(int auxflag)
        {
            try
            {
                List<CENProvincia> salida = new List<CENProvincia>();
                CADCliente consulta = new CADCliente();

                salida = consulta.ListarProvincias(auxflag);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<CENProvincia> ListarProvinciasRegistro(string codDepartamento, string codProvincia)
        {
            try
            {
                List<CENProvincia> salida = new List<CENProvincia>();
                CADCliente consulta = new CADCliente();

                salida = consulta.ListarProvinciasRegistro(codDepartamento, codProvincia);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
