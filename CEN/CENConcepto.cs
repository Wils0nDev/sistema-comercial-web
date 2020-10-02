using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    [Serializable]

    public class CENConcepto
    {
        public List<CENConcepto> lcon = new List<CENConcepto>();

        public Int32 correlativo { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
    }

    public class CENConceptoUbigeo
    {
        public List<CENConcepto> lcon = new List<CENConcepto>();

        public string correlativo { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
    }

}
