using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
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

        public async Task SendEmail(string toEmail)
        {
            var apiKey = _config["SendGridToken"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("SampleMail", "SampleTitle");
            var subject = "SampleSubject";
            var to = new EmailAddress("SampleMail");
            var plainTextContent = "sampleText";
            var htmlContent = File.ReadAllText("./Templates/htmlpage.html");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            await client.SendEmailAsync(msg);
        }
    }
}
