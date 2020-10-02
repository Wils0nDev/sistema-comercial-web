using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace CAD
{
    public class CADPermisos
    {

        public CADPermisos() { }

        public List<CENUsuario> cargarPerfil(int flag)
        {
            CADConexion con = new CADConexion();
            SqlConnection sqlcon = null;
            SqlCommand cmd;
            SqlDataReader dr;
            List<CENUsuario> perfil = new List<CENUsuario>();
            CENUsuario usuario;
            try
            {

                sqlcon = new SqlConnection(con.CxSQL());
                cmd = new SqlCommand("pa_listar_datos_select_x_flag", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                sqlcon.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = new CENUsuario();
                    usuario.codPerfil = Convert.ToInt16(dr["codigo"].ToString());
                    usuario.perfil = dr["descripcion"].ToString();

                    perfil.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }

            return perfil;
        }

        public List<CENModulo> cargarModulos(int flag)
        {
            CADConexion con = new CADConexion();
            SqlConnection sqlcon = null;
            SqlCommand cmd;
            SqlDataReader dr;
            List<CENModulo> modulos = new List<CENModulo>();
            CENModulo modulo;
            try
            {

                sqlcon = new SqlConnection(con.CxSQL());
                cmd = new SqlCommand("pa_listar_datos_select_x_flag", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                sqlcon.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    modulo = new CENModulo();
                    modulo.codModulo = Convert.ToInt16(dr["codigo"].ToString());
                    modulo.descripcion = dr["modulo"].ToString();

                    modulos.Add(modulo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }

            return modulos;
        }

        public List<CENMenu> cargarMantenedores(int flag)
        {
            CADConexion con = new CADConexion();
            SqlConnection sqlcon = null;
            SqlCommand cmd;
            SqlDataReader dr;
            List<CENMenu> groupMenu = new List<CENMenu>();
            CENMenu menu;
            try
            {

                sqlcon = new SqlConnection(con.CxSQL());
                cmd = new SqlCommand("", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                sqlcon.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    menu = new CENMenu();
                    menu.codigoSubMenu = Convert.ToInt16(dr["codigo"].ToString());
                    menu.nomSubMenu = dr["menu"].ToString();

                    groupMenu.Add(menu);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }

            return groupMenu;
        }
        public static String ObjectToXMLGeneric<T>(T filter)
        {
            //DESCRIPCION: CONVERTIR CLASS LIST EN CADENA XML
            string xml = null; // XML
            using (StringWriter sw = new StringWriter())
            {

                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, filter);
                try
                {
                    xml = sw.ToString();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return xml;
        }

        public int guardarPermiso(CENPermiso permisos, int flag)
        {
            //DESCRIPCION: inserta y modifica los perfiles
            int res;
            string xmlListParametros = ObjectToXMLGeneric<List<CENPermiso>>(permisos.listPermiso); //XML de lista de preventa descuento

            CADConexion con = new CADConexion();
            SqlConnection sqlcon = null;
            SqlCommand cmd;
            try
            {

                sqlcon = new SqlConnection(con.CxSQL());
                cmd = new SqlCommand("pa_insertar_modificar_permiso", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_flag", flag);
                cmd.Parameters.AddWithValue("@p_list", xmlListParametros);
                sqlcon.Open();
                res = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }

            return res;
        }

        public List<CENMenu> DataMenus()
        {
            CENMenu menu;
            List<CENMenu> dataMenu = new List<CENMenu>();
            CADConexion cnx = new CADConexion();
            SqlConnection con = null;
            SqlCommand cm;
            SqlDataReader dr;

            try
            {
                con = new SqlConnection(cnx.CxSQL());
                cm = new SqlCommand("pa_buscar_menus", con);
                cm.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    menu = new CENMenu();
                    menu.codigoModulo = Convert.ToInt32(dr["codModulo"].ToString());
                    menu.nomModulo = dr["nomModulo"].ToString();
                    menu.codigoSubMenu = Convert.ToInt32(dr["codMenu"].ToString());
                    menu.nomSubMenu = dr["nomMantenedor"].ToString();
                    menu.codPermisoFK = 0;
                    dataMenu.Add(menu);
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



            return dataMenu;
        }

        public List<CENMenu> DataMenusPerfil(int perfil)
        {
            CENMenu menu;
            List<CENMenu> dataMenu = new List<CENMenu>();
            CADConexion cnx = new CADConexion();
            SqlConnection con = null;
            SqlCommand cm;
            SqlDataReader dr;

            try
            {
                con = new SqlConnection(cnx.CxSQL());
                cm = new SqlCommand("pa_buscar_modulos", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add("@p_codUser", SqlDbType.Int).Value = perfil;
                cm.Parameters.Add("@p_flag", SqlDbType.Int).Value = CENConstante.g_const_2;
                con.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    menu = new CENMenu();
                    menu.codigoModulo = Convert.ToInt32(dr["codModulo"].ToString());
                    menu.nomModulo = dr["nomModulo"].ToString();
                    menu.codigoSubMenu = Convert.ToInt32(dr["codMenu"].ToString());
                    menu.nomSubMenu = dr["nomMantenedor"].ToString();
                    menu.codPermisoFK = Convert.ToInt32(dr["codPermiso"].ToString());
                    dataMenu.Add(menu);
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

            return dataMenu;
        }

        public List<CENMenu> DataMantenedoresNombre(string nombre)
        //DESCRIPCION: Busca los mantenedores por nombre
        {
            CENMenu menu;
            List<CENMenu> dataMenu = new List<CENMenu>();
            CADConexion cnx = new CADConexion();
            SqlConnection con = null;
            SqlCommand cm;
            SqlDataReader dr;

            try
            {
                con = new SqlConnection(cnx.CxSQL());
                cm = new SqlCommand("pa_buscar_mantenedores_nombre", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add("@p_codUser", SqlDbType.VarChar).Value = nombre;
                con.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    menu = new CENMenu();
                    menu.codigoModulo = Convert.ToInt32(dr["codModulo"].ToString());
                    menu.nomModulo = dr["nomModulo"].ToString();
                    menu.codigoSubMenu = Convert.ToInt32(dr["codMenu"].ToString());
                    menu.nomSubMenu = dr["nomMantenedor"].ToString();
                    menu.codPermisoFK = 0;
                    dataMenu.Add(menu);
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

            return dataMenu;
        }
    }
}

