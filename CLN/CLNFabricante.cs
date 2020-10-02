using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNFabricante
    {
        public CENDatosFabricante Listadatosfabricante()
        {
            //CLASE DE LISTA DE FABRICANTE
            CENDatosFabricante listafabricante = new CENDatosFabricante();
            CADProducto consulta = new CADProducto();
            try
            {
                listafabricante = consulta.CENdatosfabricante();
                return listafabricante;
            }
            catch (Exception ex)
            {
   				 throw ex;
            }
        }

        public List<CENFabricante> ListaFabricante(int flag)
        {
            try
            {
                List<CENFabricante> Listfabricante = new List<CENFabricante>();
                CADProducto fabricante = new CADProducto();

                Listfabricante = fabricante.ListarFabricante(flag);
                return Listfabricante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
