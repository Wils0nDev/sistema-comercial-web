using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class CADPerfil
    {
        public int actualizarPerfil(CENPerfil perfil)
        {
            //DESCRIPCION: Actualiza los datos de perfil
            SqlConnection sqlConection;
            SqlCommand cmd;
            SqlDataReader dr;
            CADConexion CadCx = new CADConexion();
            string respuesta = string.Empty;
            int codigo = 0;

            try
            {
                sqlConection = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_actualizar_perfil", sqlConection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_nombre", SqlDbType.NVarChar).Value = perfil.nombre;
                cmd.Parameters.Add("@p_apellidoPaterno", SqlDbType.NVarChar).Value = perfil.apellidoPaterno;
                cmd.Parameters.Add("@p_apellidoMaterno", SqlDbType.NVarChar).Value = perfil.apellidoMaterno;
                cmd.Parameters.Add("@p_telefono", SqlDbType.NVarChar).Value = perfil.telefono;
                cmd.Parameters.Add("@p_correo", SqlDbType.NVarChar).Value = perfil.correo;
                cmd.Parameters.Add("@p_password", SqlDbType.NVarChar).Value = perfil.password;
                cmd.Parameters.Add("@p_codPersona", SqlDbType.Int).Value = perfil.codPersona;
                cmd.Parameters.Add("@p_codUsuario", SqlDbType.Int).Value = perfil.codUsuario;

                sqlConection.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    codigo = Convert.ToInt32(dr["respuesta"].ToString());
                    respuesta = dr["mensaje"].ToString();

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigo;
        }

        public List<CENPerfil> DatosPerfil(int codUsuario, int codPersona)
        {
            List<CENPerfil> datosPerfil = new List<CENPerfil>();
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcoman;
            CADConexion cnx = new CADConexion();
            SqlDataReader dr;
            CENPerfil objPerfil;
            try
            {
                sqlcon = new SqlConnection(cnx.CxSQL());
                sqlcoman = new SqlCommand("pa_buscar_datos_perfil", sqlcon);
                sqlcoman.CommandType = CommandType.StoredProcedure;
                sqlcoman.Parameters.Add("@p_codUsuario", SqlDbType.Int).Value = codUsuario;
                sqlcoman.Parameters.Add("@p_codPersona", SqlDbType.Int).Value = codPersona;
                sqlcon.Open();
                dr = sqlcoman.ExecuteReader();

                while (dr.Read())
                {
                    //Crear objeto usuario
                    objPerfil = new CENPerfil();
                    objPerfil.usuario = dr["usuario"].ToString();
                    objPerfil.nombre = dr["nombres"].ToString();
                    objPerfil.apellidoPaterno = dr["apellidoPaterno"].ToString();
                    objPerfil.apellidoMaterno = dr["apellidoMaterno"].ToString();
                    objPerfil.correo = dr["correo"].ToString();
                    objPerfil.telefono = dr["telefono"].ToString();
                    objPerfil.password = dr["password"].ToString();

                    datosPerfil.Add(objPerfil);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datosPerfil;
        }
    }
}
