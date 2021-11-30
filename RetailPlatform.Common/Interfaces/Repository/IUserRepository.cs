using RetailPlatform.Common.Entities;
using System.Collections.Generic;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByEmail(string email);
        string GetUserFullNameByEmail(string email);
        bool CheckIfEmailAlreadyExist(long userId, string email);
    }
}
