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
    public class CADCorreo
    {
        public List<CENCorreo> buscarCredencialesCorreo(string usuario, int flag)
        {

            SqlConnection con = null;
            SqlCommand cmd;
            SqlDataReader dr;
            CADConexion CadCx = new CADConexion();
            CENCorreo objCorreo;
            List<CENCorreo> listDatos = new List<CENCorreo>();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_buscar_credenciales_usuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@p_password", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@p_intentos", SqlDbType.VarChar).Value = CENConstante.g_const_1;
                cmd.Parameters.Add("@p_flag ", SqlDbType.Int).Value = flag;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCorreo = new CENCorreo();
                    objCorreo.respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                    if (objCorreo.respuesta == CENConstante.g_const_505)
                    {
                        objCorreo.correoDestino = dr["correo"].ToString();
                        objCorreo.contraseña = dr["password"].ToString();
                    }
                    else
                    {
                        objCorreo.error = dr["nombres"].ToString();
                    }


                    listDatos.Add(objCorreo);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }



            return listDatos;
        }
    }
}
