using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;

using Utility.Tools.Notification;

namespace Utility.Tools.SMS.Rahyab
{
    public class EmailService : INotification , IEmailNotification
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> SendAsync(string Text, string Destination)
        {
            var email = configuration.BindSection<EmailParameters>();
            var client = new SmtpClient(email.Host, email.Port)
            {
                //UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email.Username, email.Password),
                TargetName = email.TargetName,
                EnableSsl = true
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(email.MailSender)
            };
            mailMessage.To.Add(Destination);
            mailMessage.Subject = email.Subject;
            mailMessage.Body = Text;

            
            await client.SendMailAsync(mailMessage);

            return null;
        }        
    }
}
