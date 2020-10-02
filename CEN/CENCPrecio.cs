using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENCPrecio
    {
        //Cabecera de Precio
        string codProducto;
        string descCategoria;
        string descSubcategoria;
        string descfabricante;
        string descripcion;
        string precioCosto;
        List<CENDPrecio> ldprecios;

        public string CodProducto
        {
            get { return codProducto; }
            set { codProducto = value; }
        }

        public string DescCategoria
        {
            get { return descCategoria; }
            set { descCategoria = value; }
        }
        public string DescSubcategoria
        {
            get { return descSubcategoria; }
            set { descSubcategoria = value; }
        }
        public string DescFabricante
        {
            get { return descfabricante; }
            set { descfabricante = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string PrecioCosto
        {
            get { return precioCosto; }
            set { precioCosto = value; }
        }

        public List<CENDPrecio> Ldprecios
        {
            get { return ldprecios; }
            set { ldprecios = value; }
        }

    }
}
