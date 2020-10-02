using CEN;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class CADProductoView
    {
        public int InsertarProductoView(CEN_Detalle_Presentacion_Product objProd)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_detProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_codProduc", objProd.codProductos);
                cmd.Parameters.AddWithValue("@p_codPresentacion", objProd.codDetPresents);
                cmd.Parameters.AddWithValue("@p_cantDetall", objProd.cantUniBases);
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

        public int ActualizarDetProduct(CEN_Detalle_Presentacion_Product objDetProduct, string CodProduct, int codPresentacion)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_actualizar_detProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_cantDetall", objDetProduct.cantUniBases);
                cmd.Parameters.AddWithValue("@p_codProduc", CodProduct);
                cmd.Parameters.AddWithValue("@p_codPresentacion", codPresentacion);
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

    }
}
