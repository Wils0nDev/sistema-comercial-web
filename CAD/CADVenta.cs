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
    public class CADVenta
    {
        private SqlConnection Connection;
        public List<CENPreventaFiltroPA> listarPreventaFiltro(CENPreventaFiltro data)
        {
            //DESCRIPCION: LISTA DE DATOS DE PRODUCTO
            List<CENPreventaFiltroPA> lista = new List<CENPreventaFiltroPA>();
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            CAD_Consulta consulta = new CAD_Consulta();
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_listar_preventa_para_venta", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@ntraPreventa", SqlDbType.Int).Value = data.ntraPreventa;
                        Command.Parameters.Add("@codUsuario", SqlDbType.Int).Value = data.codUsuario;
                        Command.Parameters.Add("@codCliente", SqlDbType.Int).Value = data.codCliente;
                        Command.Parameters.Add("@codfechaRegistroI", SqlDbType.Date).Value = data.codfechaRegistroIDate;
                        Command.Parameters.Add("@codfechaRegistroF", SqlDbType.Date).Value = data.codfechaRegistroFDate;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            CENPreventaFiltroPA preventa = new CENPreventaFiltroPA();
                            while (dr.Read())
                            {
                                preventa = new CENPreventaFiltroPA();

                                if (dr["ntraPreventa"] != DBNull.Value)
                                    preventa.ntraPreventa = Convert.ToInt32(dr["ntraPreventa"].ToString().Trim());
                                if (dr["ntraSucursal"] != DBNull.Value)
                                    preventa.ntraSucursal = Convert.ToInt32(dr["ntraSucursal"].ToString().Trim());
                                if (dr["codUsuario"] != DBNull.Value)
                                    preventa.codUsuario = Convert.ToInt32(dr["codUsuario"].ToString());
                                if (dr["vendedor"] != DBNull.Value)
                                    preventa.vendedor = dr["vendedor"].ToString().Trim();
                                if (dr["codCliente"] != DBNull.Value)
                                    preventa.codCliente = Convert.ToInt32(dr["codCliente"].ToString());
                                if (dr["cliente"] != DBNull.Value)
                                    preventa.cliente = dr["cliente"].ToString().Trim();
                                if (dr["tipoVenta"] != DBNull.Value)
                                    preventa.tipoVenta = Convert.ToInt32(dr["tipoVenta"].ToString());
                                if (dr["tVenta"] != DBNull.Value)
                                    preventa.tVenta = dr["tVenta"].ToString();
                                if (dr["tDoc"] != DBNull.Value)
                                    preventa.tDoc = dr["tDoc"].ToString().Trim();
                                if (dr["oVenta"] != DBNull.Value)
                                    preventa.oVenta = dr["oVenta"].ToString();
                                if (dr["estPre"] != DBNull.Value)
                                    preventa.estPre = dr["estPre"].ToString().Trim();
                                if (dr["fecha"] != DBNull.Value)
                                    preventa.fecha = consulta.ConvertFechaDateToString(DateTime.Parse(dr["fecha"].ToString().Trim()));
                                if (dr["fechaEntrega"] != DBNull.Value)
                                    preventa.fechaEntrega = consulta.ConvertFechaDateToString(DateTime.Parse(dr["fechaEntrega"].ToString().Trim()));
                                if (dr["recargo"] != DBNull.Value)
                                    preventa.recargo = Double.Parse(dr["recargo"].ToString());
                                if (dr["igv"] != DBNull.Value)
                                    preventa.igv = Double.Parse(dr["igv"].ToString());
                                if (dr["total"] != DBNull.Value)
                                    preventa.total = Double.Parse(dr["total"].ToString());
                                if (dr["tipoMoneda"] != DBNull.Value)
                                    preventa.tipoMoneda = Convert.ToInt32(dr["tipoMoneda"].ToString().Trim());
                                if (dr["moneda"] != DBNull.Value)
                                    preventa.moneda = dr["moneda"].ToString().Trim();
                                if (dr["tipoDocumentoVenta"] != DBNull.Value)
                                    preventa.tipoDocumentoVenta = Convert.ToInt32(dr["tipoDocumentoVenta"].ToString().Trim());
                                if (dr["codPuntoEntrega"] != DBNull.Value)
                                    preventa.codPuntoEntrega = Convert.ToInt32(dr["codPuntoEntrega"].ToString().Trim());

                                lista.Add(preventa);
                            }
                        }
                        dr.Close();
                    }
                }
                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }


        public CENRespVenta registrarVenta(CEN_DataVenta data)
        {
            //DESCRIPCION: REGISTRAR VENTA
            CENRespVenta respuesta = new CENRespVenta();
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            CAD_Consulta consulta = new CAD_Consulta();
            try
            {
                string listaCuotas = ObjectToXMLGeneric<List<CENCronograma>>(data.listCuotas);
                string prestamo = ObjectToXMLGeneric<CENPrestamo>(data.prestamo);
                string cuentaCobro = ObjectToXMLGeneric<CEN_CuentaCobro>(data.cuentaCobro);
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_registrar_venta", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        //Command.Parameters.Add("@p_serie", SqlDbType.VarChar,CENConstante.g_const_20).Value = data.serie;
                        //Command.Parameters.Add("@p_nroDocumento", SqlDbType.Int).Value = data.nroDocumento;
                        Command.Parameters.Add("@p_tipoPago", SqlDbType.SmallInt).Value = data.tipoPago;
                        Command.Parameters.Add("@p_codPreventa", SqlDbType.Int).Value = data.codPreventa;
                        Command.Parameters.Add("@p_codCliente", SqlDbType.Int).Value = data.codCliente;
                        Command.Parameters.Add("@p_codVendedor", SqlDbType.Int).Value = data.codVendedor;
                        Command.Parameters.Add("@p_fechaTransaccion", SqlDbType.Date).Value = data.fechaTransaccion;
                        Command.Parameters.Add("@p_tipoMoneda", SqlDbType.SmallInt).Value = data.tipoMoneda;
                        Command.Parameters.Add("@p_tipoVenta", SqlDbType.SmallInt).Value = data.tipoVenta;
                        Command.Parameters.Add("@p_tipoCambio", SqlDbType.Money).Value = data.tipoCambio;
                        Command.Parameters.Add("@p_estado", SqlDbType.SmallInt).Value = data.estado;
                        Command.Parameters.Add("@p_importeTotal", SqlDbType.Money).Value = data.importeTotal;
                        Command.Parameters.Add("@p_importeRecargo", SqlDbType.Money).Value = data.importeRecargo;
                        Command.Parameters.Add("@p_usuario", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.usuario;
                        Command.Parameters.Add("@p_ip", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.ip;
                        Command.Parameters.Add("@p_mac", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.mac;
                        Command.Parameters.Add("@p_prestamo", SqlDbType.Xml).Value = prestamo;
                        Command.Parameters.Add("@p_listaCronograma", SqlDbType.Xml).Value = listaCuotas;
                        Command.Parameters.Add("@p_proceso", SqlDbType.SmallInt).Value = data.proceso;
                        Command.Parameters.Add("@p_codSucursal", SqlDbType.Int).Value = data.sucursal;
                        Command.Parameters.Add("@p_fechaPago", SqlDbType.Date).Value = data.fechaPago;
                        Command.Parameters.Add("@p_prFechaTrans", SqlDbType.DateTime).Value = data.prestamo.fechaTransaccion;
                        Command.Parameters.Add("@p_cuentaCobro", SqlDbType.Xml).Value = cuentaCobro;
                        Command.Parameters.Add("@p_IGV", SqlDbType.Money).Value = data.IGV;
                        Command.Parameters.Add("@p_tipoDocVenta", SqlDbType.TinyInt).Value = data.tipoDocumentoVenta;
                        Command.Parameters.Add("@p_codPuntoEntrega", SqlDbType.Int).Value = data.codPuntoEntrega;
                        Command.Parameters.Add("@p_est_reg_cue_cob", SqlDbType.Int).Value = data.est_reg_cue_cob;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            CENPreventaFiltroPA preventa = new CENPreventaFiltroPA();
                            while (dr.Read())
                            {

                                if (dr["flag"] != DBNull.Value)
                                    respuesta.flag = Convert.ToInt32(dr["flag"].ToString().Trim());
                                if (dr["venta"] != DBNull.Value)
                                    respuesta.venta = Convert.ToInt32(dr["venta"].ToString());
                                if (dr["msje"] != DBNull.Value)
                                    respuesta.msje = dr["msje"].ToString().Trim();
                                if (dr["serie"] != DBNull.Value)
                                    respuesta.serie = dr["serie"].ToString().Trim();
                                if (dr["nroDocumento"] != DBNull.Value)
                                    respuesta.nroDocumento = Convert.ToInt32(dr["nroDocumento"].ToString().Trim());
                            }
                        }
                        dr.Close();
                    }
                }
                return respuesta;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }


        public CENVentaFiltroPA listarVentaCodigo(int codigo)
        {
            //DESCRIPCION: LISTA DE DATOS DE PRODUCTO
            List<CENVentaFiltroPA> lista = new List<CENVentaFiltroPA>();
            CENVentaFiltroPA preventa = new CENVentaFiltroPA();
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            CAD_Consulta consulta = new CAD_Consulta();
            CADNotaCredito cadNC = new CADNotaCredito();
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_filtrar_venta_datos", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_ntraVenta", SqlDbType.Int).Value = codigo;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                preventa = new CENVentaFiltroPA();

                                if (dr["ntraVenta"] != DBNull.Value)
                                    preventa.ntraVenta = Convert.ToInt32(dr["ntraVenta"].ToString().Trim());
                                if (dr["serie"] != DBNull.Value)
                                    preventa.serie = dr["serie"].ToString();
                                if (dr["nroDocumento"] != DBNull.Value)
                                    preventa.nroDocumento = Convert.ToInt32(dr["nroDocumento"].ToString().Trim());
                                if (dr["ntraSucursal"] != DBNull.Value)
                                    preventa.ntraSucursal = Convert.ToInt32(dr["ntraSucursal"].ToString().Trim());
                                if (dr["codVendedor"] != DBNull.Value)
                                    preventa.codVendedor = Convert.ToInt32(dr["codVendedor"].ToString());
                                if (dr["vendedor"] != DBNull.Value)
                                    preventa.vendedor = dr["vendedor"].ToString().Trim();
                                if (dr["codCliente"] != DBNull.Value)
                                    preventa.codCliente = Convert.ToInt32(dr["codCliente"].ToString());
                                if (dr["identificacion"] != DBNull.Value)
                                    preventa.identificacion = dr["identificacion"].ToString().Trim();
                                if (dr["cliente"] != DBNull.Value)
                                    preventa.cliente = dr["cliente"].ToString().Trim();
                                if (dr["codUbigeo"] != DBNull.Value)
                                    preventa.codUbigeo = dr["codUbigeo"].ToString().Trim();
                                if (dr["tipoVenta"] != DBNull.Value)
                                    preventa.tipoVenta = Convert.ToInt32(dr["tipoVenta"].ToString());
                                if (dr["tVenta"] != DBNull.Value)
                                    preventa.tVenta = dr["tVenta"].ToString();
                                if (dr["tDoc"] != DBNull.Value)
                                    preventa.tDoc = dr["tDoc"].ToString().Trim();

                                if (dr["estPre"] != DBNull.Value)
                                    preventa.estPre = dr["estPre"].ToString().Trim();
                                if (dr["fechaPago"] != DBNull.Value)
                                    preventa.fechaPago = consulta.ConvertFechaDateToString(DateTime.Parse(dr["fechaPago"].ToString().Trim()));
                                if (dr["fechaTransaccion"] != DBNull.Value)
                                    preventa.fechaTransaccion = consulta.ConvertFechaDateToString(DateTime.Parse(dr["fechaTransaccion"].ToString().Trim()));
                                if (dr["importeRecargo"] != DBNull.Value)
                                    preventa.importeRecargo = Double.Parse(dr["importeRecargo"].ToString());
                                if (dr["IGV"] != DBNull.Value)
                                    preventa.IGV = Double.Parse(dr["IGV"].ToString());
                                if (dr["importeTotal"] != DBNull.Value)
                                    preventa.importeTotal = Double.Parse(dr["importeTotal"].ToString());
                                if (dr["tipoMoneda"] != DBNull.Value)
                                    preventa.tipoMoneda = Convert.ToInt32(dr["tipoMoneda"].ToString().Trim());
                                if (dr["moneda"] != DBNull.Value)
                                    preventa.moneda = dr["moneda"].ToString().Trim();
                                if (dr["ntraSucursal"] != DBNull.Value)
                                    preventa.ntraSucursal = Convert.ToInt32(dr["ntraSucursal"].ToString().Trim());
                                if (dr["sucursal"] != DBNull.Value)
                                    preventa.sucursal = dr["sucursal"].ToString().Trim();
                                if (dr["tipoDocumentoVenta"] != DBNull.Value)
                                    preventa.tipoDocumentoVenta = Convert.ToInt32(dr["tipoDocumentoVenta"].ToString().Trim());
                                if (dr["codPuntoEntrega"] != DBNull.Value)
                                    preventa.codPuntoEntrega = Convert.ToInt32(dr["codPuntoEntrega"].ToString().Trim());
                                if (dr["direccion"] != DBNull.Value)
                                    preventa.direccion = dr["direccion"].ToString().Trim();
                                if (dr["ruta"] != DBNull.Value)
                                    preventa.ruta = dr["ruta"].ToString().Trim();
                                if (dr["tipoPersona"] != DBNull.Value)
                                    preventa.tipoPersona = Convert.ToInt32(dr["tipoPersona"].ToString().Trim());

                                preventa.listaDetalle = cadNC.obtenerDetalleVenta(codigo);
                                preventa.listaPromociones = ListarPromocionesVenta(codigo);
                                preventa.listaDescuentos = ListarDescuentosVenta(codigo);

                                //Lista de cuando se pagó
                                preventa.listaPagosFechas = ListarPagoVenta(codigo);
                                //Lista de notas de credito
                                preventa.listaNCFechas = ListarNCFechaVenta(codigo);
                                //Anulacion de venta
                                preventa.anulacionVenta = FechaAnulacionVenta(codigo);
                            }
                        }
                        dr.Close();
                    }
                }
                return preventa;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }

        public List<CENPrevDescDetalle> ListarPromocionesVenta(int codigo)
        {
            //DESCRIPCION: REGISTRAR VENTA
            List<CENPrevDescDetalle> respuesta = new List<CENPrevDescDetalle>();
            CENPrevDescDetalle fila = new CENPrevDescDetalle();
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_listar_promociones_venta", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_codVenta", SqlDbType.Int).Value = codigo;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                fila = new CENPrevDescDetalle();
                                if (dr["codVenta"] != DBNull.Value)
                                    fila.codVenta = Convert.ToInt32(dr["codVenta"].ToString().Trim());
                                if (dr["codPromocion"] != DBNull.Value)
                                    fila.codigo = Convert.ToInt32(dr["codPromocion"].ToString());
                                if (dr["descripcion"] != DBNull.Value)
                                    fila.descripcion = dr["descripcion"].ToString().Trim();

                                respuesta.Add(fila);
                            }
                        }
                        dr.Close();
                    }
                }
                return respuesta;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }

        public List<CENPrevDescDetalle> ListarDescuentosVenta(int codigo)
        {
            //DESCRIPCION: REGISTRAR VENTA
            List<CENPrevDescDetalle> respuesta = new List<CENPrevDescDetalle>();
            CENPrevDescDetalle fila = new CENPrevDescDetalle();
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_listar_descuentos_venta", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_codVenta", SqlDbType.Int).Value = codigo;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                fila = new CENPrevDescDetalle();
                                if (dr["codVenta"] != DBNull.Value)
                                    fila.codVenta = Convert.ToInt32(dr["codVenta"].ToString().Trim());
                                if (dr["codDescuento"] != DBNull.Value)
                                    fila.codigo = Convert.ToInt32(dr["codDescuento"].ToString());
                                if (dr["descripcion"] != DBNull.Value)
                                    fila.descripcion = dr["descripcion"].ToString().Trim();

                                respuesta.Add(fila);
                            }
                        }
                        dr.Close();
                    }
                }
                return respuesta;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }

        public List<CENFechaTrnsaccion> ListarPagoVenta(int codigo)
        {
            //DESCRIPCION: LISTAR PAGOS DE VENTA
            List<CENFechaTrnsaccion> respuesta = new List<CENFechaTrnsaccion>();
            CENFechaTrnsaccion fila = new CENFechaTrnsaccion();
            SqlDataReader dr;          //data reader	   
            CAD_Consulta cad_consulta = new CAD_Consulta();
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_listar_pago_venta", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_codVenta", SqlDbType.Int).Value = codigo;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                fila = new CENFechaTrnsaccion();
                                if (dr["ntraTransaccionPago"] != DBNull.Value)
                                    fila.codigo = Convert.ToInt32(dr["ntraTransaccionPago"].ToString().Trim());
                                if (dr["fechaTransaccion"] != DBNull.Value)
                                    fila.fechaTransaccion = cad_consulta.ConvertFechaDateToString(DateTime.Parse(dr["fechaTransaccion"].ToString().Trim()));
                                if (dr["horaTransaccion"] != DBNull.Value)
                                    fila.horaTransaccion = dr["horaTransaccion"].ToString().Trim();

                                respuesta.Add(fila);
                            }
                        }
                        dr.Close();
                    }
                }
                return respuesta;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }

        public CENFechaTrnsaccion FechaAnulacionVenta(int codigo)
        {
            //DESCRIPCION: LISTAR PAGOS DE VENTA
            CENFechaTrnsaccion fila = new CENFechaTrnsaccion();
            SqlDataReader dr;          //data reader	   
            CAD_Consulta cad_consulta = new CAD_Consulta();
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_fecha_anulacion_venta", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_codVenta", SqlDbType.Int).Value = codigo;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                fila = new CENFechaTrnsaccion();
                                if (dr["ntraVentaAnulada"] != DBNull.Value)
                                    fila.codigo = Convert.ToInt32(dr["ntraVentaAnulada"].ToString().Trim());
                                if (dr["fecha"] != DBNull.Value)
                                    fila.fechaTransaccion = cad_consulta.ConvertFechaDateToString(DateTime.Parse(dr["fecha"].ToString().Trim()));

                            }
                        }
                        dr.Close();
                    }
                }
                return fila;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
        }

        public List<CENFechaTrnsaccion> ListarNCFechaVenta(int codigo)
        {
            //DESCRIPCION: LISTAR PAGOS DE VENTA
            List<CENFechaTrnsaccion> respuesta = new List<CENFechaTrnsaccion>();
            CENFechaTrnsaccion fila = new CENFechaTrnsaccion();
            SqlDataReader dr;          //data reader	   
            CAD_Consulta cad_consulta = new CAD_Consulta();
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_listar_nc_fecha_venta", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_codVenta", SqlDbType.Int).Value = codigo;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                fila = new CENFechaTrnsaccion();
                                if (dr["ntraNotaCredito"] != DBNull.Value)
                                    fila.codigo = Convert.ToInt32(dr["ntraNotaCredito"].ToString().Trim());
                                if (dr["fecha"] != DBNull.Value)
                                    fila.fechaTransaccion = cad_consulta.ConvertFechaDateToString(DateTime.Parse(dr["fecha"].ToString().Trim()));
                                if (dr["vendedor"] != DBNull.Value)
                                    fila.vendedor = dr["vendedor"].ToString().Trim();

                                respuesta.Add(fila);
                            }
                        }
                        dr.Close();
                    }
                }
                return respuesta;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conector.CerrarConexion(Connection);
            }
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
