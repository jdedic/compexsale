using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IProfileRepository : IBaseRepository<ProfileModel>
    {
        bool CheckIfEmailAlreadyExist(string email);
        string GetProfileInfoById(long id);
        Task<List<ProfileModel>> GetPrivateAccountProfiles();
        ProfileModel GetProfileByEmail(string email);
        Task<ProfileModel> GetProfileById(long id);
        Task<List<ProfileModel>> GetBusinessAccountProfiles();
        Task<List<ProfileModel>> GetPrivateProfiles();
        Task<List<ProfileModel>> GetBusinessProfiles();

        Task<IEnumerable<ProfileModel>> GetVendors(bool isLegalEntity);
    }
}
