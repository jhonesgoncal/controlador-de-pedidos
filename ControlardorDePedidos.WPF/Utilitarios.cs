using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.WPF
{
    public static class Utilitarios
    {
        public static void EnviarEmail(string destinatario, string titulo, string mensagem)
        {
            var emailDeOrigem = "jhonesgrey@gmail.com";
            var servidorSMTP = "in-v3.mailjet.com";
            var portaSMTP = 587;
            var usuarioSMTP = "4218cb97c47cc7291ebe7df7e0a339ad";
            var senhaSMTP = "923e3631f0a1e1a1872f449c99f90872";

            var smtp = new SmtpClient();
            smtp.Host = servidorSMTP;
            smtp.Port = portaSMTP;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(usuarioSMTP, senhaSMTP);

            var msg = new MailMessage();
            msg.To.Add(destinatario);
            msg.Subject = titulo;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(emailDeOrigem);
            msg.ReplyToList.Add(emailDeOrigem);
            msg.Body = mensagem;

            smtp.Send(msg);
        }
    }
}
