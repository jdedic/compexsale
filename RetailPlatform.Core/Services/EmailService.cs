using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using RetailPlatform.Common.Interfaces.Service;
using RetailPlatform.Core.Config;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<MimeMessage> GetMessage(string email, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_emailConfig.IMAPUsername));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = body };
            
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

        public async Task SendEmailMessage(MimeMessage message)
        {
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(_emailConfig.IMAPServer, _emailConfig.IMAPPort, false);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_emailConfig.IMAPUsername, _emailConfig.IMAPPassword);
                emailClient.Send(message);
                emailClient.Disconnect(true);
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

        public async Task SendWelcomEmail(List<string> emails)
        {

            var pathToFile = await GetPathToFile("welcome.html");
            var body = await GetBody(pathToFile);

            foreach (var email in emails)
            {
                var message = await GetMessage(email, "Compexsale saradnja", body);
                await SendEmailMessage(message);
            }

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
