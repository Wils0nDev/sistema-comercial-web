using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENCuentaCobro
    {
        public int ntra {get; set;}
        public int codOperacion { get; set; }
        public int codModulo {get; set;}
        public int prefijo  {get; set;}
        public int correlativo  {get; set;}
	    public decimal importe  {get; set;}
	    public DateTime fechaTransaccion {get; set;}
        public DateTime horaTransaccion {get; set;} 
        public DateTime fechaCobro {get; set;}        
        public Int16 estado {get; set;}
	    public string responsable {get; set;}
        public decimal tipoCambiov { get; set; }
       
    } 
}
