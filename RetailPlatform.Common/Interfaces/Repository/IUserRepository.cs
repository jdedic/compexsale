using RetailPlatform.Common.Entities;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByEmail(string email);
        string GetUserFullNameByEmail(string email);
        bool CheckIfEmailAlreadyExist(long userId, string email);
        Task<User> GetUserById(long id);
    }
}
