using Microsoft.Extensions.Configuration;
using OngProject.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class EmailSender
    {
        IConfiguration _config;
        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public static string GetWelcomeEmail()
        {
            return GetEmailForTemplate("Bienvenido a Somos Mas",
                "Su usuario ha sido creado con éxito", "somosmas@email.com");
        }
        public static string GetEmailForTemplate(string title, string message, string contact = "somosmas@email.com")
        {
            try
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, "Templates/htmlpage.html");
                var file = File.OpenText(filePath);
                var content = File.ReadAllText(filePath);
                content = content.Replace("T&iacute;tulo", title);
                content = content.Replace("Texto del email", message);
                content = content.Replace("Datos de contacto de ONG", contact);
                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Se deja comentado hasta tener el controller!
    //    public async Task SendEmailAsync(string email, string subject)
    //    {
    //        try
    //        {
    //            var client = new SendGridClient(_config["SendGridToken"]);
    //            var from = new EmailAddress(FromEmail, FromName);
    //            var to = new EmailAddress(email, email);
    //            var msg = MailHelper.CreateSingleEmail(from, to, subject, String.Empty, GetWelcomeEmail());
    //            var response = await client.SendEmailAsync(msg);
    //        }
    //        catch (Exception )
    //        {
    //            throw ;
    //        }

    //    }
    }
}
