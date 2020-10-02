using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADConcepto
    {
        private SqlConnection Connection;


        //reutilizando webmetodo listar dias por tabla concepto para estadod de usuarios
        public List<CENConcepto> ListarDias( int flag)
        {
            List<CENConcepto> listDA = new List<CENConcepto>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENConcepto ObjDias = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_datos_select_x_flag", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ObjDias = new CENConcepto();
                    ObjDias.correlativo = Convert.ToInt16(dr["correlativo"]);
                    ObjDias.descripcion = dr["descripcion"].ToString();
                    listDA.Add(ObjDias);
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

            return listDA;

        }

        public List<CENConcepto> ListarConceptos()
        {
            //Listar Conceptos (CORRELATIVO)
            List<CENConcepto> listConcepto = new List<CENConcepto>();

            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_conceptos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_pref", SqlDbType.Int).Value = 7; //Prefijo Tipos de Precios

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENConcepto dataConcepto = new CENConcepto();

                            dataConcepto.correlativo = Convert.ToInt16(dr["correlativo"]);

                            listConcepto.Add(dataConcepto);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listConcepto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENConcepto> ListarConceptosDescripcionPrecio()
        {
            //Listar Conceptos (DESCRIPCION)
            List<CENConcepto> listConcepto = new List<CENConcepto>();

            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_conceptos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_pref", SqlDbType.Int).Value = 7; //Prefijo Tipos de Precios

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENConcepto dataConcepto = new CENConcepto();

                            dataConcepto.descripcion = dr["descripcion"].ToString();

                            listConcepto.Add(dataConcepto);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listConcepto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtener_descripcion_concepto(int p_concepto, int p_correlativo)
        {
            //DESCRIPCION: OBTENER DESCRIPCION DE CONCEPTO
            CADConexion CadCx = new CADConexion();    //conexión
            string descripcion = null;                  //descripcion
            try
            {
                string l_sql = "SELECT descripcion FROM tblConcepto WHERE codConcepto = " + p_concepto + " AND correlativo = " + p_correlativo + " AND marcaBaja = " + CENConstante.g_const_0;
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        descripcion = Convert.ToString(dr[CENConstante.g_const_0]);
                    }

                    dr.Close();
                }

                return descripcion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
        }

    }
}
