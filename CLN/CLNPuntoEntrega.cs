using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNPuntoEntrega
    {
        public List<CENPuntoEntrega> ListarPuntosEntrega(Int32 auxCodPersona)
        {
            try
            {
                List<CENPuntoEntrega> salida = new List<CENPuntoEntrega>();
                CADCliente consulta = new CADCliente();

                salida = consulta.ListarPuntosEntrega(auxCodPersona);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void registrarEliminarPuntoEntrega(int tPro, CENPuntoEntrega data)
        {
            try
            {
                CADCliente consulta = new CADCliente();
                consulta.registrarEliminarPuntoEntrega(tPro, data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
