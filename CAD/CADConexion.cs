using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CAD
{
    public class CADConexion
    {
        public String CxSQL()
        {
            //DESCRIPCION : CONEXION CON SQL SERVER
            try { 
            	return ConfigurationManager.ConnectionStrings[CENConstante.ConexionSQL].ConnectionString.ToString(); 
            }
            catch (Exception ex) { 
            	throw ex; 
            }
        }

        public void AbrirConexion(SqlConnection Connection)
        {
            //DESCRIPCION: INICIA CONEXION CON DB SQL
            try
            {
                if (Connection.State == ConnectionState.Closed) Connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion(SqlConnection Connection)
        {
            //DESCRIPCION: CIERRA CONEXION CON DB SQL
            try
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
