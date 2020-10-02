using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENTrabajador : CENPersona
    {
        public Int16 area { get; set; } 
        public Int16 estadoTrabajador { get; set; } 
        public Int16 tipoTrabajador { get; set; } 
        public Int16 cargo { get; set; }
        public Int16 formaPago { get; set; }
        public string numeroCuenta { get; set; }
        public Int16 tipoRegimen { get; set; }
        public Int32 regimenPensionario { get; set; } 
        public DateTime inicioRegimen { get; set; }
        public Int16 bancoRemuneracion { get; set; }
        public Int16 estadoPlanilla { get; set; }
        public Int16 modalidadContrato { get; set; }
        public Int16 periodicidad { get; set; }
        public DateTime inicioContrato { get; set; }
        public DateTime finContrato { get; set; }
        public DateTime fechaIngreso { get; set; }
        public float sueldo { get; set; }

    }
}
