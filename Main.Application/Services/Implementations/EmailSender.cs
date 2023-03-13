using Main.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Main.Application.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> EmailSending(string email, string subject, string body)
        {
            string fromEmail = "amiralaei70@gmail.com";
            string password = "qmlbuzippyhbfhyi"; 
            try
            {
                var mail = new MailMessage();

                var smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(fromEmail, "Account Varification");

                mail.To.Add(email);

                mail.Subject = subject;

                mail.Body = body;

                mail.IsBodyHtml = true;

                smtpServer.Port = 587;

                smtpServer.Credentials = new NetworkCredential(fromEmail, password);

                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}


