using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENMantUsuarioVIEW
    {
        public Int32 ntraUsuario { get; set; } 
        public Int32 codPersona { get; set; } 
        public  string numDocumento { get; set; }    
        public  string nomUser { get; set; } // tabla
        public  string usuarioPersona { get; set; } // tabla
        public  string correo { get; set; } // tabla
        public  string telefono { get; set; } // tabla
        public  string celular { get; set; } // tabla
        public Int32 codSucursal { get; set; }
        public string desSucursal {  get; set; }
        public Int32  codPerfil { get; set; }
        public string  desPerfil { get; set; }
        public Int32 codEstado { get; set; }  //tabla
        public string  desEstado { get; set; }
       
       
        
        public  CENMantUsuarioVIEW(){

        }
    
    }

    public class CENAutoUsuarioVIEW 
    {
        public int codUsuario { get; set; }
        public string nombres { get; set; }
        public string numDoc { get; set; }

    }




}
