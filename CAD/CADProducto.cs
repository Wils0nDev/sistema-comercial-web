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
    public class CADProducto
    {
        private SqlConnection Connection;
        public CENDatosProducto CENdatosproductos(int codCategoria, int codSubCategoria, int codProveedor, int codFabricante, string descripcion)
        {
            //DESCRIPCION: LISTA DE DATOS DE PRODUCTO
            CENDatosProducto listArticulos = new CENDatosProducto();
            SqlDataReader dr;          //data reader	     
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);

                    using (SqlCommand Command = new SqlCommand("pa_listar_filtros_productos", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@codCategoria", SqlDbType.Int).Value = codCategoria;
                        Command.Parameters.Add("@codSubcategoria", SqlDbType.Int).Value = codSubCategoria;
                        Command.Parameters.Add("@codProveedor", SqlDbType.Int).Value = codProveedor;
                        Command.Parameters.Add("@codFabricante", SqlDbType.Int).Value = codFabricante;
                        Command.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = descripcion.Trim();
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            CENProducto producto = new CENProducto();
                            while (dr.Read())
                            {
                                producto = new CENProducto();
                                if (Convert.ToInt32(dr["estado"].ToString()) == CENConstante.g_const_0)
                                {
                                    if (dr["codproducto"] != DBNull.Value)
                                        producto.codProducto = dr["codproducto"].ToString().Trim();
                                    if (dr["codCategoria"] != DBNull.Value)
                                        producto.codCategoria = Convert.ToInt32(dr["codCategoria"].ToString());
                                    if (dr["descCategoria"] != DBNull.Value)
                                        producto.descCategoria = dr["descCategoria"].ToString().Trim();
                                    if (dr["codSubcategoria"] != DBNull.Value)
                                        producto.codSubCategoria = Convert.ToInt32(dr["codSubcategoria"].ToString());
                                    if (dr["descSubcategoria"] != DBNull.Value)
                                        producto.descSubCategoria = dr["descSubcategoria"].ToString().Trim();
                                    if (dr["codProveedor"] != DBNull.Value)
                                        producto.codProveedor = Convert.ToInt32(dr["codProveedor"].ToString());
                                    if (dr["descproveedor"] != DBNull.Value)
                                        producto.descProveedor = dr["descproveedor"].ToString().Trim();
                                    if (dr["codFabricante"] != DBNull.Value)
                                        producto.codFabricante = Convert.ToInt32(dr["codFabricante"].ToString());
                                    if (dr["descFabricante"] != DBNull.Value)
                                        producto.descFabricante = dr["descFabricante"].ToString().Trim();
                                    if (dr["descripcion"] != DBNull.Value)
                                        producto.descProducto = dr["descripcion"].ToString().Trim();
                                   /*if (dr["fechavencimiento"] != DBNull.Value)
                                        producto.fechavencimiento = (dr["fechavencimiento"].ToString()).Substring(CENConstante.g_const_0, CENConstante.g_const_10);*/
                                  /*if (dr["stockAlmprincipal"] != DBNull.Value)
                                        producto.cantAlmPrincipal = Convert.ToInt16(dr["stockAlmprincipal"].ToString());*/
                                   if (dr["descUnidadBase"] != DBNull.Value)
                                        producto.descUndBase = dr["descUnidadBase"].ToString().Trim();
                                    listArticulos.DatosProducto.Add(producto);
                                    listArticulos.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                                    listArticulos.ErrorWebSer.CodigoErr = CENConstante.g_const_2000;
                                    listArticulos.ErrorWebSer.DescripcionErr = dr["mensaje"].ToString();
                                }
                                else
                                {
                                    listArticulos.ErrorWebSer.TipoErr = Convert.ToInt16(dr["estado"].ToString());
                                    listArticulos.ErrorWebSer.CodigoErr = CENConstante.g_const_3000;
                                    listArticulos.ErrorWebSer.DescripcionErr = dr["mensaje"].ToString();

                                }
                            }
                        }
                        dr.Close();
                    }
                }
                return listArticulos;
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
        public CENDatoscategoria CENdatoscategoria()
        {
            //DESCRIPCION: LISTA DE DATOS DE CATEGORIA
            CENDatoscategoria datoscategoria = new CENDatoscategoria();
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_listar_categorias", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CENCategoria categoria = new CENCategoria();
                                if (dr["ntraCategoria"] != DBNull.Value)
                                    categoria.codigoCategoria = Convert.ToInt32(dr["ntraCategoria"].ToString());
                                if (dr["descripcion"] != DBNull.Value)
                                    categoria.descCategoria = dr["descripcion"].ToString().Trim();

                                datoscategoria.DatosCategoria.Add(categoria);
                            }
                            datoscategoria.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                            datoscategoria.ErrorWebSer.CodigoErr = CENConstante.g_const_2000;
                            datoscategoria.ErrorWebSer.DescripcionErr = CENConstante.g_const_vacio;
                        }
                        dr.Close();
                    }
                }
                return datoscategoria;
            }
            catch (Exception ex)
            {
                datoscategoria.ErrorWebSer.TipoErr = CENConstante.g_const_1;
                datoscategoria.ErrorWebSer.CodigoErr = CENConstante.g_const_3000;
                datoscategoria.ErrorWebSer.DescripcionErr = ex.Message;
                return datoscategoria;
            }
            finally
            {
                conector.CerrarConexion(Connection);
            }

        }
        public CENDatoSubscategoria CENdatossubbcategoria(int codCategoria)
        {
            //DESCRIPCION: LISTA DE DATOS DE SUB CATEGORIA
            CENDatoSubscategoria datossubcategoria = new CENDatoSubscategoria();
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_listar_subcategoria", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@codSubCategoria", SqlDbType.Int).Value = codCategoria;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CENSubCategoria subcategoria = new CENSubCategoria();
                                if (dr["ntraSubcategoria"] != DBNull.Value)
                                    subcategoria.codigoSubCategoria = Convert.ToInt32(dr["ntraSubcategoria"].ToString());
                                if (dr["descripcion"] != DBNull.Value)
                                    subcategoria.descSubCategoria = dr["descripcion"].ToString().Trim();

                                datossubcategoria.DatosSubCategoria.Add(subcategoria);
                            }
                            datossubcategoria.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                            datossubcategoria.ErrorWebSer.CodigoErr = CENConstante.g_const_2000;
                            datossubcategoria.ErrorWebSer.DescripcionErr = CENConstante.g_const_vacio;
                        }
                        dr.Close();
                    }
                }
                return datossubcategoria;
            }
            catch (Exception ex)
            {
                datossubcategoria.ErrorWebSer.TipoErr = CENConstante.g_const_1;
                datossubcategoria.ErrorWebSer.CodigoErr = CENConstante.g_const_3000;
                datossubcategoria.ErrorWebSer.DescripcionErr = ex.Message;
                return datossubcategoria;
            }
            finally
            {
                conector.CerrarConexion(Connection);
            }
        }
        public CENDatosProveedor CENdatosproveedor()
        {
            //DESCRIPCION: LISTA DE DATOS DE PROVEEDOR
            CENDatosProveedor datosproveedor = new CENDatosProveedor();
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_listar_proveedor", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CENProveedor proveedor = new CENProveedor();
                                if (dr["ntraProveedor"] != DBNull.Value)
                                    proveedor.codigoProveedor = Convert.ToInt32(dr["ntraProveedor"].ToString());
                                if (dr["descripcion"] != DBNull.Value)
                                    proveedor.descproveedor = dr["descripcion"].ToString().Trim();

                                datosproveedor.DatosProveedor.Add(proveedor);
                            }
                            datosproveedor.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                            datosproveedor.ErrorWebSer.CodigoErr = CENConstante.g_const_2000;
                            datosproveedor.ErrorWebSer.DescripcionErr = CENConstante.g_const_vacio;
                        }
                        dr.Close();
                    }
                }
                return datosproveedor;
            }
            catch (Exception ex)
            {
                datosproveedor.ErrorWebSer.TipoErr = CENConstante.g_const_1;
                datosproveedor.ErrorWebSer.CodigoErr = CENConstante.g_const_3000;
                datosproveedor.ErrorWebSer.DescripcionErr = ex.Message;
                return datosproveedor;
            }
            finally
            {
                conector.CerrarConexion(Connection);
            }
        }
        public CENDatosFabricante CENdatosfabricante()
        {
            //DESCRIPCION: LISTA DE DATOS DE FABRICANTE
            CENDatosFabricante datosfabricante = new CENDatosFabricante();
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_listar_fabricante", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CENFabricante fabricante = new CENFabricante();
                                if (dr["ntraFabricante"] != DBNull.Value)
                                    fabricante.codigoFabricante = Convert.ToInt32(dr["ntraFabricante"].ToString());
                                if (dr["descripcion"] != DBNull.Value)
                                    fabricante.descFabricante = dr["descripcion"].ToString().Trim();

                                datosfabricante.DatosFabricante.Add(fabricante);
                            }
                            datosfabricante.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                            datosfabricante.ErrorWebSer.CodigoErr = CENConstante.g_const_2000;
                            datosfabricante.ErrorWebSer.DescripcionErr = CENConstante.g_const_vacio;
                        }
                        dr.Close();
                    }
                }
                return datosfabricante;
            }
            catch (Exception ex)
            {
                datosfabricante.ErrorWebSer.TipoErr = CENConstante.g_const_1;
                datosfabricante.ErrorWebSer.CodigoErr = CENConstante.g_const_3000;
                datosfabricante.ErrorWebSer.DescripcionErr = ex.Message;
                return datosfabricante;
            }
            finally
            {
                conector.CerrarConexion(Connection);
            }
        }
        public CENDatosDetalleAlmacen CENdatosdetallealmacen(string codArticulo)
        {
            //DESCRIPCION: LISTA DE DATOS DE DETALLE DE ALMACENES
            CENDatosDetalleAlmacen datosdetallealmacen = new CENDatosDetalleAlmacen();
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_listar_detalle_almacen", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@codArticulo", SqlDbType.VarChar, 10).Value = codArticulo.Trim();
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CENDetalleAlmacen detallealmacen = new CENDetalleAlmacen();
                                if (dr["ntraAlmacen"] != DBNull.Value)
                                    detallealmacen.transaccion = Convert.ToInt32(dr["ntraAlmacen"].ToString());
                                if (dr["descripcion"] != DBNull.Value)
                                    detallealmacen.descAlmacen = dr["descripcion"].ToString().Trim();
                                if (dr["codProducto"] != DBNull.Value)
                                    detallealmacen.codProducto = dr["codProducto"].ToString();
                                if (dr["stock"] != DBNull.Value)
                                    detallealmacen.stock = Convert.ToInt32(dr["stock"].ToString());
                                datosdetallealmacen.DatosDetalleAlmacen.Add(detallealmacen);
                            }
                            datosdetallealmacen.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                            datosdetallealmacen.ErrorWebSer.CodigoErr = CENConstante.g_const_2000;
                            datosdetallealmacen.ErrorWebSer.DescripcionErr = CENConstante.g_const_vacio;
                        }
                        dr.Close();
                    }
                }
                return datosdetallealmacen;
            }
            catch (Exception ex)
            {
                datosdetallealmacen.ErrorWebSer.TipoErr = CENConstante.g_const_1;
                datosdetallealmacen.ErrorWebSer.CodigoErr = CENConstante.g_const_3000;
                datosdetallealmacen.ErrorWebSer.DescripcionErr = ex.Message;
                return datosdetallealmacen;
            }
            finally
            {
                conector.CerrarConexion(Connection);
            }
        }
        public CENDatosRegistrostock CENregistrostock(int stock, string codArticulo, int codAlmacen)
        {
            //DESCRIPCION: REGISTRO / ACTUALIZACION DE STOCK
            CENDatosRegistrostock datosregistrostock = new CENDatosRegistrostock();
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_update_stock_almacen", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@stock", SqlDbType.Int).Value = stock;
                        Command.Parameters.Add("@codArticulo", SqlDbType.VarChar, 10).Value = codArticulo.Trim();
                        Command.Parameters.Add("@codAlmacen", SqlDbType.Int).Value = codAlmacen;
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();

                        while (dr.Read())
                        {

                            if (dr["estado"] != DBNull.Value && Convert.ToInt32(dr["estado"].ToString()) == CENConstante.g_const_0)
                            {
                                datosregistrostock.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                                datosregistrostock.ErrorWebSer.CodigoErr = CENConstante.g_const_2000;
                                datosregistrostock.ErrorWebSer.DescripcionErr = CENConstante.g_const_vacio;
                                datosregistrostock.mensaje = dr["mensaje"].ToString();
                            }
                            else
                            {
                                datosregistrostock.ErrorWebSer.TipoErr = CENConstante.g_const_1;
                                datosregistrostock.ErrorWebSer.CodigoErr = CENConstante.g_const_3000;
                                datosregistrostock.ErrorWebSer.DescripcionErr = dr["mensaje"].ToString();
                                datosregistrostock.mensaje = dr["mensaje"].ToString();
                                return datosregistrostock;

                            }
                        }
                        dr.Close();
                    }
                }
                return datosregistrostock;
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
        public CENDatosCodigoAlmacen CENCodigoAlmacen(string descAlmacen)
        {
            //DESCRIPCION: LISTA DE CODIGO DE ALMACEN
            CENDatosCodigoAlmacen CodigoAlmacen = new CENDatosCodigoAlmacen();
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_obtener_codigo_almacen", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@descAlmacen", SqlDbType.VarChar, 100).Value = descAlmacen.Trim();
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["estado"] != DBNull.Value && Convert.ToInt32(dr["estado"].ToString()) == CENConstante.g_const_0)
                            {
                                if (Convert.ToInt32(dr["codAlmacen"].ToString()) > CENConstante.g_const_0)
                                {
                                    CodigoAlmacen.CodAlmacen = Convert.ToInt32(dr["codAlmacen"].ToString());
                                    CodigoAlmacen.ErrorWebSer.CodigoErr = CENConstante.g_const_2000;
                                    CodigoAlmacen.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                                    CodigoAlmacen.ErrorWebSer.DescripcionErr = CENConstante.g_const_vacio;
                                }
                                else
                                {
                                    CodigoAlmacen.CodAlmacen = Convert.ToInt32(dr["codAlmacen"].ToString());
                                    CodigoAlmacen.ErrorWebSer.CodigoErr = CENConstante.g_const_1000;
                                    CodigoAlmacen.ErrorWebSer.TipoErr = CENConstante.g_const_0;
                                    CodigoAlmacen.ErrorWebSer.DescripcionErr = CENConstante.g_const_vacio;
                                }

                            }
                            else
                            {
                                CodigoAlmacen.CodAlmacen = Convert.ToInt32(dr["codAlmacen"].ToString());
                                CodigoAlmacen.ErrorWebSer.CodigoErr = CENConstante.g_const_3000;
                                CodigoAlmacen.ErrorWebSer.TipoErr = CENConstante.g_const_1;
                                CodigoAlmacen.ErrorWebSer.DescripcionErr = dr["mensaje"].ToString();
                                return CodigoAlmacen;
                            }
                        }
                        dr.Close();
                    }

                }
                return CodigoAlmacen;
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
        public List<CENDAlmacen> ObtenerDetalleAlmacen(string codArticulo)
        {
            //DESCRIPCION: Lista de Datos detalle de almacen
            List<CENDAlmacen> listdetalle = new List<CENDAlmacen>();
            CADConexion conector = new CADConexion(); // Conexión
            SqlDataReader dr;          //data reader
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_listar_detalle_almacen", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@codArticulo", SqlDbType.VarChar, 10).Value = codArticulo.Trim();
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CENDAlmacen detallealmacen = new CENDAlmacen();
                                if (dr["ntraAlmacen"] != DBNull.Value)
                                    detallealmacen.codAlmacen = Convert.ToInt32(dr["ntraAlmacen"].ToString());
                                if (dr["stock"] != DBNull.Value)
                                    detallealmacen.stock = Convert.ToInt32(dr["stock"].ToString());

                                listdetalle.Add(detallealmacen);
                            }

                        }
                        dr.Close();
                    }
                }
                return listdetalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerProducto(string codArticulo)
        {
            //DESCRIPCION: Verificar el codigo de producto
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión
            int cant = CENConstante.g_const_0; //Variable de validacion
            int val = CENConstante.g_const_0;   //Variable de validacion
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_obtener_existencia_articulo", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.Add("@codProducto", SqlDbType.VarChar, 10).Value = codArticulo.Trim();
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr["cantidad"] != DBNull.Value)
                                    val = Convert.ToInt32(dr["cantidad"].ToString());
                            }
                            if (val > CENConstante.g_const_0)
                            {
                                cant = CENConstante.g_const_1;
                            }
                            else
                            {
                                cant = CENConstante.g_const_0;
                            }
                        }

                    }
                }

                return cant;
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
        public int CalcularMontoInventario(string codArticulo)
        {
            SqlDataReader dr;          //data reader
            CADConexion conector = new CADConexion(); // Conexión

            int monto = CENConstante.g_const_0;
            try
            {
                using (Connection = new SqlConnection(conector.CxSQL()))
                {
                    conector.AbrirConexion(Connection);
                    using (SqlCommand Command = new SqlCommand("pa_calcular_total_almacen", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.Add("@codArticulo", SqlDbType.VarChar, 10).Value = codArticulo.Trim();
                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr["TotalStock"] != DBNull.Value)
                                    monto = Convert.ToInt32(dr["TotalStock"].ToString());
                            }
                        }
                    }
                }
                return monto;

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
        public List<CENProducto> ListarCategoria(int flag)
        {
            //DESCRIPCION: LISTA DE DATOS DE CATEGORIA USANDO EL PA DE FLAG
            List<CENProducto> ListaCategoria = new List<CENProducto>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr;          //data reader
            CENProducto objCategoria = null;
            CADConexion conector = new CADConexion(); // Conexión

            try
            {
                con = new SqlConnection(conector.CxSQL());
                cmd = new SqlCommand("pa_listar_datos_select_x_flag", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto categoria
                    objCategoria = new CENProducto();
                    objCategoria.codCategoria = Convert.ToInt32(dr["correlativo"]);
                    objCategoria.descCategoria = dr["descripcion"].ToString();
                    ListaCategoria.Add(objCategoria);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListaCategoria;
        }
        public List<CENSubcategoria> ListarSubCategoriaPorCategoria(int codCategoria)
        {
            List<CENSubcategoria> ListaSubCat = new List<CENSubcategoria>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENSubcategoria objSubcategoria = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_subcategoria", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codSubCategoria", SqlDbType.Int).Value = codCategoria;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto Rutas
                    objSubcategoria = new CENSubcategoria();
                    objSubcategoria.NtraSubcategoria = Convert.ToInt32(dr["ntraSubcategoria"]);
                    objSubcategoria.DescSubcategoria = dr["descripcion"].ToString();
                    ListaSubCat.Add(objSubcategoria);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaSubCat;
        }

        public List<CENFabricante> ListarFabricante(int flag)
        {
            List<CENFabricante> listaFabr = new List<CENFabricante>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENFabricante objFabricante = null;
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
                    objFabricante = new CENFabricante();
                    objFabricante.codigoFabricante = Convert.ToInt32(dr["ntraFabricante"]);
                    objFabricante.descFabricante = dr["descripcion"].ToString();
                    listaFabr.Add(objFabricante);

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

            return listaFabr;
        }

        public List<CENProveedor> ListarProveedor(int flag)
        {
            List<CENProveedor> listaProve = new List<CENProveedor>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENProveedor objProveedor = null;
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
                    objProveedor = new CENProveedor();
                    objProveedor.codigoProveedor = Convert.ToInt32(dr["ntraProveedor"]);
                    objProveedor.descproveedor = dr["descripcion"].ToString();
                    listaProve.Add(objProveedor);

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

            return listaProve;
        }

        public int EliminarProducto(string Cod)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_eliminar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codProducto", Cod);
                cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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

        public List<string> InsertarProducto(CENProductosInsert objProduc)
        {
            string response;
            string response2;
            var respuesta = new List<string>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_registrar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_descripcion", objProduc.descProducto);
                cmd.Parameters.AddWithValue("@p_codUndBaseVenta", objProduc.undBase);
                cmd.Parameters.AddWithValue("@p_codCategoria", objProduc.codCategoria);
                cmd.Parameters.AddWithValue("@p_codSubCat", objProduc.codSubCategoria);
                cmd.Parameters.AddWithValue("@p_tipoProduc", objProduc.tipoProducto);
                cmd.Parameters.AddWithValue("@p_flagVent", objProduc.flagVenta);
                cmd.Parameters.AddWithValue("@p_codFabricante", objProduc.codFabricante);
                cmd.Parameters.AddWithValue("@p_proveedor", objProduc.codProveedor);

                cmd.Parameters.Add("@resultado", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@codregistro", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;



                con.Open();
                cmd.ExecuteNonQuery();
                response = Convert.ToString(cmd.Parameters["@resultado"].Value);
                response2 = Convert.ToString(cmd.Parameters["@codregistro"].Value);
                respuesta.Add(response);
                respuesta.Add(response2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return respuesta;
        }

        public int ActualizarProducto(CENProducto objProducto, string codProducto)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_actualizar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_descripcion", objProducto.descProducto);
                cmd.Parameters.AddWithValue("@p_codUndBaseVenta", objProducto.undBase);
                cmd.Parameters.AddWithValue("@p_codCategoria", objProducto.codCategoria);
                cmd.Parameters.AddWithValue("@p_codSubCat", objProducto.codSubCategoria);
                cmd.Parameters.AddWithValue("@p_tipoProduc", objProducto.tipoProducto);
                cmd.Parameters.AddWithValue("@p_flagVent", objProducto.flagVenta);
                cmd.Parameters.AddWithValue("@p_codFabricante", objProducto.codFabricante);
                cmd.Parameters.AddWithValue("@p_proveedor", objProducto.codProveedor);
                cmd.Parameters.AddWithValue("@p_codProd", codProducto);
                cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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

        public List<CEN_Detalle_Presentacion_Product> ListarDetallePresentacionProduct(string codProductos)
        {
            List<CEN_Detalle_Presentacion_Product> listaFabr = new List<CEN_Detalle_Presentacion_Product>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CEN_Detalle_Presentacion_Product objDetalleProduct = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_producto_xdetalle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codProducto", SqlDbType.VarChar,10).Value = codProductos.Trim();
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objDetalleProduct = new CEN_Detalle_Presentacion_Product();
                    objDetalleProduct.codProductos = dr["codProducto"].ToString();                   
                    objDetalleProduct.codDetPresents = Convert.ToInt32(dr["codPresentancion"]);
                    objDetalleProduct.nom = dr["descripcion"].ToString();
                    objDetalleProduct.cantUniBases = Convert.ToInt32(dr["cantidadUnidadBase"]);
                    listaFabr.Add(objDetalleProduct);

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

            return listaFabr;
        }


        public List<CENProductoLista> ListaProductoPorFiltro(CENProducto datos)
        {

            List<CENProductoLista> list_producto = new List<CENProductoLista>();
            CENProductoLista objProducLista = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_filtros_product", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codCategoria", SqlDbType.Int).Value = datos.codCategoria;
                cmd.Parameters.Add("@codSubcategoria", SqlDbType.Int).Value = datos.codSubCategoria;
                cmd.Parameters.Add("@codProveedor", SqlDbType.Int).Value = datos.codProveedor;
                cmd.Parameters.Add("@codFabricante", SqlDbType.Int).Value = datos.codFabricante;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = datos.desctipoProducto.Trim();
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objProducLista = new CENProductoLista();
                    objProducLista.codProducto = Convert.ToString(dr["codProducto"]);
                    objProducLista.codCategoria = Convert.ToInt32(dr["codCategoria"].ToString());
                    objProducLista.descCategoria = Convert.ToString(dr["descCategoria"]);
                    objProducLista.codSubCategoria = Convert.ToInt32(dr["codSubcategoria"].ToString());
                    objProducLista.descSubCategoria = Convert.ToString(dr["descSubcategoria"]);
                    objProducLista.codProveedor = Convert.ToInt32(dr["codProveedor"].ToString());
                    objProducLista.descProveedor = Convert.ToString(dr["descProveedor"]);
                    objProducLista.codFabricante = Convert.ToInt32(dr["codFabricante"].ToString());
                    objProducLista.descFabricante = Convert.ToString(dr["descFabricante"]);
                    objProducLista.descProducto = Convert.ToString(dr["descripcion"]);
                    objProducLista.descUndBase = Convert.ToString(dr["descUnidadBase"]);
                    objProducLista.tipoProducto = Convert.ToInt32(dr["tipoProducto"].ToString());
                    objProducLista.desctipoProducto = Convert.ToString(dr["desctipoProducto"]);
                    objProducLista.flagVenta = Convert.ToInt32(dr["flagVenta"]);
                    list_producto.Add(objProducLista);
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
            return list_producto;

        }

        public List<CENProductoListaDetalle> ListaProductoCodCategoria(string codProducto)
        {

            List<CENProductoListaDetalle> list_producto = new List<CENProductoListaDetalle>();
            CENProductoListaDetalle objProducLista = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_producto_xdetalle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codProducto", SqlDbType.VarChar).Value = codProducto;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objProducLista = new CENProductoListaDetalle();
                    objProducLista.codProducto = Convert.ToString(dr["codProducto"]);
                    objProducLista.descCategoria = Convert.ToInt32(dr["codCategoria"]);
                    objProducLista.descSubCategoria = Convert.ToInt32(dr["codSubcategoria"]);
                    objProducLista.descProveedor = Convert.ToInt32(dr["codProveedor"]);
                    objProducLista.descFabricante = Convert.ToInt32(dr["codFabricante"]);
                    objProducLista.descProducto = Convert.ToString(dr["descripcion"]);
                    objProducLista.descUndBase = Convert.ToInt32(dr["codUnidadBaseventa"]);
                    objProducLista.tipoProducto = Convert.ToInt32(dr["tipoProducto"]);
                    objProducLista.flagVenta = Convert.ToInt32(dr["flagVenta"]);
                    objProducLista.codProductov2 = Convert.ToString(dr["codProducto"]);
                    objProducLista.descPresentacion = Convert.ToInt32(dr["codPresentacion"]);
                    objProducLista.cantUnidBase = Convert.ToInt32(dr["cantidadUnidadBase"]);
                    list_producto.Add(objProducLista);

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
            return list_producto;

        }

        public int EliminarDetallePresentacionActualizarProduct(string cod, int codP)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_eliminar_presentacion_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codProducto", cod);
                cmd.Parameters.AddWithValue("@codPresentacion", codP);
                cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();

                cmd.ExecuteNonQuery();
                response = Convert.ToInt32(cmd.Parameters["@resultado"].Value);

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

   
    }
}
