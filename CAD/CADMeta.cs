using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class CADMeta
    {
        public List<CENMetaLista> ListaMetaPorFiltro(CENMeta datos)
        {

            List<CENMetaLista> list_Meta = new List<CENMetaLista>();
            CENMetaLista objMetaLista = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_filtro_metas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codProveedor", SqlDbType.Int).Value = datos.codProveedor;
                cmd.Parameters.Add("@codEstado", SqlDbType.Int).Value = datos.codEstado;
                if (datos.fechaInicio == "")
                {
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value = datos.fechaInicio;
                }
                if (datos.fechaFin == "")
                {
                    cmd.Parameters.Add("@fechaFin", SqlDbType.Date).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@fechaFin", SqlDbType.Date).Value = datos.fechaFin;
                }
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objMetaLista = new CENMetaLista();
                    objMetaLista.codMeta = Convert.ToInt32(dr["codMeta"]);
                    objMetaLista.descripcion = Convert.ToString(dr["descripcion"].ToString());
                    objMetaLista.fechaInicio = dr["fechaInicio"].ToString();
                    objMetaLista.fechaFin = dr["fechaFin"].ToString();
                    list_Meta.Add(objMetaLista);
                }
            }
            catch (Exception ex)
            {

                ex.StackTrace.ToString();
            }
            finally
            {
                con.Close();
            }
            return list_Meta;

        }

        public int InsertarMeta(CENMeta objMeta)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_meta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = objMeta.descripcion;
                cmd.Parameters.Add("@p_fechInicio", SqlDbType.Date).Value = objMeta.fechaInicio;
                cmd.Parameters.Add("@p_fechFin", SqlDbType.Date).Value = objMeta.fechaFin;
                cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar).Value = objMeta.usuario;
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
