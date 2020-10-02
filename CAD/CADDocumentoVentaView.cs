using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADDocumentoVentaView
    {
        //DESCRIPCION: METODO QUE ME TRAE LA LISTA DE LA VISTA v_listar_rutas_asignadas_x_vendedor
        public List<CENDocumentoVentaView> ListarDocumentosVenta(
            Int16 flagFiltro, int fechaActual, int codEstado, int codCliente,
            int codVendedor, string fechaInicial, string fechaFinal, int codTipoDoc,int ntraVenta, string serie, int numdoc)
        {

            List<CENDocumentoVentaView> ListaDV = new List<CENDocumentoVentaView>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CENDocumentoVentaView objDocVenta = null;

            CADConexion CadCx = new CADConexion();
            try
            {

                con = new SqlConnection(CadCx.CxSQL());
                cmd = new SqlCommand("pa_listar_detalle_documento_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_flagFiltro", SqlDbType.Int).Value = flagFiltro;
                cmd.Parameters.Add("@p_fechaActual", SqlDbType.Int).Value = fechaActual;
                cmd.Parameters.Add("@p_estado", SqlDbType.SmallInt).Value = codEstado;
                cmd.Parameters.Add("@p_cliente", SqlDbType.Int).Value = codCliente;
                cmd.Parameters.Add("@p_vendedor", SqlDbType.Int).Value = codVendedor;
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

                cmd.Parameters.Add("@p_codTipoDoc", SqlDbType.Int).Value = codTipoDoc;

                if (ntraVenta == 0)
                {
                    cmd.Parameters.Add("@p_codFactura", SqlDbType.Int).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@p_codFactura", SqlDbType.Int).Value = ntraVenta;
                }

                if (serie == "")
                {
                    cmd.Parameters.Add("@p_serie", SqlDbType.VarChar).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@p_serie", SqlDbType.VarChar).Value = serie;
                }
                if (numdoc == 0)
                {
                    cmd.Parameters.Add("@p_nroDocumento", SqlDbType.Int).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@p_nroDocumento", SqlDbType.Int).Value = numdoc;
                }


                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Crear objeto Documento Venta
                    objDocVenta = new CENDocumentoVentaView();
                   
                    objDocVenta.ntraVenta = Convert.ToInt32(dr["ntraVenta"]);
                    objDocVenta.serie = dr["serie"].ToString();
                    objDocVenta.nroDocumento = Convert.ToInt32(dr["nroDocumento"].ToString());
                    objDocVenta.descdocumento = dr["descdocumento"].ToString();
                    objDocVenta.cliente = dr["cliente"].ToString();
                    objDocVenta.razonSocial = dr["razonSocial"].ToString();
                    objDocVenta.vendedor = dr["vendedor"].ToString();
                    objDocVenta.fechaTransaccion = dr["fechaTransaccion"].ToString();
                    objDocVenta.fechaTransaccion = dr["fechaTransaccion"].ToString();
                    objDocVenta.fechaPago = dr["fechaPago"].ToString();
                    objDocVenta.importeTotal = Convert.ToDecimal(dr["importeTotal"].ToString());
                    objDocVenta.estado = dr["estado"].ToString();
                    objDocVenta.tipoVenta = Convert.ToInt32(dr["tipoVenta"]);
                    objDocVenta.descriptipoventa = dr["descriptipoventa"].ToString();
                    objDocVenta.estadov = Convert.ToInt16(dr["estadov"].ToString());
                    objDocVenta.tipoMoneda = Convert.ToDecimal(dr["tipoMoneda"].ToString());
                    objDocVenta.igv = Convert.ToDecimal(dr["igv"].ToString());
                    if (dr["estadoc"].ToString() == "")
                    {
                        objDocVenta.estadoc = 0;
                    }
                    else
                    {
                        objDocVenta.estadoc = Convert.ToInt16(dr["estadoc"].ToString());
                    }

                    if (dr["importecxc"].ToString() == "")
                    {
                        objDocVenta.importecxc = 0;
                    }
                    else
                    {
                        objDocVenta.importecxc = Convert.ToDecimal(dr["importecxc"].ToString());
                    }
                    if (dr["importeP"].ToString() == "")
                    {
                        objDocVenta.importeP =0;

                    }
                    else
                    {
                        objDocVenta.importeP = Convert.ToDecimal(dr["importeP"].ToString());

                    }
                    if (dr["estadoP"].ToString() == "")
                    {
                        objDocVenta.estadoP = 0;

                    }
                    else
                    {
                        objDocVenta.estadoP = Convert.ToInt16(dr["estadoP"].ToString());

                    }
                    objDocVenta.moneda = dr["moneda"].ToString();




                    ListaDV.Add(objDocVenta);

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
            return ListaDV;
        }
    }
}
