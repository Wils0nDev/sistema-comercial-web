using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN;
using CAD;

namespace CLN
{
    public class CLNUsuario
    {

       
        public List<CENUsuario> ListarVendedores(int flag)
        {
            CADUsuario uvendedor = null;
            try
            {
                uvendedor = new CADUsuario();

                return uvendedor.ListarVendedores(flag);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<CENUsuario> credencialesUsuario(string usuario, string password, int intento, int sucursal)
            //DESCRIPCION: Retorna los datos del usuario logueado
        {
            CADUsuario objUsuario;
            try
            {
                objUsuario = new CADUsuario();
                return objUsuario.DatosUsuarios(usuario, password, intento,sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CENUsuario> CerrarSesion(int usuario)
            //DESCRIPCION: Graba la hora de finalizacion de sesion
        {
            CADUsuario objUsuario;
            try
            {
                objUsuario = new CADUsuario();
                return objUsuario.CerrarSesion(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENUsuario> ListarCajeros_Sucursal(int flag)
        {
            CADUsuario ucajero = null;
            try
            {
                ucajero = new CADUsuario();

                return ucajero.ListarCajeros_Sucursal(flag);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<CENSucursalVIEW> cargarSucursal(int flag)
        //DESCRIPCION: Lista todas las sucursales registradas
        {
            List<CENSucursalVIEW> ListSuc;

            CADSucursalVIEW sucursal = new CADSucursalVIEW();

            try
            {
                ListSuc = sucursal.cargarSucursal(flag);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ListSuc;
        }

    }
}
