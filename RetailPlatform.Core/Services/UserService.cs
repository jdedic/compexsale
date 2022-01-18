using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using RetailPlatform.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<string> GenerateRefreshToken(User user)
        {
            var token = Guid.NewGuid().ToString() + "---" + DateTime.Now.AddHours(1);
            var encodedToken = RefreshToken.Base64Encode(token);
            user.ForgotPasswordToken = encodedToken;
            await _repositoryWrapper.User.Update(user);
            return encodedToken;
        }

        public async Task<IEnumerable<User>> FetchUsers()
        {
            return await _repositoryWrapper.User.FindAllAsync();
        }

        public async Task CreateUser(User user, string role)
        {
            user.RoleId = _repositoryWrapper.Role.GetRoleByName(role);
            user.Password = PasswordHasher.HashPassword(user.Password);
            await _repositoryWrapper.User.Create(user);
        }

        public async Task UpdateUser(User user, string role, bool passwordUpdated)
        {
            user.RoleId = _repositoryWrapper.Role.GetRoleByName(role);
            if(passwordUpdated)
                user.Password = PasswordHasher.HashPassword(user.Password);

            await _repositoryWrapper.User.Update(user);
        }

    }
}
