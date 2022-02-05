using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using RetailPlatform.Core.Extensions;
using System;
using System.Threading.Tasks;

namespace RetailPlatform.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProfileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task CreateProfile(ProfileModel model, bool isVendor, bool isCustomer)
        {
            model.CreationDate = DateTime.Now;
            model.IsVendor = isVendor;
            model.IsCustomer = isCustomer;
            model.Password = PasswordHasher.HashPassword(model.Password);
            await _repositoryWrapper.Profile.Create(model);
        }

        public bool CheckUserCredentials(string email, string password)
        {
            var user = _repositoryWrapper.Profile.GetProfileByEmail(email);
            if (user != null)
            {
                var validatePassword = PasswordHasher.ValidatePassword(password, user.Password);
                return validatePassword == true ? true : false;
            }

            return false;
        }

        public async Task UpdateProfile(ProfileModel vendor, bool passwordUpdated, bool isVendor, bool isCutomer)
        {
            if (passwordUpdated)
                vendor.Password = PasswordHasher.HashPassword(vendor.Password);
            vendor.IsCustomer = isCutomer;
            vendor.IsVendor = isVendor;
            await _repositoryWrapper.Profile.Update(vendor);
        }
    }
}
