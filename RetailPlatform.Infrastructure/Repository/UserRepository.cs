﻿using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RetailContext dbContext) : base(dbContext)
        {

        }

        public bool CheckIfEmailAlreadyExist(long userId, string email)
        {
            bool exist = false;
            if(userId != 0)
            {
                exist = _dbContext.Users.Any(model => model.Id != userId && model.Email.Equals(email));
            }
            else
            {
                exist = _dbContext.Users.Any(model => model.Email.Equals(email));
            }
            return exist;
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.Include(m => m.Role).FirstOrDefault(m => m.Email.Equals(email));
        }

        public string GetUserFullNameByEmail(string email)
        {
            return _dbContext.Users.Where(m => m.Email.Equals(email)).Select(m => m.FirstName + " " + m.LastName).FirstOrDefault();
        }

        public async Task<User> GetUserById(long id)
        {
            return await _dbContext.Users.Include(m => m.Role).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
