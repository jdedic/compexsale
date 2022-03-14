using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
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

       
        public async Task SendEmailForRefusedAdd(string email, string reason)
        {
            var pathToFile = await GetPathToFile("refuse-add-template.html");
            var body = await GetBody(pathToFile);
            body = body.Replace("{Reason}", reason);
            var message = await GetMessage(email, "Oglas - obrazloženje", body);
            await SendEmailMessage(message);
        }

        public async Task SendEmailForAdd(string email, string id, string addName, string customer)
        {
            var pathToFile = string.IsNullOrEmpty(customer) ? await GetPathToFile("adds-template.html") : await GetPathToFile("adds-template-for-customer.html");
            var body = await GetBody(pathToFile);
            body = body.Replace("{Name}", addName);
            body = body.Replace("{Id}", id);
            if (!string.IsNullOrEmpty(customer))
            {
                body = body.Replace("{FirstName}", customer);
            }
            var message = await GetMessage(email, "Oglas - informacije", body);
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
                    + "templates"
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
                smtp.EnableSsl = false;
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

        public async Task SendWelcomEmail(string email)
        {
            var pathToFile = await GetPathToFile("welcome.html");
            var body = await GetBody(pathToFile);
            var message = await GetMessage(email, "Compexsale saradnja", body);
            await SendEmailMessage(message);
        }

        public async Task SendContactClientEmail(string email, string clientName, string content)
        {
            var pathToFile = await GetPathToFile("contact-form.html");
            var body = await GetBody(pathToFile);
            body = body.Replace("{Name}", clientName);
            body = body.Replace("{Email}", email);
            body = body.Replace("{Content}", content);
            var message = await GetMessage("info@compexsale.com", "Pitanja klijenata", body);
            await SendEmailMessage(message);
        }
        #endregion
    }
}
