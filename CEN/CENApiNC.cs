using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CENApiNC
    {
        public string tipoDoc { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public string fechaEmision { get; set; }
        public CENClient client { get; set; }
        public CENCompany company { get; set; }
        public string tipoMoneda { get; set; }
        public double sumOtrosCargos { get; set; }
        public double mtoOperGravadas { get; set; }
        public double mtoOperInafectas { get; set; }
        public double mtoOperExoneradas { get; set; }
        public double mtoOperExportacion { get; set; }
        public double mtoIGV { get; set; }
        public double mtoISC { get; set; }
        public double mtoOtrosTributos { get; set; }
        public double icbper { get; set; }
        public double mtoImpVenta { get; set; }
        public List<CENDetails> details { get; set; }
        public List<CENLegends> legends { get; set; }
        public List<CENGuias> guias { get; set; }
        public List<CENRelDocs> relDocs { get; set; }
        public string compra { get; set; }
        public double mtoBaseIsc { get; set; }
        public double mtoBaseOth { get; set; }
        public double totalImpuestos { get; set; }
        public string ublVersion { get; set; }
        public string codMotivo { get; set; }
        public string desMotivo { get; set; }
        public string tipDocAfectado { get; set; }
        public string numDocfectado { get; set; }
        public double mtoOperGratuitas { get; set; }
        public CENPerception perception { get; set; }
        public CENApiNC()
        {
            tipoDoc = "";
            serie = "";
            correlativo = "";
            fechaEmision = "";
            client = new CENClient();
            company = new CENCompany();
            tipoMoneda = "";
            sumOtrosCargos = 0;
            mtoOperGravadas = 0;
            mtoOperInafectas = 0;
            mtoOperExoneradas = 0;
            mtoOperExportacion = 0;
            mtoIGV = 0;
            mtoISC = 0;
            mtoOtrosTributos = 0;
            icbper = 0;
            mtoImpVenta = 0;
            details = new List<CENDetails>();
            legends = new List<CENLegends>();
            guias = new List<CENGuias>();
            relDocs = new List<CENRelDocs>();
            compra = "";
            mtoBaseIsc = 0;
            mtoBaseOth = 0;
            totalImpuestos = 0;
            ublVersion = "";
            codMotivo = "";
            desMotivo = "";
            tipDocAfectado = "";
            numDocfectado = "";
            mtoOperGratuitas = 0;
            perception = new CENPerception();
        }
    }

    public class CENPerception
    {
        public string codReg { get; set; }
        public double porcentaje { get; set; }
        public double mtoBase { get; set; }
        public double mto { get; set; }
        public double mtoTotal { get; set; }
        public CENPerception()
        {
            codReg = "";
            porcentaje = 0;
            mtoBase = 0;
            mto = 0;
            mtoTotal = 0;
        }
    }

    public class CENRelDocs
    {
        public string tipoDoc { get; set; }
        public string nroDoc { get; set; }
        public CENRelDocs()
        {
            tipoDoc = "";
            nroDoc = "";
        }
    }

    public class CENGuias
    {
        public string tipoDoc { get; set; }
        public string nroDoc { get; set; }
        public CENGuias()
        {
            tipoDoc = "";
            nroDoc = "";
        }
    }

    public class CENLegends
    {
        public string code { get; set; }
        public string value { get; set; }
        public CENLegends()
        {
            code = "";
            value = "";
        }
    }

    public class CENDetails
    {
        public string unidad { get; set; }
        public double cantidad { get; set; }
        public string codProducto { get; set; }
        public string codProdSunat { get; set; }
        public string codProdGS1 { get; set; }
        public string descripcion { get; set; }
        public double mtoValorUnitario { get; set; }
        public double descuento { get; set; }
        public double igv { get; set; }
        public string tipAfeIgv { get; set; }
        public double isc { get; set; }
        public string tipSisIsc { get; set; }
        public double totalImpuestos { get; set; }
        public double mtoPrecioUnitario { get; set; }
        public double mtoValorVenta { get; set; }
        public double mtoValorGratuito { get; set; }
        public double mtoBaseIgv { get; set; }
        public double porcentajeIgv { get; set; }
        public double mtoBaseIsc { get; set; }
        public double porcentajeIsc { get; set; }
        public double mtoBaseOth { get; set; }
        public double porcentajeOth { get; set; }
        public double otroTributo { get; set; }
        public double icbper { get; set; }
        public double factorIcbper { get; set; }
        public List<CENCargos> cargos { get; set; }
        public List<CENDescuentos> descuentos { get; set; }
        public List<CENAtributos> atributos { get; set; }
        public CENDetails()
        {
            unidad = "";
            cantidad = 0;
            codProducto = "";
            codProdSunat = "";
            codProdGS1 = "";
            descripcion = "";
            mtoValorUnitario = 0;
            descuento = 0;
            igv = 0;
            tipAfeIgv = "";
            isc = 0;
            tipSisIsc = "";
            totalImpuestos = 0;
            mtoPrecioUnitario = 0;
            mtoValorVenta = 0;
            mtoValorGratuito = 0;
            mtoBaseIgv = 0;
            porcentajeIgv = 0;
            mtoBaseIsc = 0;
            porcentajeIsc = 0;
            mtoBaseOth = 0;
            porcentajeOth = 0;
            otroTributo = 0;
            icbper = 0;
            factorIcbper = 0;
            cargos = new List<CENCargos>();
            descuentos = new List<CENDescuentos>();
            atributos = new List<CENAtributos>();
        }
    }

    public class CENCargos
    {
        public string codTipo { get; set; }
        public string factor { get; set; }
        public double monto { get; set; }
        public double montoBase { get; set; }
        public CENCargos()
        {
            codTipo = "";
            factor = "";
            monto = 0;
            montoBase = 0;
        }
    }

    public class CENDescuentos
    {
        public string codTipo { get; set; }
        public string factor { get; set; }
        public double monto { get; set; }
        public double montoBase { get; set; }
        public CENDescuentos()
        {
            codTipo = "";
            factor = "";
            monto = 0;
            montoBase = 0;
        }
    }

    public class CENAtributos
    {
        public string code { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string fecInicio { get; set; }
        public string fecFin { get; set; }
        public int duracion { get; set; }
        public CENAtributos()
        {
            code = "";
            name = "";
            value = "";
            fecInicio = "";
            fecFin = "";
            duracion = 0;
        }
    }

    public class CENCompany
    {
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public CENAddress address { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public CENCompany()
        {
            ruc = "";
            razonSocial = "";
            nombreComercial = "";
            address = new CENAddress();
            email = "";
            telephone = "";
        }
    }

    public class CENClient
    {
        public string tipoDoc { get; set; }
        public string numDoc { get; set; }
        public string rznSocial { get; set; }
        public CENAddress address { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public CENClient()
        {
            tipoDoc = "";
            numDoc = "";
            rznSocial = "";
            address = new CENAddress();
            email = "";
            telephone = "";
        }
    }
    public class CENAddress
    {
        public string ubigueo { get; set; }
        public string codigoPais { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string urbanizacion { get; set; }
        public string direccion { get; set; }
        public string codLocal { get; set; }
        public CENAddress()
        {
            ubigueo = "";
            codigoPais = "";
            departamento = "";
            provincia = "";
            distrito = "";
            urbanizacion = "";
            direccion = "";
            codLocal = "";

        }
    }

    //RESPONSE API
    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
    }
    public class CdrResponse
    {
        public int accepted { get; set; }
        public string id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public List<string> notes { get; set; }
    }

    public class SunatResponse
    {
        public bool success { get; set; }
        public Error error { get; set; }
        public string cdrZip { get; set; }
        public CdrResponse cdrResponse { get; set; }
    }

    public class ResponseApi
    {
        public string xml { get; set; }
        public string hash { get; set; }
        public SunatResponse sunatResponse { get; set; }
    }
}
