using RetailPlatform.Common.Entities;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IProfileService
    {
        Task CreateProfile(ProfileModel model);
        bool CheckUserCredentials(string email, string password);
        Task UpdateProfile(ProfileModel vendor, bool passwordUpdated);
    }
}
