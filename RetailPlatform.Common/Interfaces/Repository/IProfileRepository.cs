using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IProfileRepository : IBaseRepository<ProfileModel>
    {
        bool CheckIfEmailAlreadyExist(string email);
        Task<List<ProfileModel>> GetPrivateAccountProfiles();
        ProfileModel GetProfileByEmail(string email);
        Task<ProfileModel> GetVendorById(long id);
    }
}
