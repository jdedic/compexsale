using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.Infrastructure.Repository
{
    public class ProfileCategoryRepository : BaseRepository<ProfileCategory>, IProfileCategoryRepository
    {
        public ProfileCategoryRepository(RetailContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ProfileCategory>> GetProfileCategoriesByProfileId(long profileId)
        {
            return await _dbContext.ProfileCategories.Where(m => m.ProfileId == profileId).ToListAsync();
        }
    }
}
