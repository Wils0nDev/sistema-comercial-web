using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENComprobSunat
    {
        public int ntraComprob { get; set; }
        public int codTransaccion { get; set; }
        public int codModulo { get; set; }
        public int tipDocSunat { get; set; }
        public int tipDocVenta { get; set; }
        public string tramEntrada { get; set; }
        public string tramSalida { get; set; }
        public int estado { get; set; }
        public string usuario { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
        public CENComprobSunat()
        {
            ntraComprob = CENConstante.g_const_0;
            codTransaccion = CENConstante.g_const_0;
            codModulo = CENConstante.g_const_0;
            tipDocSunat = CENConstante.g_const_0;
            tipDocVenta = CENConstante.g_const_0;
            estado = CENConstante.g_const_0;
            tramEntrada = CENConstante.g_const_vacio;
            tramSalida = CENConstante.g_const_vacio;
            usuario = CENConstante.g_const_vacio;
            ip = CENConstante.g_const_vacio;
            mac = CENConstante.g_const_vacio;
        }
    }
}
