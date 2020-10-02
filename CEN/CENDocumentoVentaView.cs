using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENDocumentoVentaView
    {
        public int ntraVenta { get; set; }
        public string serie  { get; set; }
        public int nroDocumento { get; set; }
        public string descdocumento { get; set; }
        public string cliente { get; set; }
        public string razonSocial { get; set; }
        public string vendedor { get; set; }
        public string fechaTransaccion { get; set; }
        public string fechaPago { get; set; }
        public decimal importeTotal { get; set; }
        public string estado { get; set; }
        public int tipoVenta { get; set; }
        public string descriptipoventa { get; set; }
        public Int16 estadov { get; set; }
        public decimal igv { get; set; }
        public decimal tipoMoneda { get; set; }
        public Int16? estadoc { get; set; }
        public decimal? importecxc { get; set; }
        public decimal?  importeP { get; set; }
        public Int16? estadoP { get; set; }
        public string moneda { get; set; }
    }
}
