using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CAD
{
    public class CADPreventa
    {
        public List<CENPreventaCliente> buscarCliente(string cadena)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaCliente objCliente = null;
            List<CENPreventaCliente> lista = new List<CENPreventaCliente>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_buscar_cliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_cadena", SqlDbType.VarChar, 50).Value = cadena.Trim();
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCliente = new CENPreventaCliente();
                    objCliente.codCliente = Convert.ToInt32(dr["codCliente"]);
                    objCliente.nombres = dr["nombres"].ToString();
                    objCliente.tipoListaPrecio = Convert.ToInt32(dr["tipoListaPrecio"]);
                    objCliente.numDocumento = Convert.ToString(dr["numDocumento"]);
                    lista.Add(objCliente);
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
            return lista;
        }


        public List<CENPreventaPuntoEntrega> listarPuntosEntregaCliente(int codCliente)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaPuntoEntrega obj = null;
            List<CENPreventaPuntoEntrega> lista = new List<CENPreventaPuntoEntrega>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_listar_puntos_entrega", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_codcliente", SqlDbType.Int).Value = codCliente;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new CENPreventaPuntoEntrega();
                    obj.codPuntoEntrega = Convert.ToInt32(dr["codPuntoEntrega"]);
                    obj.descripcion = dr["descripcion"].ToString();
                    lista.Add(obj);
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
            return lista;
        }

        public List<CENPreventaProducto> listarProductos(string cadena)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaProducto obj = null;
            List<CENPreventaProducto> lista = new List<CENPreventaProducto>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_buscar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_cadena", SqlDbType.VarChar, 50).Value = cadena;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new CENPreventaProducto();
                    obj.codProducto = dr["codProducto"].ToString();
                    obj.descripcion = dr["descripcion"].ToString();
                    lista.Add(obj);
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
            return lista;
        }

        public CENPreventaProductoPrecio precioProducto(string codProducto, int tipoListaPrecio)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaProductoPrecio obj = null;
            //List<CENPreventaProductoPrecio> lista = new List<CENPreventaProductoPrecio>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_precio_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_codProducto", SqlDbType.VarChar, 50).Value = codProducto.Trim();
                cmd.Parameters.Add("@p_tipoListaPrecio", SqlDbType.Int).Value = tipoListaPrecio;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["flag"] != DBNull.Value && Convert.ToInt32(dr["flag"].ToString()) == 0)
                    {
                        obj = new CENPreventaProductoPrecio();
                        obj.precio = Convert.ToDouble(dr["precioVenta"].ToString());
                        obj.tipoProducto = Convert.ToInt32(dr["tipoProducto"].ToString());
                    }
                    
                    //lista.Add(obj);
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
            return obj;
        }

        public List<CENPreventaProductoPresentacion> presentacionProductos(string codProducto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaProductoPresentacion obj = null;
            List<CENPreventaProductoPresentacion> lista = new List<CENPreventaProductoPresentacion>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_presentacion_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_codProducto", SqlDbType.VarChar, 50).Value = codProducto;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new CENPreventaProductoPresentacion();
                    obj.codPresentacion = Convert.ToInt32(dr["codPresentancion"].ToString());
                    obj.descripcion = dr["descripcion"].ToString();
                    obj.cantidadUnidadBase = Convert.ToInt32(dr["cantidadUnidadBase"].ToString());
                    lista.Add(obj);
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
            return lista;
        }

        public List<CENPreventaProductoAlmacen> almacenProductos(string codProducto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaProductoAlmacen obj = null;
            List<CENPreventaProductoAlmacen> lista = new List<CENPreventaProductoAlmacen>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_almacenes_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_codProducto", SqlDbType.VarChar, 50).Value = codProducto;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new CENPreventaProductoAlmacen();
                    obj.codAlmacen = Convert.ToInt32(dr["codAlmacen"].ToString());
                    obj.descripcion = dr["descripcion"].ToString();
                    obj.stock = Convert.ToInt32(dr["stock"].ToString());
                    lista.Add(obj);
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
            return lista;
        }

        public CENPreventaRegistro registrarpreventa(CENPreventa Preventa)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DateTime fecha2 = DateTime.Now;
            TimeSpan hora = new TimeSpan();

            CENPreventaRegistro obj = null;
            //List<CENPreventaProductoAlmacen> lista = new List<CENPreventaProductoAlmacen>();
            CADConexion CadCx = new CADConexion();
            string xmlListDetalle = ObjectToXMLGeneric<List<CEN_Detalle_Preventa>>(Preventa.listDetPreventa); //XML de lista de detalles
            string xmlListPreventaProm = ObjectToXMLGeneric<List<CEN_Preventa_Promocion>>(Preventa.listPrevPromocion); //XML de lista de preventa promocion
            string xmlListPreventaDesc = ObjectToXMLGeneric<List<CEN_Preventa_Descuento>>(Preventa.listPrevDescuento); //XML de lista de preventa descuento
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_modificar_preventa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_proceso", SqlDbType.TinyInt).Value = Preventa.proceso;
                cmd.Parameters.Add("@p_ntraPreventa", SqlDbType.Int).Value = Preventa.ntraPreventa;
                cmd.Parameters.Add("@p_codCliente", SqlDbType.Int).Value = Preventa.codCliente;
                cmd.Parameters.Add("@p_codUsuario", SqlDbType.Int).Value = Preventa.codUsuario;
                cmd.Parameters.Add("@p_codPuntoEntrega", SqlDbType.Int).Value = Preventa.codPuntoEntrega;
                cmd.Parameters.Add("@p_tipoMoneda", SqlDbType.TinyInt).Value = Preventa.tipoMoneda;
                cmd.Parameters.Add("@p_tipoVenta", SqlDbType.TinyInt).Value = Preventa.tipoVenta;
                cmd.Parameters.Add("@p_tipoDocumentoVenta", SqlDbType.TinyInt).Value = Preventa.tipoDocumentoVenta;

                if (Preventa.fecha == null)
                    cmd.Parameters.Add("@p_fecha", SqlDbType.VarChar, 15).Value = "";
                else
                {
                    fecha2 = ConvertFechaStringToDate(Preventa.fecha);
                    cmd.Parameters.Add("@p_fecha", SqlDbType.Date).Value = fecha2;
                }


                if (Preventa.fechaEntrega == null)
                    cmd.Parameters.Add("@p_fechaEntrega", SqlDbType.VarChar, 15).Value = "";
                else
                {
                    fecha2 = ConvertFechaStringToDate(Preventa.fechaEntrega);
                    cmd.Parameters.Add("@p_fechaEntrega", SqlDbType.Date).Value = fecha2;
                }

                if (Preventa.fechaPago == null)
                    cmd.Parameters.Add("@p_fechaPago", SqlDbType.VarChar, 15).Value = "";
                else
                    cmd.Parameters.Add("@p_fechaPago", SqlDbType.Date).Value = Preventa.fechaPago;

                cmd.Parameters.Add("@p_flagRecargo", SqlDbType.TinyInt).Value = Preventa.flagRecargo;
                cmd.Parameters.Add("@p_recargo", SqlDbType.Money).Value = Preventa.recargo;
                cmd.Parameters.Add("@p_igv", SqlDbType.Money).Value = Preventa.igv;
                cmd.Parameters.Add("@p_isc", SqlDbType.Money).Value = Preventa.isc;
                cmd.Parameters.Add("@p_total", SqlDbType.Money).Value = Preventa.total;
                cmd.Parameters.Add("@p_estado", SqlDbType.TinyInt).Value = Preventa.estado;
                cmd.Parameters.Add("@p_origenVenta", SqlDbType.TinyInt).Value = Preventa.origenVenta;
                cmd.Parameters.Add("@p_listaDetalles", SqlDbType.Xml).Value = xmlListDetalle;
                cmd.Parameters.Add("@p_listaPreventaPromocion", SqlDbType.Xml).Value = xmlListPreventaProm;
                cmd.Parameters.Add("@p_listaPreventaDescuento", SqlDbType.Xml).Value = xmlListPreventaDesc;

                if (Preventa.usuario == null)
                    cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar, 20).Value = "";
                else
                    cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar, 20).Value = Preventa.usuario.Trim();

                if (Preventa.ip == null)
                    cmd.Parameters.Add("@p_ip", SqlDbType.VarChar, 20).Value = "";
                else
                    cmd.Parameters.Add("@p_ip", SqlDbType.VarChar, 20).Value = Preventa.ip.Trim();

                if (Preventa.mac == null)
                    cmd.Parameters.Add("@p_mac", SqlDbType.VarChar, 20).Value = "";
                else
                    cmd.Parameters.Add("@p_mac", SqlDbType.VarChar, 20).Value = Preventa.mac.Trim();

                if (Preventa.horaEntrega == null)
                    cmd.Parameters.Add("@p_horaEntrega", SqlDbType.VarChar, 10).Value = "";
                else
                {
                    hora = TimeSpan.Parse(Preventa.horaEntrega);
                    cmd.Parameters.Add("@p_horaEntrega", SqlDbType.Time).Value = hora;
                }

                cmd.Parameters.Add("@p_codSucursal", SqlDbType.Int).Value = Preventa.codSucursal;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new CENPreventaRegistro();
                    obj.ntraPreventa = int.Parse(dr["ntraPreventa"].ToString());
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
            return obj;
        }

        public DateTime ConvertFechaStringToDate(string fecha)
        {
            CultureInfo MyCultureInfo = new CultureInfo("es-PE");
            DateTime myDate = DateTime.ParseExact(fecha, "dd/MM/yyyy", MyCultureInfo);
            return myDate;

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

        public CENPreventaParametros parametrosPreventa()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaParametros obj = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_parametros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@p_codProducto", SqlDbType.VarChar, 50).Value = codProducto;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["flag"] != DBNull.Value && Convert.ToInt32(dr["flag"].ToString()) == 0)
                    {
                        obj = new CENPreventaParametros();
                        obj.igv = Convert.ToDouble(dr["igv"].ToString());
                        obj.flagRecargo = Convert.ToInt32(dr["flagRecargo"].ToString());
                        obj.porcentajeRecargo = Convert.ToDouble(dr["porcentajeRecargo"].ToString());
                    }
                        
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
            return obj;
        }

        public List<CENPreventaPromocionProducto> obtenerPromocionesProducto(CENPreventaPromocionParametro parametro)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaPromocionProducto obj = null;
            List<CENPreventaPromocionProducto> lista = new List<CENPreventaPromocionProducto>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_promociones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_codProducto", SqlDbType.VarChar, 50).Value = parametro.codProducto.Trim();
                cmd.Parameters.Add("@p_codCliente", SqlDbType.Int).Value = parametro.codCliente;
                cmd.Parameters.Add("@p_codUsuario", SqlDbType.Int).Value = parametro.codUsuario;
                cmd.Parameters.Add("@p_tipoVenta", SqlDbType.Int).Value = parametro.tipoVenta;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new CENPreventaPromocionProducto();
                    obj.ntraPromocion = Convert.ToInt32(dr["ntraPromocion"]);
                    obj.valor = Convert.ToDouble(dr["valor"]);
                    obj.tipo = Convert.ToInt32(dr["tipo"]);
                    obj.descPromocion = dr["descPromocion"].ToString();
                    lista.Add(obj);
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
            return lista;
        }

        public List<CENPreventaProductosRegalo> obtenerProductosRegalo(int ntraPromocion)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaProductosRegalo obj = null;
            List<CENPreventaProductosRegalo> lista = new List<CENPreventaProductosRegalo>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_productos_promocion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_ntraPromocion", SqlDbType.Int).Value = ntraPromocion;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new CENPreventaProductosRegalo();
                    obj.valorEntero1 = Convert.ToInt32(dr["valorEntero1"]);
                    obj.valorEntero2 = Convert.ToInt32(dr["valorEntero2"]);
                    obj.valorMoneda1 = Convert.ToDouble(dr["valorMoneda1"]);
                    obj.valorCadena1 = dr["valorCadena1"].ToString();
                    obj.codUnidadBase = Convert.ToInt32(dr["codUnidadBase"]);
                    obj.descProducto = dr["descProducto"].ToString();
                    obj.descUnidadBase = dr["descUnidadBase"].ToString();
                    obj.descAlmacen = dr["descAlmacen"].ToString();
                    lista.Add(obj);
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
            return lista;
        }

        //DESCUENTOS
        public List<CENPreventaDescuentosProducto> obtenerDescuentosProducto(CENPreventaDescuentoParametro parametro)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENPreventaDescuentosProducto obj = null;
            List<CENPreventaDescuentosProducto> lista = new List<CENPreventaDescuentosProducto>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_preventa_descuentos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_codProducto", SqlDbType.VarChar, 50).Value = parametro.codProducto.Trim();
                cmd.Parameters.Add("@p_codCliente", SqlDbType.Int).Value = parametro.codCliente;
                cmd.Parameters.Add("@p_codUsuario", SqlDbType.Int).Value = parametro.codUsuario;
                cmd.Parameters.Add("@p_tipoVenta", SqlDbType.Int).Value = parametro.tipoVenta;
                cmd.Parameters.Add("@p_tipoDescuento", SqlDbType.Int).Value = parametro.tipoDescuento;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new CENPreventaDescuentosProducto();
                    obj.ntraDescuento = Convert.ToInt32(dr["ntraDescuento"]);
                    obj.valor = Convert.ToDouble(dr["valor"]);
                    obj.tipo = Convert.ToInt32(dr["tipo"]);
                    obj.tipoDescuento = Convert.ToInt32(dr["tipoDescuento"]);
                    obj.valorDescuento = Convert.ToDouble(dr["valorDescuento"]);
                    obj.descDescuento = dr["descDescuento"].ToString();
                    lista.Add(obj);
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
            return lista;
        }


        //-----------------------------------------------------------------------------------------
        //DESCRIPCION: Anular prevnta por codigo de preventa
        public CENMensajePreventa AnularPreventa(int npre)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            CENMensajePreventa objCENMensajePreventa = new CENMensajePreventa();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_anular_preventa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_ntraPreventa", SqlDbType.Int).Value = npre;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCENMensajePreventa.codigo = Convert.ToInt32(dr["flag"]);
                    objCENMensajePreventa.mensaje = Convert.ToString(dr["msje"]);
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
            return objCENMensajePreventa;
        }

        //DESCRIPCION: Listar detalle por preventa
        public List<CENDetallePreventa> ListarDetalle(int npre)
        {
            List<CENDetallePreventa> listaDetalle = new List<CENDetallePreventa>();
            CENDetallePreventa objCENDetallePreventa = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_preventa_detalle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@npreventa", SqlDbType.Int).Value = npre;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCENDetallePreventa = new CENDetallePreventa();
                    objCENDetallePreventa.item = Convert.ToInt32(dr["item"]);
                    objCENDetallePreventa.codProducto = Convert.ToString(dr["codProducto"]);
                    objCENDetallePreventa.descripcion = Convert.ToString(dr["descripcion"]);
                    objCENDetallePreventa.cantidad = Convert.ToInt32(dr["cantidad"]);
                    objCENDetallePreventa.um = Convert.ToString(dr["um"]);
                    objCENDetallePreventa.precio = Decimal.Round(Convert.ToDecimal(dr["precio"]), CENConstante.g_const_2);
                    objCENDetallePreventa.descuento = Decimal.Round(Convert.ToDecimal(dr["descuento"]), CENConstante.g_const_2);
                    objCENDetallePreventa.tipo = Convert.ToString(dr["tipo"]);
                    objCENDetallePreventa.codDec = Convert.ToInt32(dr["codDec"]);
                    objCENDetallePreventa.codPro = Convert.ToInt32(dr["codPro"]);
                    objCENDetallePreventa.descrDesc = Convert.ToString(dr["descrDesc"]);
                    objCENDetallePreventa.descrPro = Convert.ToString(dr["descrPro"]);
                    objCENDetallePreventa.cantidadUnidadBase = Convert.ToInt32(dr["cantidadUnidadBase"]);
                    objCENDetallePreventa.codAlmacen = Convert.ToInt32(dr["codAlmacen"]);
                    objCENDetallePreventa.descAlmacen = Convert.ToString(dr["descAlmacen"]);
                    objCENDetallePreventa.codUnidad = Convert.ToInt32(dr["codUnidad"]);
                    objCENDetallePreventa.codTipo = Convert.ToInt32(dr["codTipo"]);
                    objCENDetallePreventa.codProdPrincipal = Convert.ToString(dr["codProdPrincipal"]);
                    objCENDetallePreventa.itempreventa = Convert.ToInt32(dr["itempreventa"]);

                    listaDetalle.Add(objCENDetallePreventa);
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
            return listaDetalle;
        }

        //DESCRIPCION: Obtener la lista de preventas
        public List<CENPreventaLista> ListarPreventa(CENPreventaDatos datos)
        {
            List<CENPreventaLista> list_preventa = new List<CENPreventaLista>();
            CENPreventaLista objPreventaLista = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_preventa_filtros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ntraPreventa", SqlDbType.Int).Value = datos.ntraPreventa;
                cmd.Parameters.Add("@codUsuario", SqlDbType.Int).Value = datos.codUsuario;
                cmd.Parameters.Add("@codCliente", SqlDbType.Int).Value = datos.codCliente;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = datos.estado;
                cmd.Parameters.Add("@codTipo_venta", SqlDbType.Int).Value = datos.codTipo_venta;
                cmd.Parameters.Add("@codTipo_doc", SqlDbType.Int).Value = datos.codTipo_doc;
                cmd.Parameters.Add("@codRuta", SqlDbType.Int).Value = datos.codRuta;
                cmd.Parameters.Add("@codProveedor", SqlDbType.Int).Value = datos.codProveedor;
                cmd.Parameters.Add("@codProducto", SqlDbType.Char).Value = datos.codProducto;
                cmd.Parameters.Add("@codOrigen_venta", SqlDbType.Int).Value = datos.codOrigen_venta;

                if (datos.codfechaEntregaI == "")
                {
                    cmd.Parameters.Add("@codfechaEntregaI", SqlDbType.Char).Value = datos.codfechaEntregaI;
                }
                else
                {
                    cmd.Parameters.Add("@codfechaEntregaI", SqlDbType.Date).Value = ConvertFechaStringToDate(datos.codfechaEntregaI);
                }
                if (datos.codfechaEntregaF == "")
                {
                    cmd.Parameters.Add("@codfechaEntregaF", SqlDbType.Char).Value = datos.codfechaEntregaF;
                }
                else
                {
                    cmd.Parameters.Add("@codfechaEntregaF", SqlDbType.Date).Value = ConvertFechaStringToDate(datos.codfechaEntregaF);
                }
                if (datos.codfechaRegistroI == "")
                {
                    cmd.Parameters.Add("@codfechaRegistroI", SqlDbType.Char).Value = datos.codfechaRegistroI;
                }
                else
                {
                    cmd.Parameters.Add("@codfechaRegistroI", SqlDbType.Date).Value = ConvertFechaStringToDate(datos.codfechaRegistroI);
                }
                if (datos.codfechaRegistroF == "")
                {
                    cmd.Parameters.Add("@codfechaRegistroF", SqlDbType.Char).Value = datos.codfechaRegistroF;
                }
                else
                {
                    cmd.Parameters.Add("@codfechaRegistroF", SqlDbType.Date).Value = ConvertFechaStringToDate(datos.codfechaRegistroF);
                }

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objPreventaLista = new CENPreventaLista();
                    objPreventaLista.ntraPreventa = Convert.ToInt32(dr["ntraPreventa"]);
                    objPreventaLista.vendedor = Convert.ToString(dr["vendedor"]);
                    objPreventaLista.cliente = Convert.ToString(dr["cliente"]);
                    objPreventaLista.ruta = Convert.ToString(dr["ruta"]);
                    objPreventaLista.PuntoEntrega = Convert.ToString(dr["direccion"]);
                    objPreventaLista.Tventa = Convert.ToString(dr["tVenta"]);
                    objPreventaLista.Tdoc = Convert.ToString(dr["tDoc"]);
                    objPreventaLista.Oven = Convert.ToString(dr["oVenta"]);
                    objPreventaLista.estado = Convert.ToString(dr["estPre"]);
                    objPreventaLista.FechaR = Convert.ToDateTime(dr["fecha"]).ToString("dd/MM/yyyy");
                    objPreventaLista.FechaE = Convert.ToDateTime(dr["fechaEntrega"]).ToString("dd/MM/yyyy");
                    objPreventaLista.recargo = Decimal.Round(Convert.ToDecimal(dr["recargo"]), CENConstante.g_const_2);
                    objPreventaLista.igv = Decimal.Round(Convert.ToDecimal(dr["igv"]), CENConstante.g_const_2);
                    objPreventaLista.moneda = Convert.ToString(dr["moneda"]);
                    objPreventaLista.total = Decimal.Round(Convert.ToDecimal(dr["total"]), CENConstante.g_const_2);
                    objPreventaLista.sucursal = Convert.ToString(dr["sucursal"]);
                    objPreventaLista.tipoPersona = Convert.ToInt32(dr["tipoPersona"]);
                    objPreventaLista.identificacion = Convert.ToString(dr["identificacion"]);
                    objPreventaLista.codestado = Convert.ToInt32(dr["estado"]);
                    objPreventaLista.codUbigeo = Convert.ToString(dr["codUbigeo"]);
                    objPreventaLista.codUsuario = Convert.ToInt32(dr["codUsuario"]);
                    objPreventaLista.codCliente = Convert.ToInt32(dr["codCliente"]);
                    objPreventaLista.codPuntoEntrega = Convert.ToInt32(dr["codPuntoEntrega"]);
                    list_preventa.Add(objPreventaLista);
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
            return list_preventa;
        }

        //DESCRIPCION: Traer las listas para los campos de los filtros
        public List<CENCamposPreventa> ListarCampos(int flag)
        {
            List<CENCamposPreventa> listaCampos = new List<CENCamposPreventa>();
            CENCamposPreventa objCENCamposPreventa = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_preventa_campos_x_flag", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCENCamposPreventa = new CENCamposPreventa();
                    objCENCamposPreventa.codigo = Convert.ToInt32(dr["codigo"]);
                    objCENCamposPreventa.descripcion = Convert.ToString(dr["descripcion"]);
                    listaCampos.Add(objCENCamposPreventa);
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
            return listaCampos;
        }

        //DESCRIPCION: Listar en los campos de filtros los conceptos
        public List<CENConceptos> ListarConcepto(int flag)
        {
            List<CENConceptos> listaConcepto = new List<CENConceptos>();
            CENConceptos objCENConceptos = null;
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
                    objCENConceptos = new CENConceptos();
                    objCENConceptos.correlativo = Convert.ToInt32(dr["correlativo"]);
                    objCENConceptos.descripcion = Convert.ToString(dr["descripcion"]);
                    listaConcepto.Add(objCENConceptos);
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

            return listaConcepto;
        }

        //Validar el campo fecha de registro no sea mayor del parametro de dias maximo
        public CENMensajePreventa validarFechaRegistro(string fechari, string fecharf)
        {
            CENMensajePreventa objCENMensajePreventa = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_validar_preventa_fechaR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (fechari == "")
                {
                    cmd.Parameters.Add("@codfechaRegistroI", SqlDbType.Char).Value = fechari;
                }
                else
                {
                    cmd.Parameters.Add("@codfechaRegistroI", SqlDbType.Date).Value = ConvertFechaStringToDate(fechari);
                }
                if (fecharf == "")
                {
                    cmd.Parameters.Add("@codfechaRegistroF", SqlDbType.Char).Value = fecharf;
                }
                else
                {
                    cmd.Parameters.Add("@codfechaRegistroF", SqlDbType.Date).Value = ConvertFechaStringToDate(fecharf);
                }

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCENMensajePreventa = new CENMensajePreventa();
                    objCENMensajePreventa.codigo = Convert.ToInt32(dr["codMsj"]);
                    objCENMensajePreventa.mensaje = Convert.ToString(dr["mensaje"]);
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

            return objCENMensajePreventa;
        }

        //Obtener la descripcion del ubigeo.
        public CENCamposPreventa obtenerUbigeo(string codubigeo)
        {
            CENCamposPreventa objCENCamposPreventa = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_obtener_descripcion_ubigeo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codUbigeo", SqlDbType.Char).Value = codubigeo;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCENCamposPreventa = new CENCamposPreventa();
                    objCENCamposPreventa.codigo = Convert.ToInt32(dr["codigo"]);
                    objCENCamposPreventa.descripcion = Convert.ToString(dr["descripcion"]);
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
            return objCENCamposPreventa;
        }

        //Obtener datos de la preventa.
        public CENObtenerPreventa obtenerPreventa(string npre)
        {
            CENObtenerPreventa objCENObtenerPreventa = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_obtener_preventa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@npre", SqlDbType.Int).Value = Convert.ToInt32(npre);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCENObtenerPreventa = new CENObtenerPreventa();
                    objCENObtenerPreventa.ntraPreventa = Convert.ToInt32(dr["ntraPreventa"]);
                    objCENObtenerPreventa.codUsuario = Convert.ToInt32(dr["codUsuario"]);
                    objCENObtenerPreventa.codCliente = Convert.ToInt32(dr["codCliente"]);
                    objCENObtenerPreventa.tipoVenta = Convert.ToInt32(dr["tipoVenta"]);
                    objCENObtenerPreventa.tipoDocumentoVenta = Convert.ToInt32(dr["tipoDocumentoVenta"]);
                    objCENObtenerPreventa.fechaEntrega = Convert.ToDateTime(dr["fechaEntrega"]).ToString("dd/MM/yyyy");
                    objCENObtenerPreventa.horaEntrega = Convert.ToString(dr["horaEntrega"]);
                    objCENObtenerPreventa.codPuntoEntrega = Convert.ToInt32(dr["codPuntoEntrega"]);
                    objCENObtenerPreventa.cliente = Convert.ToString(dr["cliente"]);
                    objCENObtenerPreventa.identificacion = Convert.ToString(dr["identificacion"]);
                    objCENObtenerPreventa.direccion = Convert.ToString(dr["direccion"]);
                    objCENObtenerPreventa.tipoListaPrecio = Convert.ToInt32(dr["tipoListaPrecio"]);
                    objCENObtenerPreventa.flagRecargo = Convert.ToInt32(dr["flagRecargo"]);
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
            return objCENObtenerPreventa;
        }



        public List<CENProductolista> ListarProductosCombo(int flag)
        {
            List<CENProductolista> listaProducto = new List<CENProductolista>();
            CENProductolista objCENProductolista = null;

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_preventa_campos_x_flag", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    objCENProductolista = new CENProductolista();
                    objCENProductolista.codigo = Convert.ToString(dr["codigo"]);
                    objCENProductolista.descripcion = Convert.ToString(dr["descripcion"]);
                    listaProducto.Add(objCENProductolista);
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
            return listaProducto;
        }





    }
}
