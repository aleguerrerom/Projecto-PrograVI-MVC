using System;
using System.Data;
using System.Configuration;
using Projecto_PrograVI_MVC.Models;
using System.Net;
using System.Net.Mail;

namespace WindowsService
{
    class BLiniciador
    {

        public void ObtenerCorreos()
        {
            DataTable vloDTCorreos = new DataTable();
            DSCorreo vloCorreo = new DSCorreo();
            vloDTCorreos = vloCorreo.ObtenerCorreos().Tables[0];

            if (vloDTCorreos.Rows.Count > 0)
            {
                foreach (DataRow vloFila in vloDTCorreos.Rows)
                {
                  //  AccountModel vloRegistros = new AccountModel(
                  //  Convert.ToString(vloFila[1])
                    //Convert.ToString(vloFila[2])

                    //);

                  
                    
                       // EnviarMensaje(vloRegistros.VLS_Correo, vloRegistros.Mensaje);
                    
                }
            }
        }
        public void EnviarMensaje(string vlcCorreoPara, string vlcCuerpoMensaje)
        {
            string vlcCorreoAdmin = ConfigurationManager.AppSettings["AdminUser"];
            string vlcCorreoAdminPass = ConfigurationManager.AppSettings["AdminPassword"];
            string vlcHost = ConfigurationManager.AppSettings["SMTPName"];
            int vlcPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);


            var fromAddress = new MailAddress(vlcCorreoAdmin, "De:");
            var toAddress = new MailAddress(vlcCorreoPara, "Para:");
            string fromPassword = vlcCorreoAdminPass;
            string subject = "Esto es una prueba de SW UTC";
            string body = vlcCuerpoMensaje;

            var smtp = new SmtpClient
            {
                Host = vlcHost,
                Port = vlcPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
