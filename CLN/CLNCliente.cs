using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNCliente
    {
        public List<CENCliente> ListarClientes(int auxtipoDocumento, string auxNumDocumento, string auxNombres)
        {
            try
            {
                //Traer los datos de la web
                List<CENCliente> salida = new List<CENCliente>();
                CADCliente consulta = new CADCliente();

                //Enviar la clase a nuestra capa de acceso a datos
                salida = consulta.ListarClientes(auxtipoDocumento, auxNumDocumento, auxNombres);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarCliente(int auxCodPersona)
        {
            try
            {
                CADCliente consulta = new CADCliente();
                consulta.eliminarCliente(auxCodPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificarCliente(CENCliente data)
        {
            try
            {
                CADCliente consulta = new CADCliente();
                consulta.modificarCliente(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int registrarCliente(CENCliente data)
        {
            try
            {
                int codPersona;

                CADCliente consulta = new CADCliente();
                codPersona = consulta.registrarCliente(data);
                return codPersona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Byte buscarDniCliente(int dni)
        {
            try
            {
                Byte val;

                CADCliente consulta = new CADCliente();
                val = consulta.buscarDniCliente(dni);
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarRUCCliente(string ruc)
        {
            try
            {
                int val;

                CADCliente consulta = new CADCliente();
                val = consulta.buscarRUCCliente(ruc);
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}
