using RetailPlatform.Common.Entities;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IProfileService
    {
        Task CreateProfile(ProfileModel model, bool isVendor, bool isCustomer);
        bool CheckUserCredentials(string email, string password);
        Task UpdateProfile(ProfileModel vendor, bool passwordUpdated, bool isVendor, bool isCutomer);
    }
}
