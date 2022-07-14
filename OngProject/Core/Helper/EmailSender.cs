using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        private static string GetWelcomeEmail()
        {
            return GetEmailForTemplate("Bienvenido a Somos Mas",
                "Su usuario ha sido creado con éxito", "somosmas@email.com");
        }

        private static string GetContactEmail()
        {
            return GetEmailForTemplate("Contacto Somos Mas",
                "Recibimos su contacto", "somosmas@email.com");
        }

        private static string GetEmailForTemplate(string title, string message, string contact = "somosmas@email.com")
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

        public async Task SendWelcomeEmailAsync(string email, string subject)
        {
            try
            {
                var client = new SendGridClient(_config["SendGridToken"]);
                var from = new EmailAddress("admapi07@gmail.com", "admapi07@gmail.com");
                var to = new EmailAddress(email, email);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, String.Empty, GetWelcomeEmail());
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SendContactEmailAsync(string email, string subject)
        {
            try
            {
                var client = new SendGridClient(_config["SendGridToken"]);
                var from = new EmailAddress("admapi07@gmail.com", "admapi07@gmail.com");
                var to = new EmailAddress(email, email);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, String.Empty, GetContactEmail());
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
