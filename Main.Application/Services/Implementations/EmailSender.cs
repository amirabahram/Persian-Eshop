using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Main.Application.Services.Interfaces;

namespace Main.Application.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
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
                return  true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
        
        
