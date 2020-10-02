using CEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CAD
{
    public class CADCliente
    {
        public List<CENCliente> ListarClientes(int auxtipoDocumento, string auxNumDocumento, string auxNombres)
        {
            List<CENCliente> listCliente = new List<CENCliente>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //Conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("pa_listar_clientes", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_tipoDocumento", SqlDbType.TinyInt).Value = auxtipoDocumento;
                        Command.Parameters.Add("@p_numDocumento", SqlDbType.VarChar, CENConstante.g_const_15).Value = auxNumDocumento.Trim();
                        Command.Parameters.Add("@p_nombres", SqlDbType.VarChar, CENConstante.g_const_70).Value = auxNombres;

                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENCliente dataCliente = new CENCliente();

                            dataCliente.codPersona = Convert.ToInt32(dr["codPersona"]);
                            dataCliente.tipoPersona = Convert.ToByte(dr["tipoPersona"]);
                            dataCliente.descTipoPersona = SeleccionarConcepto(1, 1, dataCliente.tipoPersona);
                            dataCliente.tipoDocumento = Convert.ToByte(dr["tipoDocumento"]);
                            dataCliente.descTipoDocumento = SeleccionarConcepto(1, 2, dataCliente.tipoDocumento);
                            if (dr["numeroDocumento"] != DBNull.Value)
                                dataCliente.numeroDocumento = Convert.ToString(dr["numeroDocumento"]);
                            if (dr["ruc"] != DBNull.Value)
                                dataCliente.ruc = Convert.ToString(dr["ruc"]);
                            if (dr["razonSocial"] != DBNull.Value)
                                dataCliente.razonSocial = Convert.ToString(dr["razonSocial"]);
                            if (dr["nombres"] != DBNull.Value)
                                dataCliente.nombres = Convert.ToString(dr["nombres"]);
                            if (dr["apellidoPaterno"] != DBNull.Value)
                                dataCliente.apellidoPaterno = Convert.ToString(dr["apellidoPaterno"]);
                            if (dr["apellidoMaterno"] != DBNull.Value)
                                dataCliente.apellidoMaterno = Convert.ToString(dr["apellidoMaterno"]);
                            dataCliente.direccion = Convert.ToString(dr["direccion"]);
                            if (dr["correo"] != DBNull.Value)
                                dataCliente.correo = Convert.ToString(dr["correo"]);
                            if (dr["telefono"] != DBNull.Value)
                                dataCliente.telefono = Convert.ToString(dr["telefono"]);
                            if (dr["celular"] != DBNull.Value)
                                dataCliente.celular = Convert.ToString(dr["celular"]);
                            if (dr["perfilCliente"] != DBNull.Value)
                            {
                                dataCliente.perfilCliente = Convert.ToByte(dr["perfilCliente"]);
                                dataCliente.descPerfilCliente = SeleccionarConcepto(1, 3, dataCliente.perfilCliente);
                            }
                            if (dr["clasificacionCliente"] != DBNull.Value)
                            {
                                dataCliente.clasificacionCliente = Convert.ToByte(dr["clasificacionCliente"]);
                                dataCliente.descClasificacion = SeleccionarConcepto(1, 4, dataCliente.clasificacionCliente);
                            }
                            if (dr["frecuenciaCliente"] != DBNull.Value)
                            {
                                dataCliente.frecuenciaCliente = Convert.ToByte(dr["frecuenciaCliente"]);
                                dataCliente.descFrecuencia = SeleccionarConcepto(1, 5, dataCliente.frecuenciaCliente);
                            }
                            if (dr["tipoListaPrecio"] != DBNull.Value)
                            {
                                dataCliente.tipoListaPrecio = Convert.ToByte(dr["tipoListaPrecio"]);
                                dataCliente.descTipoListaPrecio = SeleccionarConcepto(1, 7, dataCliente.tipoListaPrecio);
                            }
                            if (dr["codRuta"] != DBNull.Value)
                            {
                                dataCliente.codRuta = Convert.ToInt32(dr["codRuta"]);
                                dataCliente.descCodRuta = SeleccionarConcepto(2, dataCliente.codRuta, 0);
                            }
                            if (dr["ordenAtencion"] != DBNull.Value)
                                dataCliente.ordenAtencion = Convert.ToInt16(dr["ordenAtencion"]);
                            if (dr["codUbigeo"] != DBNull.Value)
                                dataCliente.codUbigeo = Convert.ToString(dr["codUbigeo"]);
                            else
                                dataCliente.codUbigeo = "";

                            if (dr["coordenadaX"] != DBNull.Value)
                                dataCliente.coordenadaX = Convert.ToString(dr["coordenadaX"]);
                            else
                                dataCliente.coordenadaX = "";

                            if (dr["coordenadaY"] != DBNull.Value)
                                dataCliente.coordenadaY = Convert.ToString(dr["coordenadaY"]);
                            else
                                dataCliente.coordenadaY = "";

                            listCliente.Add(dataCliente);
                        }
                    }
                    dr.Close();
                    Connection.Close();
                }
                return listCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string SeleccionarConcepto(int auxflag, int auxCodigo, int auxCorrelativo)
        {
            string desc = "";

            //DESCRIPCION: Seleccionar concepto
            CADConexion CadCx = new CADConexion(); //Conexion

            try
            {
                using (SqlConnection Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SELECT dbo.fu_buscar_descripcion_concepto(@p_flag, @p_codigo, @p_correlativo)", Connection))
                    {
                        Command.Parameters.Add("@p_flag", SqlDbType.Int).Value = auxflag;
                        Command.Parameters.Add("@p_codigo", SqlDbType.Int).Value = auxCodigo;
                        Command.Parameters.Add("@p_correlativo", SqlDbType.Int).Value = auxCorrelativo;

                        Command.CommandTimeout = CENConstante.g_const_0;
                        desc = Convert.ToString(Command.ExecuteScalar());

                    }
                    Connection.Close();
                }
                return desc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CENConcepto> ListarConceptos(int auxflag)
        {
            List<CENConcepto> listConcepto = new List<CENConcepto>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_datos_select_x_flag", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@flag", SqlDbType.Int).Value = auxflag;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENConcepto dataConcepto = new CENConcepto();

                            dataConcepto.correlativo = Convert.ToInt32(dr["correlativo"]);
                            dataConcepto.descripcion = Convert.ToString(dr["descripcion"]);

                            listConcepto.Add(dataConcepto);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listConcepto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENDepartamento> ListarDepartamentos(int auxflag)
        {
            List<CENDepartamento> listDep = new List<CENDepartamento>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_datos_select_x_flag", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@flag", SqlDbType.Int).Value = auxflag;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        CENDepartamento dataDepartamento1 = new CENDepartamento();

                        dataDepartamento1.codDepartamento = "00";
                        dataDepartamento1.nombre = "SELECCIONAR";

                        listDep.Add(dataDepartamento1);

                        while (dr.Read())
                        {
                            CENDepartamento dataDepartamento = new CENDepartamento();

                            dataDepartamento.codDepartamento = Convert.ToString(dr["codDepartamento"]);
                            dataDepartamento.nombre = Convert.ToString(dr["nombre"]);

                            listDep.Add(dataDepartamento);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listDep;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENProvincia> ListarProvincias(int auxflag)
        {
            List<CENProvincia> listProvincia = new List<CENProvincia>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_datos_select_x_flag", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@flag", SqlDbType.Int).Value = auxflag;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENProvincia dataProvincia = new CENProvincia();

                            dataProvincia.codDepartamento = Convert.ToString(dr["codDepartamento"]);
                            dataProvincia.codProvincia = Convert.ToString(dr["codProvincia"]);
                            dataProvincia.nombre = Convert.ToString(dr["nombre"]);

                            listProvincia.Add(dataProvincia);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listProvincia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENDistrito> ListarDistritos(int auxflag)
        {
            List<CENDistrito> listDistrito = new List<CENDistrito>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_datos_select_x_flag", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@flag", SqlDbType.Int).Value = auxflag;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENDistrito dataDistrito = new CENDistrito();

                            dataDistrito.codDepartamento = Convert.ToString(dr["codDepartamento"]);
                            dataDistrito.codProvincia = Convert.ToString(dr["codProvincia"]);
                            dataDistrito.codDistrito = Convert.ToString(dr["codDistrito"]);
                            dataDistrito.nombre = Convert.ToString(dr["nombre"]);

                            listDistrito.Add(dataDistrito);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listDistrito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CENPuntoEntrega> ListarPuntosEntrega(Int32 auxCodPersona)
        {
            List<CENPuntoEntrega> listPuntosEntrega = new List<CENPuntoEntrega>();

            //DESCRIPCION: Lista de Puntos de Entrega del Cliente
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_puntosEntrega_Cliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_codPersona", SqlDbType.Int).Value = auxCodPersona;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENPuntoEntrega dataPuntoEntrega = new CENPuntoEntrega();

                            dataPuntoEntrega.ntraPuntoEntrega = Convert.ToInt32(dr["ntraPuntoEntrega"]);
                            if (dr["ordenEntrega"] != DBNull.Value)
                                dataPuntoEntrega.ordenEntrega = Convert.ToInt16(dr["ordenEntrega"]);
                            if (dr["codUbigeo"] != DBNull.Value)
                                dataPuntoEntrega.codUbigeo = Convert.ToString(dr["codUbigeo"]);
                            else
                                dataPuntoEntrega.codUbigeo = "";
                            dataPuntoEntrega.coordenadaX = Convert.ToString(dr["coordenadaX"]);
                            dataPuntoEntrega.coordenadaY = Convert.ToString(dr["coordenadaY"]);
                            dataPuntoEntrega.direccion = Convert.ToString(dr["direccion"]);
                            if (dr["referencia"] != DBNull.Value)
                                dataPuntoEntrega.referencia = Convert.ToString(dr["referencia"]);

                            listPuntosEntrega.Add(dataPuntoEntrega);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listPuntosEntrega;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarCliente(int auxCodPersona)
        {
            //DESCRIPCION: Eliminar Clientes y los Puntos de Entrega del Cliente
            CADConexion CadCx = new CADConexion(); //conexion

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_eliminar_cliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_codPersona", SqlDbType.Int).Value = auxCodPersona;

                        command.CommandTimeout = CENConstante.g_const_0;
                        command.ExecuteReader();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarCliente(CENCliente data)
        {
            //DESCRIPCION: Modificar Clientes y los Puntos de Entrega del Cliente
            CADConexion CadCx = new CADConexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_registrar_modificar_cliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_proceso", SqlDbType.TinyInt).Value = CENConstante.g_const_2;
                        command.Parameters.Add("@p_codigo", SqlDbType.Int).Value = data.codPersona;
                        command.Parameters.Add("@p_tipoPersona", SqlDbType.TinyInt).Value = data.tipoPersona;
                        command.Parameters.Add("@p_tipoDocumento", SqlDbType.TinyInt).Value = data.tipoDocumento;
                        command.Parameters.Add("@p_numDocumento", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.numeroDocumento;
                        command.Parameters.Add("@p_ruc", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.ruc;
                        command.Parameters.Add("@p_razonSocial", SqlDbType.VarChar, CENConstante.g_const_50).Value = data.razonSocial.ToUpper();
                        command.Parameters.Add("@p_nombres", SqlDbType.VarChar, CENConstante.g_const_30).Value = data.nombres.ToUpper();
                        command.Parameters.Add("@p_apePaterno", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.apellidoPaterno.ToUpper();
                        command.Parameters.Add("@p_apeMaterno", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.apellidoMaterno.ToUpper();
                        command.Parameters.Add("@p_direccion", SqlDbType.VarChar, CENConstante.g_const_200).Value = data.direccion.ToUpper();
                        command.Parameters.Add("@p_correo", SqlDbType.VarChar, CENConstante.g_const_60).Value = data.correo;
                        command.Parameters.Add("@p_telefono", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.telefono;
                        command.Parameters.Add("@p_celular", SqlDbType.Char, CENConstante.g_const_9).Value = data.celular;
                        command.Parameters.Add("@p_ubigeo", SqlDbType.Char, CENConstante.g_const_6).Value = data.codUbigeo;
                        command.Parameters.Add("@p_ordenAtencion", SqlDbType.SmallInt).Value = data.ordenAtencion;
                        command.Parameters.Add("@p_perfilCliente", SqlDbType.TinyInt).Value = data.perfilCliente;
                        command.Parameters.Add("@p_clasificacion", SqlDbType.TinyInt).Value = data.clasificacionCliente;
                        command.Parameters.Add("@p_frecuencia", SqlDbType.TinyInt).Value = data.frecuenciaCliente;
                        command.Parameters.Add("@p_tipoListaPrecio", SqlDbType.TinyInt).Value = data.tipoListaPrecio;
                        command.Parameters.Add("@p_codRuta", SqlDbType.Int).Value = data.codRuta;
                        command.Parameters.Add("@p_usuario", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";
                        command.Parameters.Add("@p_ip", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";
                        command.Parameters.Add("@p_mac", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";
                        command.Parameters.Add("@p_coordenadaX", SqlDbType.VarChar, CENConstante.g_const_100).Value = data.coordenadaX;
                        command.Parameters.Add("@p_coordenadaY", SqlDbType.VarChar, CENConstante.g_const_100).Value = data.coordenadaY;

                        command.CommandTimeout = CENConstante.g_const_0;
                        command.ExecuteReader();
                    }
                    connection.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int registrarCliente(CENCliente data)
        {
            //DESCRIPCION: Registrar Clientes y los Puntos de Entrega del Cliente
            int codPersona = 0;
            CADConexion CadCx = new CADConexion();
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_registrar_modificar_cliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_proceso", SqlDbType.TinyInt).Value = CENConstante.g_const_1;
                        command.Parameters.Add("@p_codigo", SqlDbType.Int).Value = data.codPersona;
                        command.Parameters.Add("@p_tipoPersona", SqlDbType.TinyInt).Value = data.tipoPersona;
                        command.Parameters.Add("@p_tipoDocumento", SqlDbType.TinyInt).Value = data.tipoDocumento;
                        command.Parameters.Add("@p_numDocumento", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.numeroDocumento;
                        command.Parameters.Add("@p_ruc", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.ruc;
                        command.Parameters.Add("@p_razonSocial", SqlDbType.VarChar, CENConstante.g_const_50).Value = data.razonSocial;
                        command.Parameters.Add("@p_nombres", SqlDbType.VarChar, CENConstante.g_const_30).Value = data.nombres.ToUpper();
                        command.Parameters.Add("@p_apePaterno", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.apellidoPaterno.ToUpper();
                        command.Parameters.Add("@p_apeMaterno", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.apellidoMaterno.ToUpper();
                        command.Parameters.Add("@p_direccion", SqlDbType.VarChar, CENConstante.g_const_200).Value = data.direccion.ToUpper();
                        command.Parameters.Add("@p_correo", SqlDbType.VarChar, CENConstante.g_const_60).Value = data.correo;
                        command.Parameters.Add("@p_telefono", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.telefono;
                        command.Parameters.Add("@p_celular", SqlDbType.Char, CENConstante.g_const_9).Value = data.celular;
                        command.Parameters.Add("@p_ubigeo", SqlDbType.Char, CENConstante.g_const_6).Value = data.codUbigeo;
                        command.Parameters.Add("@p_ordenAtencion", SqlDbType.SmallInt).Value = data.ordenAtencion;
                        command.Parameters.Add("@p_perfilCliente", SqlDbType.TinyInt).Value = data.perfilCliente;
                        command.Parameters.Add("@p_clasificacion", SqlDbType.TinyInt).Value = data.clasificacionCliente;
                        command.Parameters.Add("@p_frecuencia", SqlDbType.TinyInt).Value = data.frecuenciaCliente;
                        command.Parameters.Add("@p_tipoListaPrecio", SqlDbType.TinyInt).Value = data.tipoListaPrecio;
                        command.Parameters.Add("@p_codRuta", SqlDbType.Int).Value = data.codRuta;
                        command.Parameters.Add("@p_usuario", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";
                        command.Parameters.Add("@p_ip", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";
                        command.Parameters.Add("@p_mac", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";
                        command.Parameters.Add("@p_coordenadaX", SqlDbType.VarChar, CENConstante.g_const_100).Value = data.coordenadaX;
                        command.Parameters.Add("@p_coordenadaY", SqlDbType.VarChar, CENConstante.g_const_100).Value = data.coordenadaY;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            codPersona = Convert.ToInt32(dr["codPersona"].ToString());
                        }

                    }
                    connection.Close();

                }
                return codPersona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Byte buscarDniCliente(int dni)
        {
            //DESCRIPCION: Seleccionar concepto
            Byte val = 0;
            CADConexion CadCx = new CADConexion(); //Conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("pa_buscar_dni_cliente", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_dni", SqlDbType.Int).Value = dni;

                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();

                        while (dr.Read())
                        {

                            val = Convert.ToByte(dr["val"]);

                        }

                    }
                    dr.Close();
                    Connection.Close();
                }
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void registrarEliminarPuntoEntrega(int tPro, CENPuntoEntrega data)
        {
            //DESCRIPCION: Registrar los Puntos de Entrega del Cliente
            CADConexion CadCx = new CADConexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_registrar_modificar_punto_entrega", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_proceso", SqlDbType.TinyInt).Value = tPro;
                        command.Parameters.Add("@p_ntra", SqlDbType.Int).Value = data.ntraPuntoEntrega;
                        command.Parameters.Add("@p_coordenadaX", SqlDbType.VarChar, CENConstante.g_const_100).Value = data.coordenadaX;
                        command.Parameters.Add("@p_coordenadaY", SqlDbType.VarChar, CENConstante.g_const_100).Value = data.coordenadaY;
                        command.Parameters.Add("@p_codUbigeo", SqlDbType.Char, CENConstante.g_const_6).Value = data.codUbigeo;
                        command.Parameters.Add("@p_direccion", SqlDbType.VarChar, CENConstante.g_const_200).Value = data.direccion;
                        command.Parameters.Add("@p_referencia", SqlDbType.VarChar, CENConstante.g_const_200).Value = data.referencia;
                        command.Parameters.Add("@p_ordenEntrega", SqlDbType.SmallInt).Value = data.ordenEntrega;
                        command.Parameters.Add("@p_codPersona", SqlDbType.Int).Value = data.codPersona;
                        command.Parameters.Add("@p_usuario", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";
                        command.Parameters.Add("@p_ip", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";
                        command.Parameters.Add("@p_mac", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";

                        command.CommandTimeout = CENConstante.g_const_0;
                        command.ExecuteReader();

                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENProvincia> ListarProvinciasRegistro(string codDepartamento, string codProvincia)
        {
            List<CENProvincia> listProvincia = new List<CENProvincia>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_provincias", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_codDep", SqlDbType.Char).Value = codDepartamento;
                        command.Parameters.Add("@p_codProv", SqlDbType.Char).Value = codProvincia;
                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENProvincia dataProvincia = new CENProvincia();

                            dataProvincia.codDepartamento = Convert.ToString(dr["codDepartamento"]);
                            dataProvincia.codProvincia = Convert.ToString(dr["codProvincia"]);
                            dataProvincia.nombre = Convert.ToString(dr["nombre"]);

                            listProvincia.Add(dataProvincia);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listProvincia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CENDistrito> ListarDistritosRegistro(string codDepartamento, string codProvincia, string codDistrito)
        {
            List<CENDistrito> listDistrito = new List<CENDistrito>();

            //DESCRIPCION: Lista de clientes
            CADConexion CadCx = new CADConexion(); //conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_listar_distritos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_codDep", SqlDbType.Char).Value = codDepartamento;
                        command.Parameters.Add("@p_codProv", SqlDbType.Char).Value = codProvincia;
                        command.Parameters.Add("@p_codDis", SqlDbType.Char).Value = codDistrito;
                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            CENDistrito dataDistrito = new CENDistrito();

                            dataDistrito.codDepartamento = Convert.ToString(dr["codDepartamento"]);
                            dataDistrito.codProvincia = Convert.ToString(dr["codProvincia"]);
                            dataDistrito.codDistrito = Convert.ToString(dr["codDistrito"]);
                            dataDistrito.nombre = Convert.ToString(dr["nombre"]);

                            listDistrito.Add(dataDistrito);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                return listDistrito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarRUCCliente(string ruc)
        {
            //DESCRIPCION: Seleccionar concepto
            int val = 0;
            CADConexion CadCx = new CADConexion(); //Conexion
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection Connection = new SqlConnection(CadCx.CxSQL()))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("pa_existe_ruc_cliente", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Add("@p_ruc", SqlDbType.VarChar, CENConstante.g_const_11).Value = ruc;

                        Command.CommandTimeout = CENConstante.g_const_0;
                        dr = Command.ExecuteReader();

                        while (dr.Read())
                        {

                            val = Convert.ToInt32(dr["val"].ToString());

                        }

                    }
                    dr.Close();
                    Connection.Close();
                }
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
