using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENCaja
    {
        public int ntraCaja { get; set; }
        public string descripcion { get; set; }
        public string tipoRegistro { get; set; }
        public int ntraUsuario { get; set; }
        public string users { get; set; }
        public string nombreCompleto { get; set; }
        public int ntraSucursal { get; set; }
        public string sucursal { get; set; }
        public string fechaCreacion { get; set; }
        public string horaCreacion { get; set; }
        public int codEstado { get; set; }
        public string estado { get; set; }
        public List<CENTipoMovimiento> listaTipoMovimientos { get; set; } //Lista de tipos de movimientos de caja
    }

    public class CENAperturaCaja
    {
        public int ntraAperturaCaja { get; set; }
        public int ntraCaja { get; set; }
        public string caja { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public decimal saldoSoles { get; set; }
        public decimal saldoDolares { get; set; }
        public int codEstado { get; set; }
        public string estado { get; set; }
        public int marcaBaja { get; set; }
    }

    public class CENCierreCaja
    {
        public int ntraCierreCaja { get; set; }
        public int ntraCaja { get; set; }
        public string caja { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public decimal saldoSoles { get; set; }
        public decimal saldoDolares { get; set; }
        public decimal saldoSolesCierre { get; set; }
        public decimal saldoDolaresCierre { get; set; }
        public decimal difSaldoSoles { get; set; }
        public decimal difSaldoDolares { get; set; }
        public int marcaBaja { get; set; }
    }

    public class CENTransaccionCaja
    {
        public int ntraTransaccionCaja { get; set; }
        public int ntraCaja { get; set; }
        public string caja { get; set; }
        public int codTipoRegistro { get; set; }
        public string tipoRegistro { get; set; }
        public int ntraTipoMovimiento { get; set; }
        public string tipoMovimieno { get; set; }
        public string fechaTransaccion { get; set; }
        public string horaTransaccion { get; set; }
        public string codVenta { get; set; }
        public int codTipoTransaccion { get; set; }
        public string tipoTransaccion { get; set; }
        public int codModoPago { get; set; }
        public string modoPago { get; set; }
        public int codTipoMoneda { get; set; }
        public string tipoMoneda { get; set; }
        public decimal importe { get; set; }
        public int marcaBaja { get; set; }
    }
}
