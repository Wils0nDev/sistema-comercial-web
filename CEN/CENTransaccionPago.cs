using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENTransaccionPago
    {
        public int ntraTransaccionPago { get; set; }
        public int? codPrestamo { get; set; }
        public int? nroCuota { get; set; }
        public int codVenta { get; set; }
        public Int16 ntraMedioPago { get; set; }
        public decimal tipoCambio { get; set; }
        public Int16 tipoMoneda { get; set; }
        public decimal IGV { get; set; }
        public Int16 estado { get; set; }
    }
}
