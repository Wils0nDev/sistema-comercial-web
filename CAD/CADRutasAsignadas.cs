using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADRutasAsignadas
    {
       
        public int InsertarRutasAsignadas(CENRutasAsignadas objtRutasAD)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_insertar_rutas_asignadas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codUsuario", objtRutasAD.codUsuario);
                cmd.Parameters.AddWithValue("@codRuta", objtRutasAD.codRuta);
                cmd.Parameters.AddWithValue("@codOrden", objtRutasAD.codOrden);
                cmd.Parameters.AddWithValue("@diaSemana", objtRutasAD.diaSemana);
                cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();              
                cmd.ExecuteNonQuery();
                response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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

        public int ActualizarRutasAsignadas(CENRutasAsignadas objtRutasAD, int codRutaAn)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_actualizar_rutas_asignadas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codUsuario", objtRutasAD.codUsuario);
                cmd.Parameters.AddWithValue("@codRuta", objtRutasAD.codRuta);
                cmd.Parameters.AddWithValue("@diaSemana", objtRutasAD.diaSemana);
                cmd.Parameters.AddWithValue("@codRutaAnterior", codRutaAn);
                cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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

        public int EliminarRutasAsignadas(CENRutasAsignadas objtRutasAD)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_eliminar_rutas_asignadas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codUsuario", objtRutasAD.codUsuario);
                cmd.Parameters.AddWithValue("@codRuta", objtRutasAD.codRuta);
                cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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

        public int ActualizaOrdenRutasAsignadas(List<CENRutasAsignadas> arrayData)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            foreach (CENRutasAsignadas valor in arrayData)
            {
                try
                {
                    /*int [] arrayDataOrden;
                    arrayDataOrden = arrayData.ToArray();
                    int codUsuario;*/
                    con = new SqlConnection(CadCx.CxSQL());
                    cmd = new SqlCommand("pa_ordenar_rutas_asignadas", con);
                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@codUsuario", valor.codUsuario);
                    cmd.Parameters.AddWithValue("@codRuta", valor.codRuta);
                    cmd.Parameters.AddWithValue("@codOrden", valor.codOrden);

                    cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return response;
        }

    }
}