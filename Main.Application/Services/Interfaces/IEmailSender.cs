using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface IEmailSender
    {
        public Task<bool> EmailSending(string email, string subject, string body);
    }
}
