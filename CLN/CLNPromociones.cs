using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
    public class CLNPromociones
    {

        public List<CENPromociones> ListarEstadoPrmocion(int flag)
        {
            CADPromociones objPromociones = null;
            try
            {
                objPromociones = new CADPromociones();

                return objPromociones.ListarEstadoPrmocion(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<CENPromocionesLista> ListarPromociones(CENPromociones datos)
        {
            CADPromociones objCADPromociones = null;

            try
            {
                objCADPromociones = new CADPromociones();
                return objCADPromociones.ListarPromociones(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ElimiarPromocion(CENPromocionesLista objtPromocionesAD)
        {

            CADPromociones objCLNPromociones = null;
            try
            {
                objCLNPromociones = new CADPromociones();
                return objCLNPromociones.ElimiarPromocion(objtPromocionesAD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CENDetallePromocion> ListarDetalle(int codPromocion)
        {
            CADPromociones objCADPreventa = null;
            try
            {
                objCADPreventa = new CADPromociones();
                return objCADPreventa.ListarDetalle(codPromocion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<string> InsertarPromociones(CENPromocionesInsert objProduct)
        {
            CADPromociones objCLNProduct = null;

            try
            {
                objCLNProduct = new CADPromociones();
                return objCLNProduct.InsertarPromociones(objProduct);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        public int InsertarDetPrmocion(CEN_Detalle_Flag_Promocion objDetProducto)
        {
            CADPromociones objCADdetProduct = null;
            try
            {
                objCADdetProduct = new CADPromociones();
                return objCADdetProduct.InsertarDetPrmocion(objDetProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }






    }
}
