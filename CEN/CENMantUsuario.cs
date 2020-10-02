using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENMantUsuario : CENPersona
    {
        //Para mi select de usuarios
        
        //public List<CENUsuario> luser = new List<CENUsuario>();
        public int ntraUsuario { get; set; } 

        public  string nomUsuario { get; set; } // tabla
    
        public  short estado { get; set; }  //tabla
        public  Byte password { get; set; }
        public string  desPerfil { get; set; }
        public string desSucursal {  get; set; }

        public Int32 codPerfil { get; set; }
        public Int32 codSucursal { get; set; }
       
        public  CENMantUsuario ():base()
        {

        }

        public CENMantUsuario (string numeroDocumento, string nombres,string apellidoPaterno,
                             string apellidoMaterno,string correo,string telefono,string celular, 
                             string nomUsuario, short estado, string  desPerfil , string desSucursal
                              ):base ( numeroDocumento , nombres , apellidoPaterno , apellidoMaterno, correo, telefono , celular)
                              
        {                    

            this.nomUsuario = nomUsuario;
            this.estado = estado;
           
        }
    



    }

















}


