using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Linq;

namespace RetailPlatform.Infrastructure.Repository
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(RetailContext dbContext) : base(dbContext)
        {

        }

        public bool CheckIfEmailAlreadyExist(string email)
        {
           return _dbContext.Profiles.Any(model => model.Email.Equals(email));
        }
    }
}
