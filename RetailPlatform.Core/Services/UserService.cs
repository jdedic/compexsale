using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using RetailPlatform.Core.Extensions;

namespace RetailPlatform.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public bool CheckUserCredentials(string email, string password)
        {
            var user = _repositoryWrapper.User.GetUserByEmail(email);
            if(user != null)
            {
                var validatePassword = PasswordHasher.ValidatePassword(password, user.Password);
                return validatePassword == true ? true : false;
            }

            return false;
        }
    }
}
