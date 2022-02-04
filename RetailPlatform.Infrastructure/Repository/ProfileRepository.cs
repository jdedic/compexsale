﻿using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.Infrastructure.Repository
{
    public class ProfileRepository : BaseRepository<ProfileModel>, IProfileRepository
    {
        public ProfileRepository(RetailContext dbContext) : base(dbContext)
        {

        }

        public bool CheckIfEmailAlreadyExist(string email)
        {
           return _dbContext.Profiles.Any(model => model.Email.Equals(email));
        }

        public async Task<List<ProfileModel>> GetPrivateAccountProfiles()
        {
            return await _dbContext.Profiles.Where(m => m.IsVendor == true && m.LegalEntity == false).ToListAsync();
        }

        public ProfileModel GetProfileByEmail(string email)
        {
            return _dbContext.Profiles.FirstOrDefault(m => m.Email.Equals(email));
        }

        public async Task<ProfileModel> GetVendorById(long id)
        {
            return await _dbContext.Profiles.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
