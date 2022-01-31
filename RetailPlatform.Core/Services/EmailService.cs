using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using RetailPlatform.Core.Config;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RetailPlatform.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig _emailConfig;
        private IHostingEnvironment _env;

        public EmailService(
            IOptions<EmailConfig> emailConfig,
            IHostingEnvironment env)
        {
            _emailConfig = emailConfig.Value ?? throw new ArgumentException(nameof(emailConfig));
            _env = env;
        }

       
        public async Task SendEmailForRefusedAdd(string email)
        {
            var pathToFile = await GetPathToFile("refuse-add-template.html");
            var body = await GetBody(pathToFile);
            body = body.Replace("{Username}", email);
            var message = await GetMessage(email, "Successfully created account", body);
            await SendEmailMessage(message);
        }

       

        #region helper-methods

        public async Task<MailMessage> GetMessage(string email, string subject, string body)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));
            message.From = new MailAddress(_emailConfig.IMAPUsername);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            return message;
        }

        public async Task<string> GetPathToFile(string templateName)
        {
            return _env.WebRootPath
                    + Path.DirectorySeparatorChar.ToString()
                    + "Templates"
                    + Path.DirectorySeparatorChar.ToString()
                    + "EmailTemplate"
                    + Path.DirectorySeparatorChar.ToString()
                    + $"{templateName}";
        }

        public async Task SendEmailMessage(MailMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _emailConfig.IMAPUsername,
                    Password = _emailConfig.IMAPPassword
                };
                smtp.Credentials = credential;
                smtp.Host = _emailConfig.IMAPServer;
                smtp.Port = _emailConfig.IMAPPort;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }

        public async Task<string> GetBody(string pathToFile)
        {
            string body = string.Empty;
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                body = SourceReader.ReadToEnd();
            }
            return body;
        }
        #endregion
    }
}
