using DIY.Castle.Web.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            IEnumerable<EmailAttachment> attachments = null);
    }
}
