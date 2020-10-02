using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CEN;

namespace CAD
{
    public class CADTrabajador
    {
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
        public int registrarTrabajador(CENTrabajador data)
        {
            //DESCRIPCION: Registrar Trabajador
            int respuesta = 0;
            //int codPersona = 0;
            CADConexion CadCx = new CADConexion();
            SqlDataReader dr; //Data reader

            try
            {
                using (SqlConnection connection = new SqlConnection(CadCx.CxSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_registrar_trabajador", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@p_codigo", SqlDbType.Int).Value = data.codPersona;
                        command.Parameters.Add("@p_tipoPersona", SqlDbType.TinyInt).Value = data.tipoPersona;
                        command.Parameters.Add("@p_tipoDocumento", SqlDbType.TinyInt).Value = data.tipoDocumento;
                        command.Parameters.Add("@p_numDocumento", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.numeroDocumento;
                        command.Parameters.Add("@p_ruc", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.ruc;
                        command.Parameters.Add("@p_nombres", SqlDbType.VarChar, CENConstante.g_const_30).Value = data.nombres.ToUpper();
                        command.Parameters.Add("@p_apePaterno", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.apellidoPaterno.ToUpper();
                        command.Parameters.Add("@p_apeMaterno", SqlDbType.VarChar, CENConstante.g_const_20).Value = data.apellidoMaterno.ToUpper();
                        command.Parameters.Add("@p_fechaNac", SqlDbType.Date).Value = data.fechaNacimiento;
                        command.Parameters.Add("@p_direccion", SqlDbType.VarChar, CENConstante.g_const_200).Value = data.direccion.ToUpper();
                        command.Parameters.Add("@p_correo", SqlDbType.VarChar, CENConstante.g_const_60).Value = data.correo;
                        command.Parameters.Add("@p_telefono", SqlDbType.VarChar, CENConstante.g_const_15).Value = data.telefono;
                        command.Parameters.Add("@p_celular", SqlDbType.Char, CENConstante.g_const_9).Value = data.celular;

                        command.Parameters.Add("@p_usuario", SqlDbType.VarChar, CENConstante.g_const_20).Value = "";

                        command.Parameters.Add("@p_estadoCivil", SqlDbType.SmallInt).Value = data.estadoCivil;
                        command.Parameters.Add("@p_asignacionFamilia ", SqlDbType.SmallInt).Value = data.asignacionFamilia;
                        command.Parameters.Add("@p_area ", SqlDbType.SmallInt).Value = data.area;
                        command.Parameters.Add("@p_estadoTrabajador ", SqlDbType.SmallInt).Value = data.estadoTrabajador;
                        command.Parameters.Add("@p_tipoTrabajador ", SqlDbType.SmallInt).Value = data.tipoTrabajador;
                        command.Parameters.Add("@p_cargo ", SqlDbType.SmallInt).Value = data.tipoTrabajador;
                        command.Parameters.Add("@p_formaPago ", SqlDbType.SmallInt).Value = data.formaPago;
                        command.Parameters.Add("@p_numeroCuenta ", SqlDbType.VarChar, CENConstante.g_const_16).Value = data.numeroCuenta;
                        command.Parameters.Add("@p_tipoRegimen ", SqlDbType.SmallInt).Value = data.tipoRegimen;
                        command.Parameters.Add("@p_regimenPensionario ", SqlDbType.SmallInt).Value = data.regimenPensionario;
                        command.Parameters.Add("@p_incioRegimen ", SqlDbType.Date).Value = data.inicioRegimen;
                        command.Parameters.Add("@p_bancoRemuneracion ", SqlDbType.SmallInt).Value = data.bancoRemuneracion;
                        command.Parameters.Add("@p_estadoPlanilla ", SqlDbType.SmallInt).Value = data.estadoPlanilla;
                        command.Parameters.Add("@p_modalidadContrato ", SqlDbType.SmallInt).Value = data.modalidadContrato;
                        command.Parameters.Add("@p_periodicidad ", SqlDbType.SmallInt).Value = data.periodicidad;
                        command.Parameters.Add("@p_inicioContrato ", SqlDbType.Date).Value = data.inicioContrato;
                        command.Parameters.Add("@p_finContrato ", SqlDbType.Date).Value = data.finContrato;
                        command.Parameters.Add("@p_fechaIngreso ", SqlDbType.Date).Value = data.fechaIngreso;
                        command.Parameters.Add("@p_sueldo ", SqlDbType.Money).Value = data.sueldo;

                        command.CommandTimeout = CENConstante.g_const_0;
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            respuesta = Convert.ToInt32(dr["mensaje"].ToString());
                            //codPersona = Convert.ToInt32(dr["codPersona"].ToString());
                        }

                    }
                    connection.Close();

                }
                return respuesta;
                //return codPersona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
