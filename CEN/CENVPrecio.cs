using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENVPrecio
    {
        int codProveedor;
        string descProveedor;
        int codFabricante;
        string descFabricante;
        int codCategoria;
        string descCategoria;
        int codSubcategoria;
        string descSubcategoria;
        string codProducto;
        string descProducto;
        decimal precioCosto;

        public int CodProveedor
        {
            get { return codProveedor; }
            set { codProveedor = value; }
        }

        public String DescProveedor
        {
            get { return descProveedor; }
            set { descProveedor = value; }
        }

        public int CodFabricante
        {
            get { return codFabricante; }
            set { codFabricante = value; }
        }

        public string DescFabricante
        {
            get { return descFabricante; }
            set { descFabricante = value; }
        }

        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }

        public string DescCategoria
        {
            get { return descCategoria; }
            set { descCategoria = value; }
        }

        public int CodSubcategoria
        {
            get { return codSubcategoria; }
            set { codSubcategoria = value; }
        }

        public string DescSubcategoria
        {
            get { return descSubcategoria; }
            set { descSubcategoria = value; }
        }

        public string CodProducto
        {
            get { return codProducto; }
            set { codProducto = value; }
        }

        public string DescProducto
        {
            get { return descProducto; }
            set { descProducto = value; }
        }

        public decimal PrecioCosto
        {
            get { return precioCosto; }
            set { precioCosto = value; }
        }
    }
}
