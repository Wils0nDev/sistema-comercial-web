using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class CADDescuento
    {
        public List<CENConceptoDescuento> ListarCoceptos(int flag)
        {
            List<CENConceptoDescuento> listconcepto = new List<CENConceptoDescuento>();
            CENConceptoDescuento objConcepto = null;

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
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
                    objConcepto = new CENConceptoDescuento();
                    objConcepto.correlativo = Convert.ToInt32(dr["ntraUsuario"]);
                    objConcepto.descripcion = Convert.ToString(dr["vendedor"]);
                    listconcepto.Add(objConcepto);
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
            return listconcepto;
        }

        public List<CENConceptoDescuento> ListarEstado(int flag)
        {
            List<CENConceptoDescuento> listconcepto = new List<CENConceptoDescuento>();
            CENConceptoDescuento objConcepto = null;

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
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
                    objConcepto = new CENConceptoDescuento();
                    objConcepto.correlativo = Convert.ToInt32(dr["codigo"]);
                    objConcepto.descripcion = Convert.ToString(dr["descripcion"]);
                    listconcepto.Add(objConcepto);
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
            return listconcepto;
        }

        public List<CENProductolista> ListarProductosTipo(string cadena)
        {
            List<CENProductolista> listProducto = new List<CENProductolista>();
            CENProductolista objProducto = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_producto_tipo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_cadena", SqlDbType.VarChar,50).Value = cadena;
                cmd.Parameters.Add("@p_tipo", SqlDbType.Int).Value = CENConstante.g_const_1;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objProducto = new CENProductolista();
                    objProducto.codigo = Convert.ToString(dr["codProducto"]);
                    objProducto.descripcion = Convert.ToString(dr["descripcion"]);
                    listProducto.Add(objProducto);
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
            return listProducto;
        }

        public CENConceptoDescuento obtenerUnidadBaseProducto(string codProducto)
        {
            CENConceptoDescuento objProducto = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_producto_obtener_unidadbase", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codProducto", SqlDbType.VarChar, 10).Value = codProducto;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objProducto = new CENConceptoDescuento();
                    objProducto.correlativo = Convert.ToInt32(dr["codUnidadBaseventa"]);
                    objProducto.descripcion = Convert.ToString(dr["descripcion"]);
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
            return objProducto;
        }

        public List<CENListarDescuento> ListarDescuento(string codProd, int codVendedor, int codCliente, int codEstado, string codFechaI, string codFechaF)
        {
            List<CENListarDescuento> listaDeatlle = new List<CENListarDescuento>();
            CENListarDescuento objlistadescuento = null;

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_descuento_listar_filtros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codProducto", SqlDbType.VarChar,10).Value = codProd;
                cmd.Parameters.Add("@codVendedor", SqlDbType.Int).Value = codVendedor;
                cmd.Parameters.Add("@codCliente", SqlDbType.Int).Value = codCliente;
                cmd.Parameters.Add("@codEstado", SqlDbType.Int).Value = codEstado;
                if (codFechaI == "")
                {
                    cmd.Parameters.Add("@codfechaI", SqlDbType.Char).Value = codFechaI;
                }
                else
                {
                    cmd.Parameters.Add("@codfechaI", SqlDbType.Date).Value = ConvertFechaStringToDate(codFechaI);
                }

                if (codFechaF == "")
                {
                    cmd.Parameters.Add("@codfechaF", SqlDbType.Char).Value = codFechaF;
                }
                else
                {
                    cmd.Parameters.Add("@codfechaF", SqlDbType.Date).Value = ConvertFechaStringToDate(codFechaF);
                }

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objlistadescuento = new CENListarDescuento();
                    objlistadescuento.ntraDescuento = Convert.ToInt32(dr["ntraDescuento"]);
                    objlistadescuento.descripcion = Convert.ToString(dr["descripcion"]);
                    objlistadescuento.codProd = Convert.ToString(dr["codProd"]);
                    objlistadescuento.desProd = Convert.ToString(dr["desProd"]);
                    objlistadescuento.codUnidad = Convert.ToInt32(dr["codUnidad"]);
                    objlistadescuento.desUnidad = Convert.ToString(dr["desUnidad"]);
                    objlistadescuento.fechaInicial = Convert.ToDateTime(dr["fechaInicial"]).ToString("dd/MM/yyyy");
                    objlistadescuento.fechaFin = Convert.ToDateTime(dr["fechaFin"]).ToString("dd/MM/yyyy");
                    objlistadescuento.horaInicial = Convert.ToString(dr["horaInicial"]);
                    objlistadescuento.horaFin = Convert.ToString(dr["horaFin"]);
                    objlistadescuento.codEstado = Convert.ToInt32(dr["codEstado"]);
                    objlistadescuento.desEstado = Convert.ToString(dr["desEstado"]);
                    objlistadescuento.cant = Convert.ToDecimal(dr["cant"]);
                    objlistadescuento.tipoCant = Convert.ToInt32(dr["tipoCant"]);
                    objlistadescuento.descuento = Convert.ToDecimal(dr["descuento"]);
                    objlistadescuento.tipodesc = Convert.ToInt32(dr["tipodesc"]);
                    objlistadescuento.codVen = Convert.ToInt32(dr["codVen"]);
                    objlistadescuento.vendedor = Convert.ToString(dr["vendedor"]);
                    objlistadescuento.codCli = Convert.ToInt32(dr["codCli"]);
                    objlistadescuento.cliente = Convert.ToString(dr["cliente"]);
                    objlistadescuento.vecesDes = Convert.ToInt32(dr["vecesDes"]);
                    objlistadescuento.vecesVen = Convert.ToInt32(dr["vecesVen"]);
                    objlistadescuento.vecesCli = Convert.ToInt32(dr["vecesCli"]);

                    listaDeatlle.Add(objlistadescuento);
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
            return listaDeatlle;
        }

        public CENMensajeDescuento registrarDescuento(CENRegistrarDescuento datos)
        {
            CENMensajeDescuento mensajeRegistrar = null;

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            TimeSpan horaI = new TimeSpan();
            TimeSpan horaF = new TimeSpan();
            try
            {
                horaI = TimeSpan.Parse(datos.horaI);
                horaF = TimeSpan.Parse(datos.horaF);

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_descuento_registrar_modificar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@proceso", SqlDbType.Int).Value = datos.proceso;
                cmd.Parameters.Add("@fechaVigenciaI", SqlDbType.Date).Value = ConvertFechaStringToDate(datos.fechaVigenciaI);
                cmd.Parameters.Add("@fechaVigenciaF", SqlDbType.Date).Value = ConvertFechaStringToDate(datos.fechaVigenciaF);
                cmd.Parameters.Add("@horaI", SqlDbType.Time).Value = horaI;
                cmd.Parameters.Add("@horaF", SqlDbType.Time).Value = horaF;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = datos.flagestado;
                cmd.Parameters.Add("@codTipo_venta", SqlDbType.Int).Value = datos.codTipo_venta;
                cmd.Parameters.Add("@codProducto", SqlDbType.Char).Value = datos.codProducto;
                cmd.Parameters.Add("@codUnidadBase", SqlDbType.Int).Value = datos.codUnidadBase;
                cmd.Parameters.Add("@codCantidad", SqlDbType.Int).Value = datos.codCantidad;
                cmd.Parameters.Add("@tipoCant", SqlDbType.Int).Value = datos.tipoCant;
                cmd.Parameters.Add("@codMonto", SqlDbType.Decimal).Value = datos.codMonto;
                cmd.Parameters.Add("@codTipoMonto", SqlDbType.Int).Value = datos.codTipoMonto;
                cmd.Parameters.Add("@codVendedorReg", SqlDbType.Int).Value = datos.codVendedorReg;
                cmd.Parameters.Add("@codCliente_reg", SqlDbType.Int).Value = datos.codCliente_reg;
                cmd.Parameters.Add("@cod_veces_dec", SqlDbType.Int).Value = datos.cod_veces_dec;
                cmd.Parameters.Add("@cod_veces_vend", SqlDbType.Int).Value = datos.cod_veces_vend;
                cmd.Parameters.Add("@cod_veces_clie", SqlDbType.Int).Value = datos.cod_veces_clie;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar,250).Value = datos.descripcion;
                cmd.Parameters.Add("@ntraDescuento", SqlDbType.Int).Value = datos.ntraDescuento;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mensajeRegistrar = new CENMensajeDescuento();
                    mensajeRegistrar.flag = Convert.ToInt32(dr["flag"]);
                    mensajeRegistrar.mensaje = Convert.ToString(dr["mensaje"]);
                    mensajeRegistrar.ntraDescuento = Convert.ToInt32(dr["ntraDescuento"]);
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
            return mensajeRegistrar;
        }

        public CENMensajeDescuento cambiarEstado(int idDesc, int estado)
        {
            CENMensajeDescuento mensajEstado = null;

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_descuento_activar_desactivar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idDescuento", SqlDbType.Int).Value = idDesc;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = estado;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    mensajEstado = new CENMensajeDescuento();
                    mensajEstado.flag = Convert.ToInt32(dr["flag"]);
                    mensajEstado.mensaje = Convert.ToString(dr["mensaje"]);
                    mensajEstado.ntraDescuento = Convert.ToInt32(dr["ntraDescuento"]);
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
            return mensajEstado;
        }

        public DateTime ConvertFechaStringToDate(string fecha)
        {
            try
            {
                CultureInfo MyCultureInfo = new CultureInfo(CENConstante.g_const_es_PE);
                DateTime myDate = DateTime.ParseExact(fecha, CENConstante.g_const_formfech, MyCultureInfo);
                return myDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //------------------------------------------------------------------------------
        public List<CENProductolista> ListarProductosTipo2(string cadena)
        {
            List<CENProductolista> listProducto = new List<CENProductolista>();
            CENProductolista objProducto = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_producto_tipo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_cadena", SqlDbType.VarChar, 50).Value = cadena;
                cmd.Parameters.Add("@p_tipo", SqlDbType.Int).Value = CENConstante.g_const_2;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objProducto = new CENProductolista();
                    objProducto.codigo = Convert.ToString(dr["codProducto"]);
                    objProducto.descripcion = Convert.ToString(dr["descripcion"]);
                    listProducto.Add(objProducto);
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
            return listProducto;
        }




    }
}
