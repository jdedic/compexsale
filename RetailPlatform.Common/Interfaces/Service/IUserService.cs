using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IUserService
    {
        bool CheckUserCredentials(string email, string password);
        Task<IEnumerable<User>> FetchUsers();
        Task CreateUser(User user, string role);
        Task UpdateUser(User user, string role, bool passwordUpdated);
    }
}
