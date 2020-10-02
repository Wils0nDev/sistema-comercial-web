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
    public class CADPerfilVIEW

    {
         public List<CENPerfilVIEW> CargarPerfil(int flag)
        {
            List<CENPerfilVIEW> ListaPerfil= new List<CENPerfilVIEW>();
            //int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENPerfilVIEW objPerfil = null;
            CADConexion CadCx = new CADConexion();
            try {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_datos_select_x_flag",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //Crear objeto usuario
                       objPerfil = new  CENPerfilVIEW();
                       objPerfil.codPerfil  = Convert.ToInt32(dr["codigo"]);
                       objPerfil.despsnPerfil  = dr["descripcion"].ToString();
                       ListaPerfil.Add(objPerfil);
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
            return ListaPerfil;


        }


    }
}
