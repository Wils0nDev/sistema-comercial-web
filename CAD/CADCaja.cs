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
    public class CADCaja
    {

        public List<CENCaja> ListarCajas(
            int ntraCaja, int estadoCaja, int ntraUsuario, int ntraSucursal, 
            string fechaInicial, string fechaFinal)
        {
            List<CENCaja> listaC = new List<CENCaja>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENCaja objCaja = null;
            CADConexion CadCx = new CADConexion();
            CAD_Consulta cad_consulta = new CAD_Consulta();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_cajas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_ntraCaja", SqlDbType.Int).Value = ntraCaja;
                cmd.Parameters.Add("@p_estadoCaja", SqlDbType.Int).Value = estadoCaja;
                cmd.Parameters.Add("@p_ntraUsuario", SqlDbType.Int).Value = ntraUsuario;
                cmd.Parameters.Add("@p_ntraSucursal", SqlDbType.Int).Value = ntraSucursal;
                if (fechaInicial == "")
                {
                    cmd.Parameters.Add("@p_fechaInicial", SqlDbType.Date).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@p_fechaInicial", SqlDbType.Date).Value = fechaInicial;
                }
                if (fechaFinal == "")
                {
                    cmd.Parameters.Add("@p_fechaFinal", SqlDbType.Date).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@p_fechaFinal", SqlDbType.Date).Value = fechaFinal;
                }
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCaja = new CENCaja();
                    objCaja.ntraCaja = Convert.ToInt32(dr["ntraCaja"]);
                    objCaja.descripcion = dr["descripcion"].ToString();
                    objCaja.sucursal = dr["sucursal"].ToString();
                    objCaja.codEstado = Convert.ToInt32(dr["codEstado"]);
                    objCaja.estado = dr["estado"].ToString();
                    objCaja.fechaCreacion =  cad_consulta.ConvertFechaDateToString(DateTime.Parse(dr["fechaCreacion"].ToString().Trim()));
                    objCaja.horaCreacion = dr["horaCreacion"].ToString();
                    objCaja.ntraUsuario = Convert.ToInt32(dr["ntraUsuario"]);
                    objCaja.users = dr["users"].ToString();
                    objCaja.nombreCompleto = dr["nombreCompleto"].ToString();
                    listaC.Add(objCaja);

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

            return listaC;

        }

        public CENCaja ListarTipos_Mov_Asig_Caja(CENCaja objCaja)
        {
            List<CENTipoMovimiento> listaTM = new List<CENTipoMovimiento>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENTipoMovimiento objTM = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_tipos_mov_asig_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ntraCaja", objCaja.ntraCaja);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objTM = new CENTipoMovimiento();
                    objTM.ntraTipoMovimiento = Convert.ToInt32(dr["ntraTipoMovimiento"]);
                    objTM.descripcion = dr["descripcion"].ToString();
                    objTM.codTipoRegistro = Convert.ToInt32(dr["codTipoRegistro"]);
                    objTM.tipoRegistro = dr["tipoRegistro"].ToString();
                    listaTM.Add(objTM);

                }

                objCaja.listaTipoMovimientos = listaTM;

            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }

            finally
            {
                con.Close();
            }

            return objCaja;

        }

        public int RegistrarCaja(CENCaja objCaja)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                string listaTipoMov = ObjectToXMLGeneric<List<CENTipoMovimiento>>(objCaja.listaTipoMovimientos);

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", objCaja.descripcion);
                cmd.Parameters.AddWithValue("@ntraUsuario", objCaja.ntraUsuario);
                cmd.Parameters.AddWithValue("@ntraSucursal", objCaja.ntraSucursal);
                cmd.Parameters.AddWithValue("@listaTipoMov", listaTipoMov);
                //cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                //response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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



        public int ActualizarCaja(CENCaja objCaja)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                string listaTipoMov = ObjectToXMLGeneric<List<CENTipoMovimiento>>(objCaja.listaTipoMovimientos);

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_actualizar_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ntraCaja", objCaja.ntraCaja);
                cmd.Parameters.AddWithValue("@descripcion", objCaja.descripcion);
                cmd.Parameters.AddWithValue("@ntraUsuario", objCaja.ntraUsuario);
                cmd.Parameters.AddWithValue("@listaTipoMov", listaTipoMov);
                //cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                //response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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

        public List<CENAperturaCaja> ListarCajasAperturadas(int ntraSucursal, int ntraCaja, int flag)
        {
            List<CENAperturaCaja> listaAC = new List<CENAperturaCaja>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENAperturaCaja objAperturaCaja = null;
            CADConexion CadCx = new CADConexion();
            CAD_Consulta cad_consulta = new CAD_Consulta();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_cajas_aperturadas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_ntraSucursal", SqlDbType.Int).Value = ntraSucursal;
                cmd.Parameters.Add("@p_ntraCaja", SqlDbType.Int).Value = ntraCaja;
                cmd.Parameters.Add("@p_flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objAperturaCaja = new CENAperturaCaja();
                    objAperturaCaja.ntraAperturaCaja = Convert.ToInt32(dr["ntraAperturaCaja"]);
                    objAperturaCaja.ntraCaja = Convert.ToInt32(dr["ntraCaja"]);
                    objAperturaCaja.caja = dr["caja"].ToString();
                    objAperturaCaja.fecha = cad_consulta.ConvertFechaDateToString(DateTime.Parse(dr["fecha"].ToString().Trim()));
                    objAperturaCaja.hora = dr["hora"].ToString();
                    objAperturaCaja.saldoSoles = Convert.ToDecimal(dr["saldoSoles"]);
                    objAperturaCaja.saldoDolares = Convert.ToDecimal(dr["saldoDolares"]);
                    objAperturaCaja.codEstado = Convert.ToInt32(dr["codEstado"]);
                    objAperturaCaja.estado = dr["estado"].ToString();
                    objAperturaCaja.marcaBaja = Convert.ToInt32(dr["marcaBaja"]);
                    listaAC.Add(objAperturaCaja);

        
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

            return listaAC;

        }

        public int RegistrarAperturaCaja(CENAperturaCaja objAperturaCaja)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_apertura_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ntraCaja", objAperturaCaja.ntraCaja);
                cmd.Parameters.AddWithValue("@saldoSoles", objAperturaCaja.saldoSoles);
                cmd.Parameters.AddWithValue("@saldoDolares", objAperturaCaja.saldoDolares);
                //cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                //response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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



        public int ActualizarAperturaCaja(CENAperturaCaja objAperturaCaja)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_actualizar_apertura_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ntraAperturaCaja", objAperturaCaja.ntraAperturaCaja);
                cmd.Parameters.AddWithValue("@saldoSoles", objAperturaCaja.saldoSoles);
                cmd.Parameters.AddWithValue("@saldoDolares", objAperturaCaja.saldoDolares);
                //cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                //response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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

        public List<CENCierreCaja> ListarCajasCerradas(int ntraSucursal, int ntraCaja, int flag)
        {
            List<CENCierreCaja> listaCC = new List<CENCierreCaja>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENCierreCaja objCierreCaja = null;
            CADConexion CadCx = new CADConexion();
            CAD_Consulta cad_consulta = new CAD_Consulta();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_cajas_cerradas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_ntraSucursal", SqlDbType.Int).Value = ntraSucursal;
                cmd.Parameters.Add("@p_ntraCaja", SqlDbType.Int).Value = ntraCaja;
                cmd.Parameters.Add("@p_flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCierreCaja = new CENCierreCaja();
                    objCierreCaja.ntraCierreCaja = Convert.ToInt32(dr["ntraCierreCaja"]);
                    objCierreCaja.ntraCaja = Convert.ToInt32(dr["ntraCaja"]);
                    objCierreCaja.caja = dr["caja"].ToString();
                    objCierreCaja.fecha = cad_consulta.ConvertFechaDateToString(DateTime.Parse(dr["fecha"].ToString().Trim()));
                    objCierreCaja.hora = dr["hora"].ToString();
                    objCierreCaja.saldoSoles = Convert.ToDecimal(dr["saldoSoles"]);
                    objCierreCaja.saldoDolares = Convert.ToDecimal(dr["saldoDolares"]);
                    objCierreCaja.saldoSolesCierre = Convert.ToDecimal(dr["saldoSolesCierre"]);
                    objCierreCaja.saldoDolaresCierre = Convert.ToDecimal(dr["saldoDolaresCierre"]);
                    objCierreCaja.difSaldoSoles = Convert.ToDecimal(dr["difSaldoSoles"]);
                    objCierreCaja.difSaldoDolares = Convert.ToDecimal(dr["difSaldoDolares"]);
                    objCierreCaja.marcaBaja = Convert.ToInt32(dr["marcaBaja"]);
                    listaCC.Add(objCierreCaja);


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

            return listaCC;

        }

        public List<CENTransaccionCaja> ListarTransaccionesCajas(int ntraSucursal, int ntraCaja, string fechaTransaccion, int flag)
        {
            List<CENTransaccionCaja> listaTC = new List<CENTransaccionCaja>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENTransaccionCaja objTransaccionCaja = null;
            CADConexion CadCx = new CADConexion();
            CAD_Consulta cad_consulta = new CAD_Consulta();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_transacciones_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_ntraSucursal", SqlDbType.Int).Value = ntraSucursal;
                cmd.Parameters.Add("@p_ntraCaja", SqlDbType.Int).Value = ntraCaja;
                if (fechaTransaccion == "")
                {
                    cmd.Parameters.Add("@p_fechaTransaccion", SqlDbType.Date).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@p_fechaTransaccion", SqlDbType.Date).Value = fechaTransaccion;
                }
                cmd.Parameters.Add("@p_flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objTransaccionCaja = new CENTransaccionCaja();
                    objTransaccionCaja.ntraTransaccionCaja = Convert.ToInt32(dr["ntraTransaccionCaja"]);
                    objTransaccionCaja.ntraCaja = Convert.ToInt32(dr["ntraCaja"]);
                    objTransaccionCaja.caja = dr["caja"].ToString();
                    objTransaccionCaja.codTipoRegistro = Convert.ToInt32(dr["codTipoRegistro"]);
                    objTransaccionCaja.tipoRegistro = dr["tipoRegistro"].ToString();
                    objTransaccionCaja.ntraTipoMovimiento = Convert.ToInt32(dr["ntraTipoMovimiento"]);
                    objTransaccionCaja.tipoMovimieno = dr["tipoMovimieno"].ToString();
                    objTransaccionCaja.fechaTransaccion = cad_consulta.ConvertFechaDateToString(DateTime.Parse(dr["fechaTransaccion"].ToString().Trim()));
                    objTransaccionCaja.horaTransaccion = dr["horaTransaccion"].ToString();
                    if (dr["codVenta"] != null)
                    {
                        objTransaccionCaja.codVenta = dr["codVenta"].ToString();
                    }
                    else
                    {
                        objTransaccionCaja.codVenta = "";
                    }
                    objTransaccionCaja.codTipoTransaccion = Convert.ToInt32(dr["codTipoTransaccion"]);
                    objTransaccionCaja.tipoTransaccion = dr["tipoTransaccion"].ToString();
                    objTransaccionCaja.codModoPago = Convert.ToInt32(dr["codModoPago"]);
                    objTransaccionCaja.modoPago = dr["modoPago"].ToString();
                    objTransaccionCaja.codTipoMoneda = Convert.ToInt32(dr["codTipoMoneda"]);
                    objTransaccionCaja.tipoMoneda = dr["tipoMoneda"].ToString();
                    objTransaccionCaja.importe = Convert.ToDecimal(dr["importe"]);
                    objTransaccionCaja.marcaBaja = Convert.ToInt32(dr["marcaBaja"]);
                    listaTC.Add(objTransaccionCaja);


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

            return listaTC;

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

    }
}
