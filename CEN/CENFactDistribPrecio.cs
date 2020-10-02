
namespace CEN
{
    public class CENFactDistribPrecio
    {
        public int tipoPrecio { get; set; }
        public string descTipoPrecio { get; set; }
        public int factor { get; set; }

        public int TipoPrecio
        {
            get { return tipoPrecio; }
            set { tipoPrecio = value; }
        }

        public string DescTipoPrecio
        {
            get { return descTipoPrecio; }
            set { descTipoPrecio = value; }
        }
        public int Factor
        {
            get { return factor; }
            set { factor = value; }
        }

    }
}
