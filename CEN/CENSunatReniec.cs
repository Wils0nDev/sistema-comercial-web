using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CEN_RequestSunat
    {
        public string numDocumento { get; set; } //Numero de RUC
        public CEN_RequestSunat()
        {
            numDocumento = CENConstante.g_const_vacio;
        }
    }
    public class CEN_ResponseServ_Sunat
    {
        public string ruc { get; set; }
        public string razon_social { get; set; }
        public string ciiu { get; set; }
        public string fecha_actividad { get; set; }
        public string contribuyente_condicion { get; set; }
        public string contribuyente_tipo { get; set; }
        public string contribuyente_estado { get; set; }
        public string nombre_comercial { get; set; }
        public string fecha_inscripcion { get; set; }
        public string domicilio_fiscal { get; set; }
        public string sistema_emision { get; set; }
        public string sistema_contabilidad { get; set; }
        public string actividad_exterior { get; set; }
        public string emision_electronica { get; set; }
        public string fecha_inscripcion_ple { get; set; }
        public string Oficio { get; set; }
        public string fecha_baja { get; set; }
    }

    

    public class CEN_RespuestaWSSunat
    {
        public CEN_ResponseServ_Sunat respuestaWsSunat { get; set; }
        public CENErrorWebSer ErrorWebSer { get; set; }

        public CEN_RespuestaWSSunat()
        {
            respuestaWsSunat = new CEN_ResponseServ_Sunat();
            ErrorWebSer = new CENErrorWebSer();
        }

    }

    //RENIEC
    public class CEN_RequestReniec
    {
        public string numDocumento { get; set; } //Numero de RUC
        public CEN_RequestReniec()
        {
            numDocumento = CENConstante.g_const_vacio;
        }
    }

    public class CEN_RespuestaWSConsulRec
    {
        public string dni { get; set; }
        public int cui { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string nombres { get; set; }
    }

    public class CEN_RespuestaWSReniec
    {
        public CEN_RespuestaWSConsulRec respuestaWsReniec { get; set; }
        public CENErrorWebSer ErrorWebSer { get; set; }

        public CEN_RespuestaWSReniec()
        {
            respuestaWsReniec = new CEN_RespuestaWSConsulRec();
            ErrorWebSer = new CENErrorWebSer();
        }

    }
}
