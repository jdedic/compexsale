using RetailPlatform.Common.Entities;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IProfileRepository : IBaseRepository<ProfileModel>
    {
        bool CheckIfEmailAlreadyExist(string email);
        Task CreateProfile(ProfileModel model);
    }
}
