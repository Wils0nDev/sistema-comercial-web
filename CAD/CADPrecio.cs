using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class CADPrecio
    {
        private SqlConnection Connection;
        public CADPrecio() { }

        public List<CENVPrecio> Obtener_VPrecios()
        {
            //Listar Precios (Vista)
            List<CENVPrecio> l_VPrecios = new List<CENVPrecio>();
            CENVPrecio cen_VPrecios;
            SqlDataReader dr; //Data reader
            CADConexion CadCx = new CADConexion(); // Conexión
            //SqlParameter parametro;

            try
            {
                string l_sql = "pa_listar_precios_x_productos";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //parametro = new SqlParameter();
                    cmd.Parameters.AddWithValue("@codProveedor", 0);
                    cmd.Parameters.AddWithValue("@codFabricante", 0);
                    cmd.Parameters.AddWithValue("@codCategoria", 0);
                    cmd.Parameters.AddWithValue("@codSubcategoria", 0);
                    cmd.Parameters.AddWithValue("@descripcion", "");

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cen_VPrecios = new CENVPrecio();
                        cen_VPrecios.CodProveedor = Int32.Parse((dr["codProveedor"]).ToString());
                        cen_VPrecios.DescProveedor = dr["descProveedor"].ToString();
                        cen_VPrecios.CodFabricante = Int32.Parse(dr["codFabricante"].ToString());
                        cen_VPrecios.DescFabricante = dr["descFabricante"].ToString();
                        cen_VPrecios.CodCategoria = Int32.Parse(dr["codCategoria"].ToString());
                        cen_VPrecios.DescCategoria = dr["descCategoria"].ToString();
                        cen_VPrecios.CodSubcategoria = Int32.Parse(dr["codSubcategoria"].ToString());
                        cen_VPrecios.DescSubcategoria = dr["descSubcategoria"].ToString();
                        cen_VPrecios.CodProducto = dr["codProducto"].ToString();
                        cen_VPrecios.DescProducto = dr["descProducto"].ToString();
                        cen_VPrecios.PrecioCosto = Convert.ToDecimal(dr["precioCosto"].ToString());

                        l_VPrecios.Add(cen_VPrecios);

                    }

                }

            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return l_VPrecios;

        }


        public List<CENDetallePrecio> ObtenerDetallePrecios(String codigoArticulo)
        {
            //DESCRIPCION: OBTENER DETALLE DE PRECIOS POR ARTICULO
            CENDetallePrecio cenDetallePrecio;
            List<CENDetallePrecio> l_detallePrecio = new List<CENDetallePrecio>();

            SqlDataReader dr; //Data reader
            CADConexion CadCx = new CADConexion(); // Conexión
            SqlParameter parametro;

            try
            {
                string l_sql = "pa_listar_detalle_precio_x_producto";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    parametro = new SqlParameter();
                    cmd.Parameters.AddWithValue("@codProducto", codigoArticulo);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cenDetallePrecio = new CENDetallePrecio();

                        cenDetallePrecio.Correlativo = Int32.Parse((dr["correlativo"]).ToString());
                        cenDetallePrecio.Descripcion = dr["descripcion"].ToString();

                        if (dr["precioVenta"].ToString().Equals("")) //Validacion cuando el Precio Venta es NULL o Vacio ""
                        {
                            cenDetallePrecio.PrecioVenta = 0;
                        }
                        else
                        {
                            cenDetallePrecio.PrecioVenta = Convert.ToDecimal(dr["precioVenta"].ToString());

                        }

                        l_detallePrecio.Add(cenDetallePrecio); //SIEMPRE SE TIENE QUE AGREGAR A LA LISTA (LO ANTERIOR SON VALIDACIONES)

                    }

                }

            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }

            return l_detallePrecio;
        }

        public Boolean RegistrarActualizarxCargaMasiva(String codProducto, int tipoListaPrecio, double valor, int flag)
        {
            //DESCRIPCION: Actualizar y registrar carga masiva
            SqlDataReader dr; //Data reader
            CADConexion CadCx = new CADConexion(); // Conexión

            try
            {
                string l_sql = "pa_registrar_actualizar_precio_x_producto";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //parametro = new SqlParameter();
                    cmd.Parameters.AddWithValue("@codProducto", codProducto);
                    cmd.Parameters.AddWithValue("@tipoListaPrecio", tipoListaPrecio);
                    cmd.Parameters.AddWithValue("@precio", valor);
                    cmd.Parameters.AddWithValue("@flag", flag);

                    dr = cmd.ExecuteReader();


                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return true;

        }

        public List<CENCPrecio> obtenerDataBDProductoDetallePrecio()
        {
            //DESCRIPCION: Obtener datos de la BD de Producto y Detalle de Precios
            SqlDataReader dr; //Data reader
            CADConexion CadCx = new CADConexion(); // Conexión
            String aux = null;
            CENCPrecio cenCPrecio = new CENCPrecio();
            CENDPrecio cenDPrecio = new CENDPrecio();
            List<CENDPrecio> lcenDPrecio = new List<CENDPrecio>();
            List<CENCPrecio> lcenCPrecio = new List<CENCPrecio>();
            int cont = 0;

            try
            {
                string l_sql = "pa_listar_producto_precios_completo";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        if (cont == 0)
                        {
                            //Primera Ejecucion Traigo todas las columnas
                            cenCPrecio.CodProducto = dr["codProducto"].ToString();
                            cenCPrecio.PrecioCosto = dr["precioCosto"].ToString();

                            cenDPrecio.TipoListaPrecio = int.Parse(dr["tipoListaPrecio"].ToString());
                            cenDPrecio.PrecioVenta = dr["precioVenta"].ToString();

                            lcenDPrecio.Add(cenDPrecio); //Lista Detalle de Precios

                            aux = dr["codProducto"].ToString(); //Codigo de Producto


                        }
                        else
                        {
                            if (dr["codProducto"].ToString().Equals(aux)) //Mismo Producto
                            {
                                cenDPrecio = new CENDPrecio();
                                cenDPrecio.TipoListaPrecio = int.Parse(dr["tipoListaPrecio"].ToString());
                                cenDPrecio.PrecioVenta = dr["precioVenta"].ToString();
                                lcenDPrecio.Add(cenDPrecio); //Lista Detalle de Precios


                            }
                            else //Diferente Producto
                            {
                                //Agrego a la Lista Genetal de Cabeceras de Precios
                                cenCPrecio.Ldprecios = lcenDPrecio;
                                lcenCPrecio.Add(cenCPrecio);

                                //Nuevamente traigo todos los campos
                                cenCPrecio = new CENCPrecio();
                                cenCPrecio.CodProducto = dr["codProducto"].ToString();
                                cenCPrecio.PrecioCosto = dr["precioCosto"].ToString();

                                cenDPrecio = new CENDPrecio();
                                cenDPrecio.TipoListaPrecio = int.Parse(dr["tipoListaPrecio"].ToString());
                                cenDPrecio.PrecioVenta = dr["precioVenta"].ToString();

                                lcenDPrecio = new List<CENDPrecio>(); //Inicializo la Lista Detalle para un Nuevo Producto
                                lcenDPrecio.Add(cenDPrecio); //Lista Detalle de Precios

                                aux = dr["codProducto"].ToString(); //Codigo de Producto


                            }
                        }

                        cont++; //Contador de Filas            

                    }

                    //Agrego a la Lista Genetal de Cabeceras de Precios
                    cenCPrecio.Ldprecios = lcenDPrecio;
                    lcenCPrecio.Add(cenCPrecio);

                }

            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lcenCPrecio;

        }

        public List<CENProveedor> listarProveedor()
        {
            //DESCRIPCION: Listar Proveedor
            List<CENProveedor> lProveedor = new List<CENProveedor>();
            CADConexion CadCx = new CADConexion(); // Conexión
            CENProveedor CENProveedor;
            SqlDataReader dr; //Data reader
            try
            {
                string l_sql = "pa_listar_proveedor";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //parametro = new SqlParameter();


                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CENProveedor = new CENProveedor();
                        CENProveedor.codigoProveedor = Int32.Parse((dr["ntraProveedor"]).ToString());
                        CENProveedor.descproveedor = dr["descripcion"].ToString();

                        lProveedor.Add(CENProveedor);

                    }
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lProveedor;

        }

        public List<CENFabricante> listarFabricante()
        {
            //DESCRIPCION: Listar Fabricante
            List<CENFabricante> lFabricante = new List<CENFabricante>();
            CADConexion CadCx = new CADConexion(); // Conexión
            CENFabricante CENFabricante;
            SqlDataReader dr; //Data reader
            try
            {
                string l_sql = "pa_listar_fabricante";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //parametro = new SqlParameter();


                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CENFabricante = new CENFabricante();
                        CENFabricante.codigoFabricante = Int32.Parse((dr["ntraFabricante"]).ToString());
                        CENFabricante.descFabricante = dr["descripcion"].ToString();

                        lFabricante.Add(CENFabricante);

                    }
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }



            return lFabricante;
        }

        public List<CENCategoria> listarCategoria()
        {
            //DESCRIPCION: Listar Categoria
            List<CENCategoria> lCategoria = new List<CENCategoria>();
            CADConexion CadCx = new CADConexion(); // Conexión
            CENCategoria CENCategoria;
            SqlDataReader dr; //Data reader
            try
            {
                string l_sql = "pa_listar_categorias";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //parametro = new SqlParameter();


                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CENCategoria = new CENCategoria();
                        CENCategoria.codigoCategoria = Int32.Parse((dr["ntraCategoria"]).ToString());
                        CENCategoria.descCategoria = dr["descripcion"].ToString();

                        lCategoria.Add(CENCategoria);

                    }
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lCategoria;
        }

        public List<CENSubcategoria> listarSubcategoria(int ntraCategoria)
        {
            //DESCRIPCION: Listar Subcategoria
            List<CENSubcategoria> lSubcategoria = new List<CENSubcategoria>();
            CADConexion CadCx = new CADConexion(); // Conexión
            CENSubcategoria CENSubcategoria;
            SqlDataReader dr; //Data reader
            try
            {
                string l_sql = "pa_listar_subcategoria";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codSubCategoria", ntraCategoria);
                    //parametro = new SqlParameter();


                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CENSubcategoria = new CENSubcategoria();
                        CENSubcategoria.NtraSubcategoria = Int32.Parse((dr["ntraSubcategoria"]).ToString());
                        CENSubcategoria.DescSubcategoria = dr["descripcion"].ToString();

                        lSubcategoria.Add(CENSubcategoria);

                    }
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lSubcategoria;
        }

        public List<CENVPrecio> BuscarProducto(int codProveedor, int codFabricante, int codCategoria, int codSubcategoria, string producto)
        {
            //DESCRIPCION: Buscar Producto por Codgio y Descripcion
            List<CENVPrecio> l_VPrecios = new List<CENVPrecio>();
            CADConexion CadCx = new CADConexion(); // Conexión
            CENVPrecio CENVPrecios;
            SqlDataReader dr; //Data reader
            try
            {
                string l_sql = "pa_listar_precios_x_productos";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@codProveedor", codProveedor);
                    cmd.Parameters.AddWithValue("@codFabricante", codFabricante);
                    cmd.Parameters.AddWithValue("@codCategoria", codCategoria);
                    cmd.Parameters.AddWithValue("@codSubcategoria", codSubcategoria);
                    cmd.Parameters.AddWithValue("@descripcion", producto);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CENVPrecios = new CENVPrecio();
                        CENVPrecios.CodProveedor = Int32.Parse((dr["codProveedor"]).ToString());
                        CENVPrecios.DescProveedor = dr["descProveedor"].ToString();
                        CENVPrecios.CodFabricante = Int32.Parse(dr["codFabricante"].ToString());
                        CENVPrecios.DescFabricante = dr["descFabricante"].ToString();
                        CENVPrecios.CodCategoria = Int32.Parse(dr["codCategoria"].ToString());
                        CENVPrecios.DescCategoria = dr["descCategoria"].ToString();
                        CENVPrecios.CodSubcategoria = Int32.Parse(dr["codSubcategoria"].ToString());
                        CENVPrecios.DescSubcategoria = dr["descSubcategoria"].ToString();
                        CENVPrecios.CodProducto = dr["codProducto"].ToString();
                        CENVPrecios.DescProducto = dr["descProducto"].ToString();
                        CENVPrecios.PrecioCosto = Convert.ToDecimal(dr["precioCosto"].ToString());

                        l_VPrecios.Add(CENVPrecios);


                    }
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return l_VPrecios;
        }

        public Decimal ObtenerPrecioXProducto(string codProducto, int tipoListaPrecio)
        {
            //DESCRIPCION: Obtener precio x producto

            CADConexion CadCx = new CADConexion(); // Conexión
            SqlDataReader dr; //Data reader

            Decimal precio = 0; //precio de producto por tipo lista precio
            try
            {
                string l_sql = "pa_obtener_precio_x_producto";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@codProducto", codProducto);
                    cmd.Parameters.AddWithValue("@tipoListaPrecio", tipoListaPrecio);


                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        precio = Convert.ToDecimal(dr["precioVenta"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return precio;
        }

        public void ActualizarInsertarPrecioModal(string codProducto, int tipoListaPrecio, decimal precio, int flag)
        {
            //DESCRIPCION: Actualizar Insertar Precio desde el Modal

            CADConexion CadCx = new CADConexion(); // Conexión
            SqlDataReader dr; //Data reader

            try
            {
                string l_sql = "pa_registrar_actualizar_precio_x_producto";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@codProducto", codProducto);
                    cmd.Parameters.AddWithValue("@tipoListaPrecio", tipoListaPrecio);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@flag", flag);


                    dr = cmd.ExecuteReader();

                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

        }

        public List<CENDPrecio> ObtenerSoloPrecioVentaXProducto(String codigoArticulo)
        {
            //DESCRIPCION: OBTENER SÓLO PRECIO VENTA X PRODUCTO PARA GENERAR REPORTE
            CENDPrecio CENDPrecio;
            List<CENDPrecio> listaDetalle = new List<CENDPrecio>();

            SqlDataReader dr; //Data reader
            CADConexion CadCx = new CADConexion(); // Conexión
            SqlParameter parametro;

            try
            {
                string l_sql = "pa_listar_detalle_precio_x_producto";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    parametro = new SqlParameter();
                    cmd.Parameters.AddWithValue("@codProducto", codigoArticulo);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CENDPrecio = new CENDPrecio();
                        CENDPrecio.PrecioVenta = dr["precioVenta"].ToString();

                        //REDONDEAR LOS PRECIOS DE CADA PRODUCTO A 2 DECIMALES PARA MOSTRAR EN EL REPORTE
                        if (!CENDPrecio.PrecioVenta.Equals("")) //VALIDACION EN CASO EL VALOR SEA NULL (VACIO)
                        {
                            decimal precioVentaRedondeado = Convert.ToDecimal(CENDPrecio.PrecioVenta);
                            precioVentaRedondeado = Math.Round(precioVentaRedondeado, 2);
                            CENDPrecio.PrecioVenta = precioVentaRedondeado.ToString();
                            listaDetalle.Add(CENDPrecio); //LISTA SÓLO DE PRECIOS DE VENTA

                        }
                        else
                        {
                            CENDPrecio.PrecioVenta = "0.00";
                            listaDetalle.Add(CENDPrecio); //LISTA SÓLO DE PRECIOS DE VENTA
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return listaDetalle;
        }

        public List<CENConcepto> ListarConceptoPrecio(int prefijo)
        {
            //DESCRIPCION: Listar concepto precio
            List<CENConcepto> lConceptoPrecio = new List<CENConcepto>();
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            //DESCRIPCION: Listar concepto precio
            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_conceptos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_pref", SqlDbType.Int).Value = prefijo; //Prefijo Tipos de Precios

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENConcepto dataConcepto = new CENConcepto();

                            dataConcepto.descripcion = dr["descripcion"].ToString();

                            lConceptoPrecio.Add(dataConcepto);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lConceptoPrecio;
        }

        public int validarCodigoProducto(String codigoProducto)
        {
            //DESCRIPCION: VALIDAR CODIGO DE PRODUCTO
            int cantidad = 0;

            SqlDataReader dr; //Data reader
            CADConexion CadCx = new CADConexion(); // Conexión
            SqlParameter parametro;

            try
            {
                string l_sql = "pa_validar_codigoproducto";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    parametro = new SqlParameter();
                    cmd.Parameters.AddWithValue("@codProducto", codigoProducto);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        cantidad = Convert.ToInt32(dr["cantidad"]);

                    }

                }

            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return cantidad;
        }

        public List<CENFactDistribPrecio> listar_tipo_precio_parametrizado()
        {
            //DESCRIPCION: Se listará el tipo de precio parametrizado (excepto el Precio Costo)

            SqlDataReader dr; //Data reader
            CADConexion CadCx = new CADConexion(); // Conexión   
            List<CENFactDistribPrecio> lTipoPrecioParametrizados = new List<CENFactDistribPrecio>();
            try
            {
                string l_sql = "pa_listar_tipos_precio_paramatrizado";
                using (Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(l_sql, Connection);
                    cmd.CommandTimeout = CENConstante.g_const_0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CENFactDistribPrecio cenFactDistribPrecio = new CENFactDistribPrecio();
                        if (Convert.ToInt32(dr["codRespuesta"]) != CENConstante.g_const_n999)
                        {
                            cenFactDistribPrecio.tipoPrecio = Convert.ToInt32(dr["correlativo"]);
                            cenFactDistribPrecio.descTipoPrecio = Convert.ToString(dr["descripcion"]);
                            lTipoPrecioParametrizados.Add(cenFactDistribPrecio);

                        }
                        else
                        {
                            cenFactDistribPrecio.tipoPrecio = Convert.ToInt32(dr["correlativo"]);
                            cenFactDistribPrecio.descTipoPrecio = Convert.ToString(dr["descripcion"]);
                            lTipoPrecioParametrizados.Add(cenFactDistribPrecio);
                            break;

                        }


                    }

                }

            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lTipoPrecioParametrizados;
        }


    }
}
