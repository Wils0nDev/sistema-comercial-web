using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;


namespace CAD
{
   public class CADRutasAsignadasView
    {
   

        //DESCRIPCION: METODO QUE ME TRAE LA LISTA DE LA VISTA v_listar_rutas_asignadas_x_vendedor
        public List<CENRutasAsignadasView> ListarRutasAsignadasPorVendedor(int codUsuario)
        {

            List<CENRutasAsignadasView> ListaRA = new List<CENRutasAsignadasView>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENRutasAsignadasView objRutasAsignadas = null;
            
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_rutas_asignadas_x_vendedor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codUsuario", SqlDbType.Int).Value = codUsuario;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto Rutas
                    objRutasAsignadas = new CENRutasAsignadasView();
                    objRutasAsignadas.ntraRutas = Convert.ToInt32(dr["ntraRutas"]);
                    objRutasAsignadas.ntraUsuario = Convert.ToInt32(dr["ntraUsuario"].ToString());
                    objRutasAsignadas.correlativo = Convert.ToInt32(dr["correlativo"].ToString());
                    objRutasAsignadas.ORDEN = Convert.ToInt32(dr["ORDEN"].ToString());
                    objRutasAsignadas.ABREVIATURA = dr["ABREVIATURA"].ToString();
                    objRutasAsignadas.VENDEDOR = dr["VENDEDOR"].ToString();
                    objRutasAsignadas.RUTA = dr["RUTA"].ToString();
                    objRutasAsignadas.DIA = dr["DIA"].ToString();
                    objRutasAsignadas.estado = Convert.ToInt16(dr["estado"]);
                    ListaRA.Add(objRutasAsignadas);

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
            return ListaRA;
        }
    }
}
