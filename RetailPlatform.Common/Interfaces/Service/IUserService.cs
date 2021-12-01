using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IUserService
    {
        bool CheckUserCredentials(string email, string password);
        Task<IEnumerable<User>> FetchUsers();
    }
}
