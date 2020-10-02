using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    [Serializable]
    public class CENPersona 
    {
        public Int32 codPersona { get; set; }
        public Byte tipoPersona { get; set; }
        public string descTipoPersona { get; set; }
        public Byte tipoDocumento { get; set; }
        public string descTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public Int16 estadoCivil { get; set; }
        public Int16 asignacionFamilia { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string codUbigeo { get; set; }
        public string usuario { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }

        public CENPersona()
        {

        }

        public CENPersona(string numeroDocumento, string nombres, string apellidoPaterno,
                             string apellidoMaterno, string correo, string telefono, string celular)
        {
            this.numeroDocumento = numeroDocumento;
            this.nombres = nombres;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.correo = correo;
            this.telefono = telefono;
            this.telefono = telefono;

        }



    }



}
