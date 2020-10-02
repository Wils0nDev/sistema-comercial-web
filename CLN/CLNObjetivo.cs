using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using CEN;

namespace CLN
{
    public class CLNObjetivo
    {
        public int InsertarObjetivos(CENObjetivo objObjetivo)
        {
            CADObjetivo objCLNobjetivo = null;

            try
            {
                objCLNobjetivo = new CADObjetivo();
                return objCLNobjetivo.InsertarObjetivo(objObjetivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CENObjetivoLista> ListarObjetivos(CENObjetivo datos)
        {
            CADObjetivo objCADObjetivo = null;

            try
            {
                objCADObjetivo = new CADObjetivo();
                return objCADObjetivo.ListaObjetivoPorFiltro(datos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
