using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;
namespace CAD
{
    public class CADRutas
    {
        //DESCRIPCION: PATRON SINGLETON PARA CREAR LA INSTANCIA

        public List<CENRutas> ListarRutas(int flag)
        {
            List<CENRutas> listaRU = new List<CENRutas>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENRutas objRutas = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_datos_select_x_flag", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objRutas = new CENRutas();
                    objRutas.ntraRutas = Convert.ToInt32(dr["ntraRutas"]);
                    objRutas.descripcion = dr["descripcion"].ToString();
                    objRutas.pseudonimo = dr["pseudonimo"].ToString();
                    listaRU.Add(objRutas);

                }



            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }

            finally
            {
                con.Close();
            }

            return listaRU;

        }



        public int EliminarRutas(CENRutas objtRutasAD)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_eliminar_rutas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codRuta", objtRutasAD.ntraRutas);
                cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                //response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public int InsertarRutas(CENRutas objtRutasAD)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_insertar_rutas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", objtRutasAD.descripcion);
                cmd.Parameters.AddWithValue("@pseudonimo", objtRutasAD.pseudonimo);
                cmd.Parameters.AddWithValue("@codSucursal", objtRutasAD.codSucursal);
                //cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                //response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }



        public int ActualizarRutas(CENRutas objtRutasAD, int codRuta)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_actualizar_rutas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", objtRutasAD.descripcion);
                cmd.Parameters.AddWithValue("@pseudonimo", objtRutasAD.pseudonimo);
                cmd.Parameters.AddWithValue("@ntraRutas", objtRutasAD.ntraRutas);
                //cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                //response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }




    }
}
