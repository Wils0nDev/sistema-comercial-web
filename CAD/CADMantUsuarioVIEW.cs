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
    public class CADMantUsuarioVIEW
    {

        public List<CENMantUsuarioVIEW> ListarUsuario(
            int flagFiltro , int codEstado, int codUsuario)
        {
            List<CENMantUsuarioVIEW> ListaUser= new List<CENMantUsuarioVIEW>();
            //int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENMantUsuarioVIEW objUsuario = null;
            CADConexion CadCx = new CADConexion();

            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_buscar_usuario",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_flagFiltro", SqlDbType.Int).Value = flagFiltro;
                cmd.Parameters.Add("@p_codEstado", SqlDbType.Int).Value = codEstado;
                cmd.Parameters.Add("@p_codUsuario", SqlDbType.Int).Value = codUsuario;
                con.Open();
                dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //Crear objeto usuario
                        objUsuario = new  CENMantUsuarioVIEW();
                        objUsuario.codPersona   = Convert.ToInt32(dr["codPersona"]);
                        objUsuario.ntraUsuario  = Convert.ToInt32(dr["ntraUsuario"]);
                        objUsuario.numDocumento  =  dr["numeroDocumento"].ToString();
                        objUsuario.nomUser  = dr["Usuario"].ToString();
                        objUsuario.usuarioPersona = dr["usuarioPersona"].ToString();
                        objUsuario.correo = dr["correo"].ToString();
                        objUsuario.celular  = dr["celular"].ToString();
                        objUsuario.telefono  = dr["telefono"].ToString();
                        objUsuario.codPerfil  = Convert.ToInt32(dr["codigoPerfil"]);
                        objUsuario.desPerfil  = dr["perfil"].ToString();
                        objUsuario.codSucursal  = Convert.ToInt32(dr["codigoSucursal"]);
                        objUsuario.desSucursal  = dr["sucursal"].ToString();
                        objUsuario.codEstado  =  Convert.ToInt32(dr["codEstado"]);
                        objUsuario.desEstado  = dr["estadoDescp"].ToString();
                        ListaUser.Add(objUsuario);
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
            return ListaUser;
        }




     public List<CENAutoUsuarioVIEW> buscarUsuario (string cadena)
     {
         List<CENAutoUsuarioVIEW > ListaUser= new List<CENAutoUsuarioVIEW>();
            //int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENAutoUsuarioVIEW  objUsuario = null;
            CADConexion CadCx = new CADConexion();

            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_auto_nom_buscar_usuario",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_cadena", SqlDbType.VarChar,50).Value = cadena.Trim();
                con.Open();
                dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //Crear objeto usuario
                        objUsuario = new  CENAutoUsuarioVIEW();
                        objUsuario.codUsuario  = Convert.ToInt32(dr["codUsuario"]);
                        objUsuario.numDoc  =  dr["numDoc"].ToString();
                        objUsuario.nombres  = dr["nombres"].ToString();
                        ListaUser.Add(objUsuario);
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
            return ListaUser;
        }


     }


  
        
 }
