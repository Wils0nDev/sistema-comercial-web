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
    public class CADNotaCredito
    {
        public List<CENNotaCreditoVenta> buscarVentas(CENNotaCreditoParametroBuscarVenta parametros)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoVenta objeto = null;
            List<CENNotaCreditoVenta> lista = new List<CENNotaCreditoVenta>();
            CADConexion CadCx = new CADConexion();
            DateTime fecha = DateTime.Now;

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_buscar_ventas", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros.codVenta != null)
                {
                    if (parametros.codVenta.Length > 0)
                        cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = Convert.ToInt32(parametros.codVenta);
                }

                if (parametros.serie != null)
                {
                    if (parametros.serie.Length > 0)
                        cmd.Parameters.Add("@p_serie", SqlDbType.VarChar, 20).Value = parametros.serie;
                }

                if (parametros.numero != null)
                {
                    if (parametros.numero.Length > 0)
                        cmd.Parameters.Add("@p_numero", SqlDbType.Int).Value = Convert.ToInt32(parametros.numero);
                }

                if (parametros.fechaInicio != null)
                {
                    if (parametros.fechaInicio.Length > 0)
                    {
                        fecha = ConvertFechaStringToDate(parametros.fechaInicio);
                        cmd.Parameters.Add("@p_fechaInicio", SqlDbType.Date).Value = fecha;
                    }
                }

                if (parametros.fechaFin != null)
                {
                    if (parametros.fechaFin.Length > 0)
                    {
                        fecha = ConvertFechaStringToDate(parametros.fechaFin);
                        cmd.Parameters.Add("@p_fechaFin", SqlDbType.Date).Value = fecha;
                    }
                }

                if (parametros.codCliente != null)
                {
                    if (parametros.codCliente.Length > 0)
                        cmd.Parameters.Add("@p_codCliente", SqlDbType.Int).Value = Convert.ToInt32(parametros.codCliente);
                }

                if (parametros.codVendedor != null)
                {
                    if (parametros.codVendedor.Length > 0 && parametros.codVendedor != "0")
                        cmd.Parameters.Add("@p_codVendedor", SqlDbType.Int).Value = Convert.ToInt32(parametros.codVendedor);
                }

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoVenta();
                    objeto.ntraVenta = Convert.ToInt32(dr["ntraVenta"]);
                    objeto.nombres = dr["nombres"].ToString();
                    lista.Add(objeto);
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

        public DateTime ConvertFechaStringToDate(string fecha)
        {
            CultureInfo MyCultureInfo = new CultureInfo("es-PE");
            DateTime myDate = DateTime.ParseExact(fecha, "dd/MM/yyyy", MyCultureInfo);
            return myDate;

        }

        public CENNotaCreditoDatosVenta obtenerVenta(int codigo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoDatosVenta objeto = null;
            //List<CENNotaCreditoDatosVenta> lista = new List<CENNotaCreditoDatosVenta>();
            CADConexion CadCx = new CADConexion();
            DateTime fecha = DateTime.Now;

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_obtener_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoDatosVenta();
                    objeto.ntraVenta = Convert.ToInt32(dr["ntraVenta"]);
                    objeto.nomCliente = dr["nomCliente"].ToString();
                    objeto.tipoCambio = Convert.ToDouble(dr["tipoCambio"]);
                    objeto.serie = dr["serie"].ToString();
                    objeto.nroDocumento = Convert.ToInt32(dr["nroDocumento"]);
                    objeto.nomVendedor = dr["nomVendedor"].ToString();
                    objeto.importeTotal = Convert.ToDouble(dr["importeTotal"]);
                    objeto.importeRecargo = Convert.ToDouble(dr["importeRecargo"]);
                    objeto.tipoVenta = Convert.ToInt32(dr["tipoVenta"]);
                    //lista.Add(objeto);
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
            return objeto;
        }

        public List<CENNotaCreditoDatosDetalleVenta> obtenerDetalleVenta(int codigo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoDatosDetalleVenta objeto = null;
            List<CENNotaCreditoDatosDetalleVenta> lista = new List<CENNotaCreditoDatosDetalleVenta>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_obtener_detalleventa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoDatosDetalleVenta();
                    objeto.itemVenta = Convert.ToInt32(dr["itemVenta"]);
                    objeto.codProducto = dr["codProducto"].ToString();
                    objeto.descProducto = dr["descProducto"].ToString();
                    objeto.cantidadPresentacion = Convert.ToInt32(dr["cantidadPresentacion"]);
                    objeto.cantidadUnidadBase = Convert.ToInt32(dr["cantidadUnidadBase"]);
                    objeto.precioVenta = Convert.ToDouble(dr["precioVenta"]);
                    objeto.descAlmacen = dr["descAlmacen"].ToString();
                    objeto.descUnidadBase = dr["descUnidadBase"].ToString();
                    objeto.tipoProducto = Convert.ToInt32(dr["tipoProducto"]);
                    objeto.descTipoProducto = dr["descTipProducto"].ToString();
                    objeto.descuento = Convert.ToDouble(dr["descuento"]);
                    objeto.descuento_disponible = Convert.ToDouble(dr["dsct_disponible"]);
                    objeto.can_disponible = Convert.ToInt32(dr["can_disponible"]);
                    objeto.can_devueltos = Convert.ToInt32(dr["can_devueltos"]);
                    lista.Add(objeto);
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

        public List<CENNotaCreditoMotivoNC> obtenerMotivosNC()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoMotivoNC objeto = null;
            List<CENNotaCreditoMotivoNC> lista = new List<CENNotaCreditoMotivoNC>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_obtener_motivos_nc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoMotivoNC();
                    objeto.codigoMotivo = dr["codigoMotivo"].ToString();
                    objeto.descripcion = dr["descripcion"].ToString();
                    lista.Add(objeto);
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

        public List<CENNotaCreditoVentaPromocion> obtenerVentaPromocion(int codigo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoVentaPromocion objeto = null;
            List<CENNotaCreditoVentaPromocion> lista = new List<CENNotaCreditoVentaPromocion>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_obtener_venta_promocion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoVentaPromocion();
                    objeto.codPromocion = Convert.ToInt32(dr["codPromocion"]);
                    objeto.itemVenta = Convert.ToInt32(dr["itemVenta"]);
                    objeto.itemPromocionado = Convert.ToInt32(dr["itemPromocionado"]);
                    lista.Add(objeto);
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

        public List<CENNotaCreditoVentaDescuento> obtenerVentaDescuento(int codigo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoVentaDescuento objeto = null;
            List<CENNotaCreditoVentaDescuento> lista = new List<CENNotaCreditoVentaDescuento>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_obtener_venta_descuento", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoVentaDescuento();
                    objeto.codDescuento = Convert.ToInt32(dr["codDescuento"]);
                    objeto.itemVenta = Convert.ToInt32(dr["itemVenta"]);
                    objeto.importe = Convert.ToDouble(dr["importe"]);
                    lista.Add(objeto);
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

        public CENNotaCreditoDatosPromocion obtenerValoresPromocion(int codigo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoDatosPromocion objeto = null;
            //List<CENNotaCreditoDatosVenta> lista = new List<CENNotaCreditoDatosVenta>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_habilita_promocion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoDatosPromocion();
                    objeto.valor = Convert.ToDouble(dr["valor"]);
                    objeto.tipo = Convert.ToInt32(dr["tipo"]);
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
            return objeto;
        }

        public CENNotaCreditoDatosDescuento obtenerValoresDescuento(int codigo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoDatosDescuento objeto = null;
            //List<CENNotaCreditoDatosVenta> lista = new List<CENNotaCreditoDatosVenta>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_habilita_descuento", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoDatosDescuento();
                    objeto.valor = Convert.ToDouble(dr["valor"]);
                    objeto.tipo = Convert.ToInt32(dr["tipo"]);
                    objeto.valorDescuento = Convert.ToInt32(dr["valorDescuento"]);
                    objeto.tipoDescuento = Convert.ToInt32(dr["tipoDescuento"]);
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
            return objeto;
        }

        public int registrarVentaN(CENNotaCredito nc)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            int ntraVN = 0;
            CADConexion CadCx = new CADConexion();
            string xmlListDetalle = ObjectToXMLGeneric<List<CENListaDevueltos>>(nc.listaDevueltos); //XML de lista de detalles
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_registrar_venta_negativo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = nc.codVenta;
                cmd.Parameters.Add("@p_listaDetalles", SqlDbType.Xml).Value = xmlListDetalle;
                cmd.Parameters.Add("@p_importe", SqlDbType.Money).Value = nc.importe;
                cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar, 20).Value = nc.usuario;
                cmd.Parameters.Add("@p_ip", SqlDbType.VarChar, 20).Value = nc.ip;
                cmd.Parameters.Add("@p_mac", SqlDbType.VarChar, 20).Value = nc.mac;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ntraVN = Convert.ToInt32(dr["ntraVN"]);
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
            return ntraVN;
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

        public CENNotaCreditoRptaRegistroNC registrarNotaCredito(CENNotaCredito nc, int ntraVN)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoRptaRegistroNC objeto = null;
            CADConexion CadCx = new CADConexion();
            DateTime fecha = DateTime.Now;
            try
            {
                con = new SqlConnection(CadCx.CxSQL());

                if (nc.tipo == 1) //total
                {
                    cmd = new SqlCommand("pa_notacredito_registrar_nc_total", con);
                }
                else //parcial
                {
                    cmd = new SqlCommand("pa_notacredito_registrar_nc_parcial", con);
                }

                cmd.CommandType = CommandType.StoredProcedure;

                if (nc.tipo == 1) //total
                {
                    cmd.Parameters.Add("@p_flagReversion", SqlDbType.Int).Value = nc.flagReversion;
                }

                cmd.Parameters.Add("@p_codVenta", SqlDbType.Int).Value = nc.codVenta;
                cmd.Parameters.Add("@p_codVentaNega", SqlDbType.Int).Value = ntraVN;
                cmd.Parameters.Add("@p_codMotivo", SqlDbType.Char, 2).Value = nc.codMotivo;

                fecha = ConvertFechaStringToDate(nc.fecha);
                cmd.Parameters.Add("@p_fecha", SqlDbType.Date).Value = fecha;

                cmd.Parameters.Add("@p_tipo", SqlDbType.Int).Value = nc.tipo;
                cmd.Parameters.Add("@p_importe", SqlDbType.Money).Value = nc.importe;
                cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar, 20).Value = nc.usuario;
                cmd.Parameters.Add("@p_ip", SqlDbType.VarChar, 20).Value = nc.ip;
                cmd.Parameters.Add("@p_mac", SqlDbType.VarChar, 20).Value = nc.mac;
                cmd.Parameters.Add("@p_codSucursal", SqlDbType.Int).Value = nc.codSucursal;
                cmd.Parameters.Add("@p_codUsuario", SqlDbType.Int).Value = nc.codUsuario;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string a;
                    objeto = new CENNotaCreditoRptaRegistroNC();
                    objeto.ntraNC = Convert.ToInt32(dr["ntraNC"]);
                    a = dr["msje"].ToString();
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
            return objeto;
        }


        public CENNotaCreditoCabeceraImpresion obtenerDatosCabeceraNC(int codNotaCredito)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoCabeceraImpresion objeto = null;
            CADConexion CadCx = new CADConexion();
            CAD_Consulta cadConsulta = new CAD_Consulta();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_impresion_cabecera_venta_nc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codNotaCredito", SqlDbType.Int).Value = codNotaCredito;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoCabeceraImpresion();
                    objeto.serieNC = dr["serieNC"].ToString();
                    objeto.numeroNC = Convert.ToInt32(dr["numeroNC"]);
                    objeto.tipoCambioNC = Convert.ToDouble(dr["tipoCambioNC"]);
                    objeto.fechaNC = cadConsulta.ConvertFechaDateToString(DateTime.Parse(dr["fechaNC"].ToString().Trim()));
                    objeto.tipoNC = dr["tipoNC"].ToString();
                    objeto.motivoNC = dr["motivoNC"].ToString();

                    objeto.serieV = dr["serieV"].ToString();
                    objeto.numeroV = Convert.ToInt32(dr["numeroV"]);
                    objeto.importeTotalV = Convert.ToDouble(dr["importeTotalV"]);
                    objeto.importeIgvV = Convert.ToDouble(dr["importeIgvV"]);
                    objeto.importeSubTotalV = Convert.ToDouble(dr["importeSubTotalV"]);

                    objeto.nombreC = dr["nombreC"].ToString();
                    objeto.nroDocumentoC = dr["nroDocumentoC"].ToString();


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
            return objeto;
        }

        public List<CENNotaCreditoDetalleImpresion> obtenerDatosDetalleNC(int codigo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoDetalleImpresion objeto = null;
            List<CENNotaCreditoDetalleImpresion> lista = new List<CENNotaCreditoDetalleImpresion>();
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_impresion_detalle_venta_nc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codNotaCredito", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoDetalleImpresion();
                    objeto.itemVenta = Convert.ToInt32(dr["itemVenta"]);
                    objeto.codProducto = dr["codProducto"].ToString();
                    objeto.descProducto = dr["descProducto"].ToString();
                    objeto.cantidad = Convert.ToInt32(dr["cantidad"]);
                    objeto.descUnidad = dr["descUnidad"].ToString();
                    objeto.precioVenta = Convert.ToDouble(dr["precioVenta"]);
                    objeto.descTipoProducto = dr["descTipoProducto"].ToString();
                    objeto.subTotal = Convert.ToDouble(dr["subTotal"]);
                    lista.Add(objeto);
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

        public CENNotaCreditoRptaValidacion validarVenta(int codigo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoRptaValidacion objeto = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_validar_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codigo", SqlDbType.Int).Value = codigo;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoRptaValidacion();
                    objeto.flag = Convert.ToInt32(dr["flag"]);
                    objeto.msje = dr["msje"].ToString();
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
            return objeto;
        }

        public CENNotaCreditoParametrosRpta obtenerParametros(CENNotaCreditoParametros p)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENNotaCreditoParametrosRpta objeto = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_obtener_parametros_x_flag_sucursal", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_flag", SqlDbType.Int).Value = p.flag;
                cmd.Parameters.Add("@p_codSucursal", SqlDbType.Int).Value = p.codSucursal;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENNotaCreditoParametrosRpta();
                    objeto.igv = Convert.ToDouble(dr["igv"]);
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
            return objeto;
        }

        public CENApiNC obtenerDatosSunat(int codVenta, int codNC, int codVentaN)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            CENApiNC objeto = null;
            List<CENNotaCreditoDatosDetalleVenta> lista = null;
            CENDetails detalle = null;
            string unidad = null;
            string tipAfeIgv = null;
            double mtoBaseIgv = 0;
            double porcentajeIgv = 0;
            double cal_igv = 0;
            double igv = 0;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_notacredito_obtener_datos_sunat", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_codVenta", SqlDbType.Int).Value = codVenta;
                cmd.Parameters.Add("@p_codNC", SqlDbType.Int).Value = codNC;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objeto = new CENApiNC();
                    objeto.tipDocAfectado = dr["tipDocAfec"].ToString();
                    objeto.numDocfectado = dr["serieDocAfec"].ToString() + "-" + dr["numeroDocAfec"].ToString();
                    objeto.codMotivo = dr["codMotivoNC"].ToString();
                    objeto.desMotivo = dr["desMotivoNC"].ToString();

                    objeto.serie = dr["serieNC"].ToString();
                    if (codNC == CENConstante.g_const_0)
                    {
                        objeto.fechaEmision = dr["fechaAfec"].ToString();
                        objeto.tipoDoc = dr["tipDocAfec"].ToString();
                        objeto.mtoImpVenta = Convert.ToDouble(dr["totalVentaAfec"]);
                        objeto.mtoIGV = Convert.ToDouble(dr["igvAfec"]);
                        objeto.totalImpuestos = Convert.ToDouble(dr["igvAfec"]);
                    }
                    else
                    {
                        objeto.fechaEmision = dr["fechaEmisionNC"].ToString();
                        objeto.tipoDoc = dr["tipoDocNC"].ToString();
                        objeto.mtoImpVenta = Convert.ToDouble(dr["mtoImpVentaNC"]);
                        objeto.mtoIGV = Convert.ToDouble(dr["mtoIGVNC"]);
                        objeto.totalImpuestos = Convert.ToDouble(dr["mtoIGVNC"]);
                    }


                    objeto.correlativo = dr["correlativoNC"].ToString();
                    objeto.tipoMoneda = dr["tipoMoneda"].ToString();
                    objeto.client.tipoDoc = dr["tipoDocClient"].ToString();
                    objeto.client.numDoc = dr["numDocCliente"].ToString();
                    objeto.client.rznSocial = dr["rznSocialClient"].ToString();
                    objeto.client.address.direccion = dr["direccionClient"].ToString();
                    objeto.company.ruc = dr["rucCompany"].ToString();
                    objeto.company.razonSocial = dr["razonSocialCompany"].ToString();
                    objeto.company.address.direccion = dr["direccionCompany"].ToString();




                    objeto.mtoOperGravadas = objeto.mtoImpVenta - objeto.mtoIGV;

                    objeto.ublVersion = dr["ublVersion"].ToString();
                    unidad = dr["unidad"].ToString();
                    tipAfeIgv = dr["tipAfeIgv"].ToString();
                    mtoBaseIgv = Convert.ToDouble(dr["mtoBaseIgv"]);
                    porcentajeIgv = Convert.ToDouble(dr["porcentajeIgv"]);
                    cal_igv = Convert.ToDouble(dr["cal_igv"]);
                    igv = Convert.ToDouble(dr["igv"]);


                }

                lista = new List<CENNotaCreditoDatosDetalleVenta>();
                lista = obtenerDetalleVenta(codVentaN);

                foreach (CENNotaCreditoDatosDetalleVenta p in lista)
                {
                    detalle = new CENDetails();
                    detalle.codProducto = p.codProducto;
                    detalle.unidad = unidad;
                    detalle.descripcion = p.descProducto;
                    detalle.cantidad = p.cantidadUnidadBase;
                    detalle.mtoBaseIgv = mtoBaseIgv;
                    detalle.porcentajeIgv = porcentajeIgv;
                    if (codNC == CENConstante.g_const_0)
                        detalle.mtoPrecioUnitario = p.precioVenta;
                    else
                        detalle.mtoPrecioUnitario = p.precioVenta * -1;
                    detalle.mtoValorUnitario = FormatoDecimal((detalle.mtoPrecioUnitario / cal_igv), 3);
                    detalle.mtoValorVenta = FormatoDecimal((detalle.mtoValorUnitario * detalle.cantidad), 2);
                    //detalle.igv = FormatoDecimal((detalle.mtoValorVenta * (detalle.porcentajeIgv / detalle.mtoBaseIgv)),2);
                    detalle.igv = igv;
                    detalle.totalImpuestos = detalle.igv;
                    detalle.tipAfeIgv = tipAfeIgv;
                    detalle.mtoValorUnitario = FormatoDecimal(detalle.mtoValorUnitario, 2);

                    objeto.details.Add(detalle);
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
            return objeto;
        }

        public double FormatoDecimal(double monto, int canDecimales)
        {
            return Convert.ToDouble(string.Format(CENConstante.g_const_formredini + Math.Abs(canDecimales) + CENConstante.g_const_formredfin, monto));
        }
    }
}
