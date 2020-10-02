using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENPagoTransferencia
    {

        public string nroTransferencia { get; set; }
        public string cuentaTransferencia { get; set; }
        public string banco { get; set; }
        public decimal importe { get; set; }
        public Int16 tipoMoneda { get; set; }
        public DateTime fechaTransferencia { get; set; }
        public Int16 estado { get; set; }
    }
}
