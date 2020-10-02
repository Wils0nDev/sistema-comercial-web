using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class CADcomprobSunat
    {
        private SqlConnection Connection;
        public int RegistrarComprobSunat(CENComprobSunat data)
        {
            //DESCRIPCION: REGISTRAR COMPROBANTE DE LA SUNAT
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            int codigo = CENConstante.g_const_0;
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_registrar_comprobante_sunat", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_codTransaccion", SqlDbType.Int).Value = data.codTransaccion;
                        Command.Parameters.Add("@p_codModulo", SqlDbType.SmallInt).Value = data.codModulo;
                        Command.Parameters.Add("@p_tipDocSunat", SqlDbType.SmallInt).Value = data.tipDocSunat;
                        Command.Parameters.Add("@p_tipDocVenta", SqlDbType.SmallInt).Value = data.tipDocVenta;
                        Command.Parameters.Add("@p_tramEntrada", SqlDbType.VarChar).Value = data.tramEntrada;
                        Command.Parameters.Add("@p_estado", SqlDbType.SmallInt).Value = data.estado;
                        Command.Parameters.Add("@p_usuario", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.estado;
                        Command.Parameters.Add("@p_ip", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.ip;
                        Command.Parameters.Add("@p_mac", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.mac;

                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                if (dr["codigo"] != DBNull.Value)
                                    codigo = Convert.ToInt32(dr["codigo"].ToString().Trim());
                            }
                        }
                        dr.Close();
                    }
                }
                return codigo;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }


        public void ActualizarComprobSunat(int codTransaccino, string tramaSalida, int estado)
        {
            //DESCRIPCION: ACTUALIZAR COMPROBANTE DE LA SUNAT
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_actualizar_comprobante_sunat", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_codTransaccion", SqlDbType.Int).Value = codTransaccino;
                        Command.Parameters.Add("@p_tramSalida", SqlDbType.VarChar).Value = tramaSalida;
                        Command.Parameters.Add("@p_estado", SqlDbType.SmallInt).Value = estado;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();

                        dr.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }


        public List<CENComprobSunat> ListarComprobantesFallidos()
        {
            //DESCRIPCION: LISTAR COMPROBANTES FALLIDOS DE LA SUNAT
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            List<CENComprobSunat> listComprobantes = new List<CENComprobSunat>();
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_lista_comprob_fallidos", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            CENComprobSunat comprobante = new CENComprobSunat();
                            while (dr.Read())
                            {
                                comprobante = new CENComprobSunat();
                                if (dr["ntraComprob"] != DBNull.Value)
                                    comprobante.ntraComprob = Convert.ToInt32(dr["ntraComprob"].ToString().Trim());
                                if (dr["codTransaccion"] != DBNull.Value)
                                    comprobante.codTransaccion = Convert.ToInt32(dr["codTransaccion"].ToString().Trim());
                                if (dr["codModulo"] != DBNull.Value)
                                    comprobante.codModulo = Convert.ToInt32(dr["codModulo"].ToString().Trim());
                                if (dr["tipDocSunat"] != DBNull.Value)
                                    comprobante.tipDocSunat = Convert.ToInt32(dr["tipDocSunat"].ToString().Trim());
                                if (dr["tipDocVenta"] != DBNull.Value)
                                    comprobante.tipDocVenta = Convert.ToInt32(dr["tipDocVenta"].ToString().Trim());
                                if (dr["tramEntrada"] != DBNull.Value)
                                    comprobante.tramEntrada = dr["tramEntrada"].ToString().Trim();

                                listComprobantes.Add(comprobante);
                            }
                        }
                        dr.Close();
                    }
                }
                return listComprobantes;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }


    }
}
