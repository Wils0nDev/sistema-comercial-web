using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADTransaccionPago
    {

        public int InsertarTransaccionPago(int flag, CENTransaccionPago objTP, CENPagoEfectivo objPE, CENPagoTransferencia objePT)
        {

            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_modificar_transaccion_pago", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_flag", flag);
                cmd.Parameters.AddWithValue("@p_codPrestamo", objTP.codPrestamo);
                cmd.Parameters.AddWithValue("@p_nroCuota", objTP.nroCuota);
                cmd.Parameters.AddWithValue("@p_codVenta", objTP.codVenta);
                cmd.Parameters.AddWithValue("@p_ntraMedioPago", objTP.ntraMedioPago);
                cmd.Parameters.AddWithValue("@p_tipoCambio", objTP.tipoCambio);
                cmd.Parameters.AddWithValue("@p_tipoMoneda", objTP.tipoMoneda);
                cmd.Parameters.AddWithValue("@p_igv", objTP.IGV);
                cmd.Parameters.AddWithValue("@p_estado", objTP.estado);
                cmd.Parameters.AddWithValue("@p_importe", objPE.importe);
                cmd.Parameters.AddWithValue("@p_vuelto", objPE.vuelto);
                cmd.Parameters.AddWithValue("@p_nroTransferencia", objePT.nroTransferencia);
                cmd.Parameters.AddWithValue("@p_cuentaTransferencia", objePT.cuentaTransferencia); 
                cmd.Parameters.AddWithValue("@p_banco", objePT.banco);
                cmd.Parameters.AddWithValue("@p_fechaTransferencia", objePT.fechaTransferencia);
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
