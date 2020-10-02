using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;

namespace CAD
{
    public class CADObjetivo
    {

        public List<CENConcepto> ListarConceptos(int auxflag)
        {
            List<CENConcepto> listConcepto = new List<CENConcepto>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_datos_select_x_flag", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@flag", SqlDbType.Int).Value = auxflag;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENConcepto dataConcepto = new CENConcepto();

                            dataConcepto.correlativo = Convert.ToInt32(dr["correlativo"]);
                            dataConcepto.descripcion = Convert.ToString(dr["descripcion"]);

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
        public List<CENConcepto> ListarConceptosPerfil(int auxflag)
        {
            List<CENConcepto> listConcepto = new List<CENConcepto>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_datos_select_x_flag", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@flag", SqlDbType.Int).Value = auxflag;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENConcepto dataConcepto = new CENConcepto();

                            dataConcepto.correlativo = Convert.ToInt32(dr["codigo"]);
                            dataConcepto.descripcion = Convert.ToString(dr["descripcion"]);

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

        public List<CENTrabajador> ListarTrabajadorPorPerfil(int codPerfil)
        {
            List<CENTrabajador> ListaTrabajador = new List<CENTrabajador>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENTrabajador objTrabajador = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_trabajador_x_perfil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codPerfil", SqlDbType.Int).Value = codPerfil;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto Rutas
                    objTrabajador = new CENTrabajador();
                    objTrabajador.codPersona = Convert.ToInt32(dr["codPersona"]);
                    objTrabajador.nombres = dr["Trabajador"].ToString();
                    ListaTrabajador.Add(objTrabajador);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaTrabajador;
        }
        
        public int InsertarObjetivo(CENObjetivo objObjetivo)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_objetivo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_descripcion", SqlDbType.VarChar).Value = objObjetivo.descripcion;
                cmd.Parameters.Add("@p_codTipoIndicador", SqlDbType.SmallInt).Value = objObjetivo.codTipoIndicador;
                cmd.Parameters.Add("@p_codIndicador", SqlDbType.SmallInt).Value = objObjetivo.codIndicador;
                cmd.Parameters.Add("@p_valorIndicador", SqlDbType.Decimal).Value = objObjetivo.valorIndicador;
                cmd.Parameters.Add("@p_codPerfil", SqlDbType.SmallInt).Value = objObjetivo.codPerfil;
                cmd.Parameters.Add("@p_codTrabajador", SqlDbType.Int).Value = objObjetivo.codTrabajador;
                cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar).Value = objObjetivo.usuario;
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

        public List<CENObjetivoLista> ListaObjetivoPorFiltro(CENObjetivo datos)
        {

            List<CENObjetivoLista> list_Objetivo = new List<CENObjetivoLista>();
            CENObjetivoLista objObjetivoLista = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_filtro_objetivos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codTipoIndicador", SqlDbType.Int).Value = datos.codTipoIndicador;
                cmd.Parameters.Add("@codIndicador", SqlDbType.Int).Value = datos.codIndicador;
                cmd.Parameters.Add("@codPerfil", SqlDbType.Int).Value = datos.codPerfil;
                cmd.Parameters.Add("@codTrabajador", SqlDbType.Int).Value = datos.codTrabajador;
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
                    objObjetivoLista = new CENObjetivoLista();
                    objObjetivoLista.codObjetivo = Convert.ToInt32(dr["codObjetivo"]);
                    objObjetivoLista.descripcion = Convert.ToString(dr["descripcion"].ToString());
                    objObjetivoLista.descTipoIndicador = Convert.ToString(dr["descTipoIndicador"].ToString());
                    objObjetivoLista.descIndicador = Convert.ToString(dr["descIndicador"].ToString());
                    objObjetivoLista.valorIndicador = Convert.ToDecimal(dr["valorIndicador"]);
                    objObjetivoLista.descPerfil = Convert.ToString(dr["descPerfil"].ToString());
                    objObjetivoLista.descTrabajador = Convert.ToString(dr["descTrabajador"].ToString());
                    objObjetivoLista.fechaRegistro = dr["fechaRegistro"].ToString();
                    list_Objetivo.Add(objObjetivoLista);
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
            return list_Objetivo;

        }
    }
}
