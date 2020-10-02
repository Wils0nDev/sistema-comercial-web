using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class Token
    {
        public string code { get; set; }
    }

    public class Plan
    {
        public string nombre { get; set; }
        public int limite { get; set; }
    }

    public class Environment
    {
        public string nombre { get; set; }
        public string fe_url { get; set; }
        public string re_url { get; set; }
        public string guia_url { get; set; }
    }

    public class CENEmpresa
    {
        public int id { get; set; }
        public string sol_user { get; set; }
        public string sol_pass { get; set; }
        public string ruc { get; set; }
        public string razon_social { get; set; }
        public string direccion { get; set; }
        public string certificado { get; set; }
        public string logo { get; set; }
        public Token token { get; set; }
        public Plan plan { get; set; }
        public Environment environment { get; set; }

        public CENEmpresa()
        {
            token = new Token();
            plan = new Plan();
            environment = new Environment();
        }
    }

    public class CENListEmpresa
    {
        public List<CENEmpresa> empresa { get; set; }
        public CENListEmpresa()
        {
            empresa = new List<CENEmpresa>();
        }
    }

    public class SalidaResponseRpta
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    //BOLETA ELECTRONICA
    /*
    public class Address
    {
        public string direccion { get; set; }
    }
    
    public class Client
    {
        public string tipoDoc { get; set; }
        public int numDoc { get; set; }
        public string rznSocial { get; set; }
        public Address address { get; set; }
    }

    public class Address2
    {
        public string direccion { get; set; }
    }
    
    public class Company
    {
        public long ruc { get; set; }
        public string razonSocial { get; set; }
        public Address2 address { get; set; }
    }

    public class Detail
    {
        public string codProducto { get; set; }
        public string unidad { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public int mtoValorUnitario { get; set; }
        public int mtoValorVenta { get; set; }
        public int mtoBaseIgv { get; set; }
        public int porcentajeIgv { get; set; }
        public int igv { get; set; }
        public int tipAfeIgv { get; set; }
        public int totalImpuestos { get; set; }
        public int mtoPrecioUnitario { get; set; }
    }
    
    public class Legend
    {
        public string code { get; set; }
        public string value { get; set; }
    }
    */
    public class RequestApiBoleta
    {
        public string tipoOperacion { get; set; }
        public string tipoDoc { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public string fechaEmision { get; set; }
        public string tipoMoneda { get; set; }
        public CENClient client { get; set; }
        public CENCompany company { get; set; }
        public double mtoOperGravadas { get; set; }
        public double mtoOperExoneradas { get; set; }
        public double mtoIGV { get; set; }
        public double totalImpuestos { get; set; }
        public double valorVenta { get; set; }
        public double mtoImpVenta { get; set; }
        public string ublVersion { get; set; }
        public List<CENDetails> details { get; set; }
        public List<CENLegends> legends { get; set; }
    }

    //Respuesta de boleta
    /*
    public class CdrResponse
    {
        public string id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public List<object> notes { get; set; }
    }

    public class SunatResponse
    {
        public bool success { get; set; }
        public string cdrZip { get; set; }
        public CdrResponse cdrResponse { get; set; }
    }
    
    public class ResponseApiBoleta
    {
        public string xml { get; set; }
        public string hash { get; set; }
        public SunatResponse sunatResponse { get; set; }
    }*/

    //Error consulta boleta
    /*
    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
    }*/

    public class SunatResponseError
    {
        public bool success { get; set; }
        public Error error { get; set; }
    }

    public class ResponseApiBoletaError
    {
        public string xml { get; set; }
        public string hash { get; set; }
        public SunatResponseError sunatResponse { get; set; }
    } 
}
