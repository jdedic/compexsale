
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IEmailService
    {
        Task SendEmailForRefusedAdd(string email, string reason);
        Task SendWelcomEmail(List<string> emails);
        Task SendContactClientEmail(string email, string clientName, string content);
        Task SendEmailForAdd(string email, string id, string addName, string customer);
    }
}
