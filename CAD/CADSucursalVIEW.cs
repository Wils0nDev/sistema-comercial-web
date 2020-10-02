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
    public class CADSucursalVIEW
    {

        public List<CENSucursalVIEW> cargarSucursal(int flag)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENSucursalVIEW objSucur = null;
            List<CENSucursalVIEW> ListSuc = new List<CENSucursalVIEW>();
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
                    objSucur = new CENSucursalVIEW();
                    objSucur.ntraSucursal = Convert.ToInt32(dr["ntraSucursal"]);
                    objSucur.descripcion = dr["descripcion"].ToString();
                    ListSuc.Add(objSucur);
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

            return ListSuc;
        }

    }
}
