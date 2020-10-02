using CAD;
using CEN;
using System;
using System.Collections.Generic;

namespace CLN
{
    public class CLNMeta
    {
        public List<CENMetaLista> ListarMetas(CENMeta datos)
        {
            CADMeta objCADMeta = null;

            try
            {
                objCADMeta = new CADMeta();
                return objCADMeta.ListaMetaPorFiltro(datos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int InsertarMetas(CENMeta objMeta)
        {
            CADMeta objCLNMeta = null;

            try
            {
                objCLNMeta = new CADMeta();
                return objCLNMeta.InsertarMeta(objMeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
