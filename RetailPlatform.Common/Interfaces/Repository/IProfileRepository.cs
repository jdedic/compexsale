using RetailPlatform.Common.Entities;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        bool CheckIfEmailAlreadyExist(string email);
    }
}
