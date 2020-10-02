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
    public class CADPromociones
    {
        public List<CENPromociones> ListarEstadoPrmocion(int flag)
        {
            List<CENPromociones> listaRU = new List<CENPromociones>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENPromociones objPromociones = null;
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
                    objPromociones = new CENPromociones();
                    objPromociones.estado = Convert.ToInt32(dr["correlativo"]);
                    objPromociones.desEstado = dr["descripcion"].ToString();
                    listaRU.Add(objPromociones);

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

            return listaRU;

        }



        public List<CENPromocionesLista> ListarPromociones(CENPromociones datos)
        {
            List<CENPromocionesLista> list_promociones = new List<CENPromocionesLista>();
            CENPromocionesLista objPromocionesLista = null;

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_promocion_filtros", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@codfechaI", SqlDbType.Char).Value = datos.codfechaI;
                cmd.Parameters.Add("@codfechaF", SqlDbType.Char).Value = datos.codfechaF;

                cmd.Parameters.Add("@codProveedor", SqlDbType.Int).Value = datos.codProveedor;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = datos.estado;
                cmd.Parameters.Add("@codCliente", SqlDbType.Int).Value = datos.codCliente;
                cmd.Parameters.Add("@codVendedor", SqlDbType.Int).Value = datos.codVendedor;
                cmd.Parameters.Add("@codProducto", SqlDbType.Char).Value = datos.codProducto;
                cmd.Parameters.Add("@codTipoVenta", SqlDbType.Int).Value = datos.codTipoVenta;

                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objPromocionesLista = new CENPromocionesLista();
                    objPromocionesLista.codPromocion = Convert.ToInt32(dr["ntraPromocion"]);
                    objPromocionesLista.promocion = Convert.ToString(dr["nombrePromo"]);
                    objPromocionesLista.codProducto = Convert.ToString(dr["codProducto"]);
                    objPromocionesLista.producto = Convert.ToString(dr["producto"]);
                    objPromocionesLista.codfechaI = Convert.ToDateTime(dr["fechaInicial"]).ToString("dd/MM/yyyy");
                    objPromocionesLista.codfechaF = Convert.ToDateTime(dr["fechaFin"]).ToString("dd/MM/yyyy");
                    objPromocionesLista.codProveedor = Convert.ToInt32(dr["codProveedor"]);
                    objPromocionesLista.proveedor = Convert.ToString(dr["proveedor"]);

                    objPromocionesLista.codhoraI = Convert.ToString(dr["horaInicial"]);
                    objPromocionesLista.codhoraF = Convert.ToString(dr["horaFin"]);

                    objPromocionesLista.codEstado = Convert.ToInt32(dr["estado"]);
                    objPromocionesLista.estado = Convert.ToString(dr["estadoPromo"]);
                    objPromocionesLista.cantidadProd = Convert.ToString(dr["cantImporte"]);
                    objPromocionesLista.codUnidadBase = Convert.ToInt32(dr["tipoImporte"]);
                    objPromocionesLista.desUnidadBase = Convert.ToString(dr["descImporte"]);
                    objPromocionesLista.tipoProm = Convert.ToInt32(dr["codTipoVenta"]);
                    objPromocionesLista.detTipoProm = Convert.ToString(dr["tipoVenta"]);
                    objPromocionesLista.codVendAplica = Convert.ToInt32(dr["codVendedor"]);
                    objPromocionesLista.desVendAplica = Convert.ToString(dr["vendedor"]);
                    objPromocionesLista.codClienteAplica = Convert.ToInt32(dr["codPersona"]);
                    objPromocionesLista.desClienetAplica = Convert.ToString(dr["cliente"]);

                    objPromocionesLista.vecesUsarProm = Convert.ToInt32(dr["cantVecesUsarProm"]);
                    objPromocionesLista.vecesUsarPromXvend = Convert.ToInt32(dr["cantVecesUsarXvendedor"]);
                    objPromocionesLista.vecesUsarPromXcliente = Convert.ToInt32(dr["cantVecesUsarXcliente"]);

                    list_promociones.Add(objPromocionesLista);
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

            return list_promociones;
        }

        public int ElimiarPromocion(CENPromocionesLista objtPromocionesAD)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_eliminar_promociones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codProm", objtPromocionesAD.codPromocion);
                cmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
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



        public List<CENDetallePromocion> ListarDetalle(int codPromocion)
        {
            List<CENDetallePromocion> listaDetalle = new List<CENDetallePromocion>();
            CENDetallePromocion objCENDetallePreventa = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CADConexion CadCx = new CADConexion();

            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_promocion_detalle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@npromocion", SqlDbType.Int).Value = codPromocion;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCENDetallePreventa = new CENDetallePromocion();
                    objCENDetallePreventa.item = Convert.ToInt32(dr["ntraPromocion"]);
                    objCENDetallePreventa.codProductoProm = Convert.ToString(dr["codProductoReg"]);
                    objCENDetallePreventa.descripcionProd = Convert.ToString(dr["prodRegalar"]);
                    objCENDetallePreventa.cantidad = Convert.ToInt32(dr["cantidad"]);
                    objCENDetallePreventa.precio = Convert.ToString(dr["precioProdReg"]);

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



        public List<string> InsertarPromociones(CENPromocionesInsert objProduc)
        {
            string response;
            //string response2;

            var respuesta = new List<string>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {
                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_insertar_promociones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", objProduc.nomPromo);
                cmd.Parameters.AddWithValue("@fechaInicial", objProduc.fechaI);
                cmd.Parameters.AddWithValue("@fechaFin", objProduc.fechaF);
                cmd.Parameters.AddWithValue("@horaInicial", objProduc.horaI);
                cmd.Parameters.AddWithValue("@horaFin", objProduc.horaF);
                cmd.Parameters.AddWithValue("@estado", objProduc.activoInactivo);

                cmd.Parameters.AddWithValue("@descripcion1", objProduc.decPrdPrin);
                cmd.Parameters.AddWithValue("@valorInicial1", objProduc.codProdPrin);

                cmd.Parameters.AddWithValue("@descripcion2", objProduc.desCantdadSoles);
                cmd.Parameters.AddWithValue("@valorInicial2", objProduc.monto);
                cmd.Parameters.AddWithValue("@valorFinal2", objProduc.codCantdadSoles);

                cmd.Parameters.AddWithValue("@descripcion4", objProduc.desVendedorAplica);
                cmd.Parameters.AddWithValue("@valorInicial4", objProduc.codVendedorAplica);

                cmd.Parameters.AddWithValue("@descripcion5", objProduc.desClienteAplica);
                cmd.Parameters.AddWithValue("@valorInicial5", objProduc.codClienteAplica);

                cmd.Parameters.AddWithValue("@valorInicial6", objProduc.vecesUsarProm);

                cmd.Parameters.AddWithValue("@valorInicial7", objProduc.vecesUsarPromXvendedor);

                cmd.Parameters.AddWithValue("@valorInicial8", objProduc.vecesUsarPromXcliente);

                cmd.Parameters.AddWithValue("@descripcion9", objProduc.desContadoCredito);
                cmd.Parameters.AddWithValue("@valorInicial9", objProduc.codContadoCredito);

                cmd.Parameters.Add("@resultado", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@codregistro", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;



                con.Open();
                cmd.ExecuteNonQuery();
                response = Convert.ToString(cmd.Parameters["@resultado"].Value);
                //response2 = Convert.ToString(cmd.Parameters["@codregistro"].Value);
                respuesta.Add(response);
                //respuesta.Add(response2);
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







        public int InsertarDetPrmocion(CEN_Detalle_Flag_Promocion objProd)
        {
            int response = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_insertar_detalleflagpromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcionDet", objProd.descPrdoReg);
                cmd.Parameters.AddWithValue("@valorEntero1Det", objProd.cantProductoReg);
                cmd.Parameters.AddWithValue("@valorMoneda1Det", objProd.costoProdReg);
                cmd.Parameters.AddWithValue("@valorCadena1Det", objProd.codProductoReg);
                cmd.Parameters.AddWithValue("@valorCadena2Det", objProd.idUnidBaseProdReg);

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
