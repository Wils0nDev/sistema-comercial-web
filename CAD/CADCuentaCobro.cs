using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADCuentaCobro
    {
        public CENCuentaCobro BuscarCuentaPorCobrar(int codVenta, int flag) {

            CENCuentaCobro objCxC = new CENCuentaCobro();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
           //    CENRutasAsignadasView objRutasAsignadas = null;

            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_busqueda_tipo_venta_pago", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_flagFiltro", SqlDbType.Int).Value = flag;
                cmd.Parameters.Add("@p_ntraVenta", SqlDbType.Int).Value = codVenta;
                con.Open();
                dr = cmd.ExecuteReader();

                //Crear objeto Cuentas por cobrar
                while (dr.Read())
                {
                    objCxC.ntra = Convert.ToInt32(dr["ntra"]);
                    objCxC.codOperacion = Convert.ToInt32(dr["codOperacion"]);
                    objCxC.importe = Convert.ToDecimal(dr["importe"]);
                    objCxC.fechaCobro = Convert.ToDateTime(dr["fechaCobro"].ToString());
                    objCxC.estado = Convert.ToInt16(dr["estado"]);
                    objCxC.tipoCambiov = Convert.ToDecimal(dr["tipoCambiov"]);

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
            return objCxC;

        }
    }
}
