using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System;
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

        public async Task CreateProfile(ProfileModel model)
        {
            model.CreationDate = DateTime.Now;
            await Create(model);
        }

        public string GetProfileInfoById(long id)
        {
            return _dbContext.Profiles.Where(m => m.Id == id).Select(m => m.CompanyName).FirstOrDefault();
        }
    }
}
