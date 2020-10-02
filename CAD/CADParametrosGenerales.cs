using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADParametrosGenerales
    {
        public CENParametrosGenerales ListarParametros (int flag, int codSucursal)
        {
           
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENParametrosGenerales ObjPA = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_obtener_parametros_x_flag_sucursal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_flag", SqlDbType.Int).Value = flag;
                cmd.Parameters.Add("p_codSucursal", SqlDbType.Int).Value = codSucursal;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ObjPA = new CENParametrosGenerales();
                    ObjPA.tipoCambio = Convert.ToDecimal(dr["tipoCambio"]);
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

            return ObjPA;

        }
    }
}
