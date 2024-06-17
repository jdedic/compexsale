using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json.Linq;
using RetailPlatform.Common.Interfaces.Service;
using RetailPlatform.Core.Config;
using SendGrid;
using SendGrid.Helpers.Mail;
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

        public async Task<bool> SendEmail()
        {

            var apiKey = _emailConfig.SendGridAPIKey;
            var sendGridClient = new SendGridClient(apiKey);
            var sendGridMessage = new SendGridMessage()
            {
                Subject = "test", 
                PlainTextContent = "Happy tuesday"
            };

            sendGridMessage.SetFrom(_emailConfig.SendFrom, _emailConfig.SendGridSender);
            sendGridMessage.AddTo("jovanna.deddic@gmail.com", string.Empty);

            try
            {
                var response = await sendGridClient.SendEmailAsync(sendGridMessage);

                if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(responseBody);
                    var errorMessage = jsonObject["errors"][0]["message"].ToString();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> SendEmailForRefusedAdd(string email, string reason)
        {
            var apiKey = _emailConfig.SendGridAPIKey;
            var sendGridClient = new SendGridClient(apiKey);

            var pathToFile = await GetPathToFile("refuse-add-template.html");
            var body = await GetBody(pathToFile);
            body = body.Replace("{Reason}", reason);
            var sendGridMessage = new SendGridMessage()
            {
                Subject = "Oglas - obrazloženje",
                HtmlContent = body
            };

            sendGridMessage.SetFrom(_emailConfig.SendFrom, _emailConfig.SendGridSender);
            sendGridMessage.AddTo(email, string.Empty);

            try
            {
                var response = await sendGridClient.SendEmailAsync(sendGridMessage);

                if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(responseBody);
                    var errorMessage = jsonObject["errors"][0]["message"].ToString();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task SendEmailForCreatedAdd(string topic, string name, string category, string createdBy, string link)
        {
            var apiKey = _emailConfig.SendGridAPIKey;
            var sendGridClient = new SendGridClient(apiKey);

            var pathToFile = await GetPathToFile("offer.html");
            var body = await GetBody(pathToFile);
            body = body.Replace("{Topic}", topic);
            body = body.Replace("{Name}", name);
            body = body.Replace("{Category}", category);
            body = body.Replace("{CreatedBy}", createdBy);
            body = body.Replace("{Link}", link);

            var sendGridMessage = new SendGridMessage()
            {
                Subject = topic,
                HtmlContent = body
            };

            sendGridMessage.SetFrom(_emailConfig.SendFrom, _emailConfig.SendGridSender);

            sendGridMessage.AddTo(_emailConfig.SendFrom, string.Empty);

              var response = await sendGridClient.SendEmailAsync(sendGridMessage);

                if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(responseBody);
                    var errorMessage = jsonObject["errors"][0]["message"].ToString();
                }
        }

        public async Task SendEmailForAdd(string email, string id, string addName, string customer)
        {
            var apiKey = _emailConfig.SendGridAPIKey;
            var sendGridClient = new SendGridClient(apiKey);

            var pathToFile = string.IsNullOrEmpty(customer) ? await GetPathToFile("adds-template.html") : await GetPathToFile("adds-template-for-customer.html");
            var body = await GetBody(pathToFile);
            body = body.Replace("{Name}", addName);
            body = body.Replace("{Id}", id);
            if (!string.IsNullOrEmpty(customer))
            {
                body = body.Replace("{FirstName}", customer);
            }

            var sendGridMessage = new SendGridMessage()
            {
                Subject = "Oglas - informacije",
                HtmlContent = body
            };

            sendGridMessage.SetFrom(_emailConfig.SendFrom, _emailConfig.SendGridSender);
            sendGridMessage.AddTo(email, string.Empty);

            
                var response = await sendGridClient.SendEmailAsync(sendGridMessage);

                if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(responseBody);
                    var errorMessage = jsonObject["errors"][0]["message"].ToString();
                }
            
           
        }

        #region helper-methods

        //public async Task<MimeMessage> GetMessage(string email, string subject, string body)
        //{
        //    var message = new MimeMessage();
        //    message.From.Add(MailboxAddress.Parse(_emailConfig.IMAPUsername));
        //    message.To.Add(MailboxAddress.Parse(email));
        //    message.Subject = subject;
        //    message.Body = new TextPart(TextFormat.Html) { Text = body };

        //    return message;
        //}

        public async Task<string> GetPathToFile(string templateName)
        {
            return _env.WebRootPath
                    + Path.DirectorySeparatorChar.ToString()
                    + "templates"
                    + Path.DirectorySeparatorChar.ToString()
                    + $"{templateName}";
        }

        //public async Task SendEmailMessage(MimeMessage message)
        //{
        //    using (var emailClient = new SmtpClient())
        //    {
        //        emailClient.Connect(_emailConfig.IMAPServer, _emailConfig.IMAPPort, false);
        //        emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
        //        emailClient.Authenticate(_emailConfig.IMAPUsername, _emailConfig.IMAPPassword);
        //        emailClient.Send(message);
        //        emailClient.Disconnect(true);
        //    }
        //}

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
            var apiKey = _emailConfig.SendGridAPIKey;
            var sendGridClient = new SendGridClient(apiKey);

            var pathToFile = await GetPathToFile("welcome.html");
            var body = await GetBody(pathToFile);
            var sendGridMessage = new SendGridMessage()
            {
                Subject = "Compexsale saradnja",
                HtmlContent = body
            };

            sendGridMessage.SetFrom(_emailConfig.SendFrom, _emailConfig.SendGridSender);

            foreach (var email in emails)
            {
                sendGridMessage.AddTo(email, string.Empty);

               
                    var response = await sendGridClient.SendEmailAsync(sendGridMessage);

                    if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                    {
                        var responseBody = await response.Body.ReadAsStringAsync();
                        var jsonObject = JObject.Parse(responseBody);
                        var errorMessage = jsonObject["errors"][0]["message"].ToString();
                    }
                
            }

        }

        public async Task<bool> SendContactClientEmail(string email, string clientName, string content)
        {
            var apiKey = _emailConfig.SendGridAPIKey;
            var sendGridClient = new SendGridClient(apiKey);

            var pathToFile = await GetPathToFile("contact-form.html");
            var body = await GetBody(pathToFile);
            body = body.Replace("{Name}", clientName);
            body = body.Replace("{Email}", email);
            body = body.Replace("{Content}", content);

            var sendGridMessage = new SendGridMessage()
            {
                Subject = "Pitanja klijenata",
                HtmlContent = body
            };

            sendGridMessage.SetFrom(_emailConfig.SendFrom, _emailConfig.SendGridSender);
            sendGridMessage.AddTo("compexsale@gmail.com", string.Empty);

            try
            {
                var response = await sendGridClient.SendEmailAsync(sendGridMessage);

                if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(responseBody);
                    var errorMessage = jsonObject["errors"][0]["message"].ToString();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
