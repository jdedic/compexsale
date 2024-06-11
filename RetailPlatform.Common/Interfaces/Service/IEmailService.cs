
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IEmailService
    {
        Task<bool> SendEmail();
        Task<bool> SendEmailForRefusedAdd(string email, string reason);
        //Task SendEmailForRefusedAdd(string email, string reason);
        Task SendWelcomEmail(List<string> emails);
        Task<bool> SendContactClientEmail(string email, string clientName, string content);
        Task SendEmailForAdd(string email, string id, string addName, string customer);
        Task SendEmailForCreatedAdd(string topic, string name, string category, string createdBy, string link);
    }
}
