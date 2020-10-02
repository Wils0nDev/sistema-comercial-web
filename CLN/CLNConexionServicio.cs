using CEN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNConexionServicio
    {
        public CEN_RespuestaWSSunat ConsultaClienteSunat(CEN_RequestSunat data)
        {
            //DESCRIPCIÓN: Conexión y busqueda de cliente en SUNAT
            try
            {
                CEN_RespuestaWSSunat resp = new CEN_RespuestaWSSunat();
                // Definir el URL de la aplicación Web API
                string URLWebAPI = ConfigurationManager.ConnectionStrings["urlServiceSunRec"].ConnectionString.ToString();

                // Crear un objeto HttpClient para acceder a la Web API
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URLWebAPI);

                // Especificar que estamos aceptando datos JSON
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.
                    MediaTypeWithQualityHeaderValue(CENConstante.g_const_apliJSON));

                // Serializar los datos a formato JSON
                string DataJSON = JsonConvert.SerializeObject(data);

                // Obtener un tipo HttpContent para pasarlo en la petición 
                StringContent Content = new StringContent(DataJSON,
                    System.Text.Encoding.UTF8, CENConstante.g_const_apliJSON);

                // Realizar la llamada al recurso Web API y obtener la respuesta
                HttpResponseMessage response = client.PostAsync(
                ConfigurationManager.ConnectionStrings["ServiceSunat"].ConnectionString.ToString(), Content).Result;

                // Verificar si la respuesta fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Deserializar el resultado obtenido
                    resp = JsonConvert.DeserializeObject<CEN_RespuestaWSSunat>(
                            response.Content.ReadAsStringAsync().Result);
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEN_RespuestaWSReniec ConsultaClienteReniec(CEN_RequestReniec data)
        {
            //DESCRIPCIÓN: Conexión y busqueda de cliente en SUNAT
            try
            {
                CEN_RespuestaWSReniec resp = new CEN_RespuestaWSReniec();
                // Definir el URL de la aplicación Web API
                string URLWebAPI = ConfigurationManager.ConnectionStrings["urlServiceSunRec"].ConnectionString.ToString();

                // Crear un objeto HttpClient para acceder a la Web API
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URLWebAPI);

                // Especificar que estamos aceptando datos JSON
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.
                    MediaTypeWithQualityHeaderValue(CENConstante.g_const_apliJSON));

                // Serializar los datos a formato JSON
                string DataJSON = JsonConvert.SerializeObject(data);

                // Obtener un tipo HttpContent para pasarlo en la petición 
                StringContent Content = new StringContent(DataJSON,
                    System.Text.Encoding.UTF8, CENConstante.g_const_apliJSON);

                // Realizar la llamada al recurso Web API y obtener la respuesta
                HttpResponseMessage response = client.PostAsync(
                ConfigurationManager.ConnectionStrings["ServiceReniec"].ConnectionString.ToString(), Content).Result;

                // Verificar si la respuesta fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Deserializar el resultado obtenido
                    resp = JsonConvert.DeserializeObject<CEN_RespuestaWSReniec>(
                            response.Content.ReadAsStringAsync().Result);
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseApi RegistrarBoleta(RequestApiBoleta data)
        {
            //DESCRIPCIÓN: Conexión y registro de registro de boleta
            CENErrorWebSer ErrorWebSer = new CENErrorWebSer();
            ResponseApi resp = new ResponseApi();
            ResponseApiBoletaError resp_error = new ResponseApiBoletaError();
            List<CENEmpresa> listresp = new List<CENEmpresa>();
            try
            {
                // Definir el URL de la aplicación Web API
                string URLWebAPI = ConfigurationManager.ConnectionStrings["urlServiceFactura"].ConnectionString.ToString();

                // Crear un objeto HttpClient para acceder a la Web API
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URLWebAPI);


                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + ConfigurationManager.ConnectionStrings["TokenFacturacion"].ConnectionString.ToString());

                // Especificar que estamos aceptando datos JSON
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.
                    MediaTypeWithQualityHeaderValue(CENConstante.g_const_apliJSON));

                // Serializar los datos a formato JSON

                string DataJSON = JsonConvert.SerializeObject(data);

                // Obtener un tipo HttpContent para pasarlo en la petición 
                StringContent Content = new StringContent(DataJSON,
                    System.Text.Encoding.UTF8, CENConstante.g_const_apliJSON);

                // Realizar la llamada al recurso Web API y obtener la respuesta
                //HttpResponseMessage response = new HttpResponseMessage();
                HttpResponseMessage response = client.PostAsync(
                ConfigurationManager.ConnectionStrings["FactBolFact"].ConnectionString.ToString(), Content).Result;
                //"/api/v1/invoice/send", Content).Result;

                // Verificar si la respuesta fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Deserializar el resultado obtenido

                    //RootObject rootObj = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
                    resp = JsonConvert.DeserializeObject<ResponseApi>(
                           response.Content.ReadAsStringAsync().Result);


                }
                else
                {
                    resp_error = JsonConvert.DeserializeObject<ResponseApiBoletaError>(
                            response.Content.ReadAsStringAsync().Result);
                    /*
                    gbcon = consentimiento.Obtener_desc_gbcon(CEN_Constante.g_const_prefijo, CEN_Constante.g_const_1020);
                    resp.RptaRegRespConsen.FlagVerificacion = false;
                    resp.RptaRegRespConsen.cod_resp = CEN_Constante.g_const_0;
                    resp.RptaRegRespConsen.DescripcionResp = CEN_Constante.g_const_err_int;
                    resp.ErrorWebSer = consulta.LlenarErrorWebSer(CEN_Constante.g_const_0, gbcon.gbconcorr, gbcon.gbcondesc);
                    */
                }

            }
            catch (Exception ex)
            {
                /*
                gbcon = consentimiento.Obtener_desc_gbcon(CEN_Constante.g_const_prefijo, CEN_Constante.g_const_1020);
                resp.RptaRegRespConsen.FlagVerificacion = false;
                resp.RptaRegRespConsen.cod_resp = CEN_Constante.g_const_0;
                resp.RptaRegRespConsen.DescripcionResp = CEN_Constante.g_const_err_int;
                resp.ErrorWebSer = consulta.LlenarErrorWebSer(CEN_Constante.g_const_0, gbcon.gbconcorr, ex.Message);
                return resp;
                */
            }
            return resp;
        }

    }
}
