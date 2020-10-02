using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENPagoEfectivo
    {
        public decimal importe { get; set; }
        public decimal? vuelto { get; set; }
        public Int16 tipoMoneda { get; set; }
        public Int16 estado { get; set; }

    }
}
