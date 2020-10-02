using CAD;
using CEN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNCorreo
    {
        public CLNCorreo() { }

        public List<CENCorreo> CredencialesCorreo()
        {
            //DESCRIPCION: lectura de parametros para envio de correo
            List<CENCorreo> listCredenciales;
            try
            {
                listCredenciales = new List<CENCorreo>();
                CENCorreo credenciales = new CENCorreo();
                credenciales.puerto = ConfigurationManager.AppSettings[CENConstante.g_const_puerto].ToString();
                credenciales.host = ConfigurationManager.AppSettings[CENConstante.g_const_host].ToString();
                credenciales.user = ConfigurationManager.AppSettings[CENConstante.g_const_user].ToString();
                credenciales.password = ConfigurationManager.AppSettings[CENConstante.g_const_pass].ToString();
                credenciales.asunto = ConfigurationManager.AppSettings[CENConstante.g_const_asunto].ToString();
                listCredenciales.Add(credenciales);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listCredenciales;
        }

        public string enviarCorreo(string usuario)
        {
            //DESCRIPCION: Envio de correo 

            string respuesta = string.Empty;
            int mensaje = 0;
            List<CENCorreo> listaDatos;
            List<CENCorreo> listaDatosServidor;
            var fromEmailAddress = string.Empty;
            var fromDisplayName = string.Empty;
            var userName = string.Empty;
            var password = string.Empty;
            var smtpHost = string.Empty;
            var smtpPort = string.Empty;
            var body = string.Empty;
            try
            {
                CADCorreo correo = new CADCorreo();
                listaDatos = correo.buscarCredencialesCorreo(usuario, CENConstante.g_const_2);

                //lectura de los datos de las credenciales del servidor de correo
                listaDatosServidor = CredencialesCorreo();

                foreach (var item in listaDatosServidor)
                {
                    userName = item.user;
                    password = item.password;
                    smtpHost = item.host;
                    smtpPort = item.puerto;
                    body = item.asunto;
                }

                foreach (var item2 in listaDatos)
                {
                    fromEmailAddress = item2.correoDestino;
                    fromDisplayName = item2.contraseña;
                    respuesta = item2.error;
                    mensaje = item2.respuesta;
                        
                }

                if (mensaje == CENConstante.g_const_505)
                {

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = smtpHost;
                    smtpClient.Port = Convert.ToInt32(smtpPort);
                    smtpClient.EnableSsl = false;
                    smtpClient.Credentials = new NetworkCredential(userName, password);

                    smtpClient.Timeout = 10000;


                    MailMessage mail = new MailMessage();
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    //mail.IsBodyHtml = true;
                    mail.Subject = body;
                    mail.Body = "contraseña: " + fromDisplayName.ToString();
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.Priority = MailPriority.High;
                    mail.From = new MailAddress(userName);
                    mail.To.Add(new MailAddress(fromEmailAddress));
                    smtpClient.Send(mail);
                }
                               
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
