using RetailPlatform.Common.Entities;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByEmail(string email);
        string GetUserFullNameByEmail(string email);
    }
}
