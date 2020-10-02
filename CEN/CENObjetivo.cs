using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENObjetivo
    {
        public int codObjetivo { get; set; }
        public string descripcion { get; set; }
        public int codTipoIndicador { get; set; }
        public int codIndicador { get; set; }      
        public decimal valorIndicador { get; set; }
        public int codPerfil { get; set; }
        public int codTrabajador { get; set; }
        public string usuario { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public CENObjetivo()
        {

        }

        public CENObjetivo(int codTipoIndicador, int codIndicador, int codPerfil, int codTrabajador, string fechaInicio, string fechaFin)
        {
            this.codTipoIndicador = codTipoIndicador;
            this.codIndicador = codIndicador;
            this.codPerfil = codPerfil;
            this.codTrabajador = codTrabajador;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
        }
    }

    public class CENObjetivoLista
    {
        public int codObjetivo { get; set; }
        public string descripcion { get; set; }
        public int codTipoIndicador { get; set; }
        public string descTipoIndicador { get; set; }
        public int codIndicador { get; set; }
        public string descIndicador { get; set; }
        public decimal valorIndicador { get; set; }
        public int codPerfil { get; set; }
        public string descPerfil { get; set; }
        public int codTrabajador { get; set; }
        public string descTrabajador { get; set; }
        public string fechaRegistro { get; set; }
    }
}
