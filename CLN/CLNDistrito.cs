using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNDistrito
    {
        public List<CENDistrito> ListarDistritos(int auxFlag)
        {
            try
            {
                List<CENDistrito> salida = new List<CENDistrito>();
                CADCliente consulta = new CADCliente();

                salida = consulta.ListarDistritos(auxFlag);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<CENDistrito> ListarDistritosRegistro(string codDepartamento, string codProvincia, string codDistrito)
        {
            try
            {
                List<CENDistrito> salida = new List<CENDistrito>();
                CADCliente consulta = new CADCliente();

                salida = consulta.ListarDistritosRegistro(codDepartamento, codProvincia, codDistrito);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
