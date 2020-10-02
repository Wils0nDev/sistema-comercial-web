using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;



namespace CAD
{
    public class CADRutasBitacoras
    {
        //DESCRIPCION: METODO QUE ME TRAE LA LISTA DE LA VISTA v_listar_rutas_asignadas_x_vendedor
        public List<CENRutasBitacora> ListarRutasBitacora(int codVendedor, int fechaActual, Int16 flagFiltro, DateTime fechaIncio, DateTime fechaFin)
        {

            List<CENRutasBitacora> ListaRB = new List<CENRutasBitacora>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENRutasBitacora objRutasBitacora = null;

            CADConexion CadCx = new CADConexion();
            
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_rutas_bitacoras", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codVendedor", SqlDbType.Int).Value = codVendedor;
                cmd.Parameters.Add("@fechaActual", SqlDbType.Int).Value = fechaActual;
                cmd.Parameters.Add("@flagFiltro", SqlDbType.Int).Value = flagFiltro;
                cmd.Parameters.Add("@fechaIncio", SqlDbType.Date).Value = fechaIncio;
                cmd.Parameters.Add("@fechaFin", SqlDbType.Date).Value = fechaFin;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto Rutas
                    objRutasBitacora = new CENRutasBitacora();
                    objRutasBitacora.vendedor = dr["vendedor"].ToString();
                    objRutasBitacora.descripcion = dr["descripcion"].ToString();
                    objRutasBitacora.cliente = dr["cliente"].ToString();
                    objRutasBitacora.razonsocial = dr["razonsocial"].ToString();
                    objRutasBitacora.visita = Convert.ToInt16(dr["visita"]);
                    objRutasBitacora.motivo = dr["motivo"].ToString();
                    objRutasBitacora.coordenadaX = dr["cordenadaX"].ToString();
                    objRutasBitacora.coordenadaY = dr["cordenadaY"].ToString();
                    objRutasBitacora.fecha = dr["fecha"].ToString();
                    ListaRB.Add(objRutasBitacora);

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
            return ListaRB;
        }
    }

}

