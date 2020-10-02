using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    [Serializable]

    public class CENProvincia
    {
        public List<CENProvincia> lprov = new List<CENProvincia>();

        public string codDepartamento { get; set; }
        public string codProvincia { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
    }
}
