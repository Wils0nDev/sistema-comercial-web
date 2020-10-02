using System;

namespace CEN
{
    public class CENMeta
    {
        public int codMeta { get; set; }
        public int codProveedor{ get; set; }
        public int codEstado { get; set; }
        public string descripcion { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string usuario { get; set; }
        public CENMeta()
        {

        }

        public CENMeta(int codProveedor, int codEstado, string fechaini, string fechaFin)
        {
            this.codProveedor = codProveedor;
            this.codEstado = codEstado;
            this.fechaInicio = fechaini;
            this.fechaFin = fechaFin;
        }
    }

    public class CENMetaLista
    {
        //DESCRIPCION: ENTIDAD PRODUCTO
        public int codMeta { get; set; }
        public string descripcion { get; set; }
        public int codProveedor { get; set; }
        public string descProveedor { get; set; }
        public int codEstado { get; set; }
        public string descEstado { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
    }
}
