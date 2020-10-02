using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;
namespace CAD
{
    public class CADTipoMovimiento
    {
        //DESCRIPCION: PATRON SINGLETON PARA CREAR LA INSTANCIA

        public List<CENTipoMovimiento> ListarTiposMovimientosCaja(int flag)
        {
            List<CENTipoMovimiento> listaTM = new List<CENTipoMovimiento>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENTipoMovimiento objTipoMov = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_tipos_mov_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", flag);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objTipoMov = new CENTipoMovimiento();
                    objTipoMov.ntraTipoMovimiento = Convert.ToInt32(dr["ntraTipoMovimiento"]);
                    objTipoMov.descripcion = dr["descripcion"].ToString();
                    objTipoMov.codTipoRegistro = Convert.ToInt32(dr["codTipoRegistro"]);
                    objTipoMov.tipoRegistro = dr["tipoRegistro"].ToString();
                    objTipoMov.marcaBaja = Convert.ToInt32(dr["marcaBaja"]);
                    listaTM.Add(objTipoMov);

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

            return listaTM;

        }



       public int AltaBajaTipoMovimientoCaja(CENTipoMovimiento objtTipoMovAD, int flag)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_alta_baja_tipo_mov_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ntraTipoMovimiento", objtTipoMovAD.ntraTipoMovimiento);
                cmd.Parameters.AddWithValue("@flag", flag);
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

        public int RegistrarTipoMovimientoCaja(CENTipoMovimiento objtTipoMovAD)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_tipo_mov_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", objtTipoMovAD.descripcion);
                cmd.Parameters.AddWithValue("@tipoRegistro", objtTipoMovAD.codTipoRegistro);
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



        public int ActualizarTipoMovimientoCaja(CENTipoMovimiento objtTipoMovAD)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_actualizar_tipo_mov_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", objtTipoMovAD.descripcion);
                cmd.Parameters.AddWithValue("@tipoRegistro", objtTipoMovAD.codTipoRegistro);
                cmd.Parameters.AddWithValue("@ntraTipoMovimiento", objtTipoMovAD.ntraTipoMovimiento);
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
