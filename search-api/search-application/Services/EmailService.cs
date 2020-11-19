using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace search_application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Send(string to, string subject, string content)
        {
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.Subject = subject;
            message.From = new MailAddress(configuration["EmailFrom"]);
            message.Body = content;

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Timeout = 30000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(configuration["EmailFrom"], configuration["EmailPassword"]);
            smtp.Host = "smtp.gmail.com";

            smtp.Send(message);
        }
    }
}
