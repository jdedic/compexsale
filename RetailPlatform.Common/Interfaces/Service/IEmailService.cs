
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IEmailService
    {
        Task SendEmailForRefusedAdd(string email, string reason);
    }
}
