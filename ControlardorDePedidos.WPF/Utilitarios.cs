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
            var emailDeOrigem = "jhones.goncalves@outlook.com";
            var servidorSMTP = "in-v3.mailjet.com";
            var portaSMTP = 587;
            var usuarioSMTP = "92d927b13ec8257815dda711583f1a8a";
            var senhaSMTP = "e2bb37d436ed3555a5fe2166959b91cb";

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
