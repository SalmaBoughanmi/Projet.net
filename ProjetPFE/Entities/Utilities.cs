using System.Net.Mail;
using System.Net;

namespace ProjetPFE.Entities
{
   public static class Utilities
    {
        public static void SendMail(String destination, String Subject, string Content)
        {
            var body = Content;
            var message = new MailMessage();
            message.To.Add(new MailAddress(destination));
            message.From = new MailAddress("recrutementtiscircuits@gmail.com");
            message.Subject = Subject;
            message.Body = body;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "recrutementtiscircuits@gmail.com",
                    Password = "zfyxualrivjagglt"
                };
                // mot de passe email ; "tiscircuits"
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                try
                {
                    smtp.Send(message);
                }
                catch (Exception)
                {

                }
            }
        }

    }
}
