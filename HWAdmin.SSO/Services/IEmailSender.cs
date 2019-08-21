using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HWAdmin.SSO.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
