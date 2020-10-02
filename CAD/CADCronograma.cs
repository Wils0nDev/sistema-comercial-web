using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADCronograma
    {

        public List<CENCronograma> ListarCronograma(int codVenta, int flag)
        {

            List<CENCronograma> ListobjCro = new List<CENCronograma>();

            CENCronograma objCro = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_busqueda_cronograma_prestamo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_flagFiltro", SqlDbType.Int).Value = flag;
                cmd.Parameters.Add("@p_ntraVenta", SqlDbType.Int).Value = codVenta;
                con.Open();
                dr = cmd.ExecuteReader();

                //Crear objeto Cuentas por cobrar
                while (dr.Read())
                {
                    objCro = new CENCronograma();
                    objCro.codPrestamo = Convert.ToInt32(dr["codPrestamo"]);
                    objCro.fechaPago = Convert.ToDateTime(dr["fechaPago"].ToString());
                    objCro.nroCuota = Convert.ToInt32(dr["nroCuota"]);
                    objCro.importe = Convert.ToDouble(dr["importe"]);
                    objCro.estado = Convert.ToInt16(dr["estado"]);
                    objCro.descestado = dr["descestado"].ToString();

                    ListobjCro.Add(objCro);

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
            return ListobjCro;

        }
    }
}
