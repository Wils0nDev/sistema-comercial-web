using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADUsuario
    {
      

        //DESCRIPCION: FUNCION QUE ME TRAERA LOS VENDEDORES DE LA TABLA tblUsuario. FLAG = 1
        public List<CENUsuario> ListarVendedores(int flag)
        {

            List<CENUsuario> ListaVE = new List<CENUsuario>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENUsuario objVendedor = null;
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
                    //Crear objeto Vendedor
                    objVendedor = new CENUsuario();
                    objVendedor.ntraUsuario = Convert.ToInt32(dr["ntraUsuario"]);
                    objVendedor.vendedor = dr["vendedor"].ToString();
                    ListaVE.Add(objVendedor);

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
            return ListaVE;
        }

        public List<CENUsuario> DatosUsuarios(string usuario, string contraseña, int intentos, int sucursal)
        //DESCRPCION: Obtiene las credenciales de usuario
        {
            List<CENUsuario> ListaDatos = new List<CENUsuario>();
            SqlConnection con = null;
            SqlCommand cmd;
            SqlDataReader dr;
            CENUsuario objUsuarios;
            CADConexion CadCx = new CADConexion();


            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_buscar_credenciales_usuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@p_password", SqlDbType.VarChar).Value = contraseña;
                cmd.Parameters.Add("@p_intentos", SqlDbType.Int).Value = intentos;
                cmd.Parameters.Add("@p_flag", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@p_sucursal", SqlDbType.Int).Value = sucursal;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto usuario
                    objUsuarios = new CENUsuario();
                    objUsuarios.respuesta = Convert.ToInt32(dr["respuesta"].ToString());
                    if (objUsuarios.respuesta == CENConstante.g_const_505)
                    {
                        objUsuarios.perfil = dr["perfil"].ToString();
                        objUsuarios.sucursal = dr["sucursal"].ToString();
                        objUsuarios.ntraUsuario = Convert.ToInt32(dr["codUsuario"].ToString());
                        objUsuarios.telefono = dr["telefono"].ToString();
                        objUsuarios.fkcodPersona = Convert.ToInt32(dr["codPersona"].ToString());
                    }
                    objUsuarios.nombre = dr["nombres"].ToString();
                    ListaDatos.Add(objUsuarios);
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
            return ListaDatos;
        }

        public List<CENUsuario> CerrarSesion(int codUsuario)
        //DESCRPCION: Cierra la sesion de usuario
        {
            List<CENUsuario> ListaDatos = new List<CENUsuario>();
            SqlConnection con = null;
            SqlCommand cmd;
            SqlDataReader dr;
            CENUsuario objUsuarios;
            CADConexion CadCx = new CADConexion();
            DateTime fecha = DateTime.Now;
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_cerrar_sesion_usuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_codUsu", SqlDbType.Int).Value = codUsuario;
                cmd.Parameters.Add("@p_fecha_fin", SqlDbType.DateTime).Value = fecha;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto usuario
                    objUsuarios = new CENUsuario();
                    objUsuarios.respuesta = Convert.ToInt32(dr["codigo"].ToString());
                    objUsuarios.mensaje = dr["mensaje"].ToString();

                    ListaDatos.Add(objUsuarios);
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
            return ListaDatos;
        }

        public List<CENUsuario> ListarCajeros_Sucursal(int flag)
        {

            List<CENUsuario> ListaCaj = new List<CENUsuario>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENUsuario objCajero = null;
            CADConexion CadCx = new CADConexion();

            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_cajeros_sucursal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ntraSucursal", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto Cajero
                    objCajero = new CENUsuario();
                    objCajero.ntraUsuario = Convert.ToInt32(dr["correlativo"]);
                    objCajero.vendedor = dr["descripcion"].ToString();
                    ListaCaj.Add(objCajero);

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
            return ListaCaj;
        }



        

    }
}
