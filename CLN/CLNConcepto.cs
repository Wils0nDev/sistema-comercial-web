using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNConcepto
    {
        public List<CENConcepto> ListarConceptos(int auxflag)
        {
            try
            {
                //Traer los datos de la web
                List<CENConcepto> salida = new List<CENConcepto>();
                CADCliente consulta = new CADCliente();

                //Enviar la clase a nuestra capa de acceso a datos
                salida = consulta.ListarConceptos(auxflag);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       //reutilizando webmetodo listar dias por tabla concepto para estadod de usuarios
        public List<CENConcepto> ListarDias(int flag)
        {
            CADConcepto dias = null;

            try
            {
                dias = new CADConcepto();
                return dias.ListarDias(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<CENConcepto> obtenerCorrelativos()
        {
            CADConcepto CADPrecio = new CADConcepto();
            try
            {
                return CADPrecio.ListarConceptos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string obtener_descripcion_concepto(int p_concepto, int p_correlativo)
        {
            CADConcepto cadConcepto = new CADConcepto();

            try
            {
                return cadConcepto.obtener_descripcion_concepto(p_concepto, p_correlativo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




    }
}