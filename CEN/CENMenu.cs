using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{

    public class CENMenu : CENModulo
    {
        //datos del modulo
        public string nomModulo { set; get; }

        public int codigoModulo { get; set; }

        public int ordenModulo { set; get; }

        //detalle del modulo

        public string nomSubMenu { set; get; }

        public string rutaSubMenu { set; get; }

        public int codigoSubMenu { set; get; }

        public int ordenSubMenu { set; get; }

        public int codModFK { get; set; }

        public int codPermisoFK { get; set; }

        //flag de validacion

        public int respuesta { set; get; }

    }

}
