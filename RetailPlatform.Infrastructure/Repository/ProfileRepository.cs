using Microsoft.EntityFrameworkCore;
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

        public async Task<List<ProfileModel>> GetPrivateProfiles()
        {
            return await _dbContext.Profiles.Where(m => m.IsCustomer == true && m.LegalEntity == false).ToListAsync();
        }

        public async Task<List<ProfileModel>> GetBusinessProfiles()
        {
            return await _dbContext.Profiles.Where(m => m.IsCustomer == true && m.LegalEntity == true).ToListAsync();
        }

        public async Task<List<ProfileModel>> GetBusinessAccountProfiles()
        {
            return await _dbContext.Profiles.Where(m => m.IsVendor == true && m.LegalEntity == true).ToListAsync();
        }

        public ProfileModel GetProfileByEmail(string email)
        {
            return _dbContext.Profiles.FirstOrDefault(m => m.Email.Equals(email));
        }

        public async Task<ProfileModel> GetProfileById(long id)
        {
            return await _dbContext.Profiles.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
