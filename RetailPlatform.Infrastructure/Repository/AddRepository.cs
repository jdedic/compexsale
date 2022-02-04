using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.Infrastructure.Repository
{
    public class AddRepository : BaseRepository<Add>, IAddRepository
    {
        public AddRepository(RetailContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Add> FetchAdds(bool active)
        {
            var adds = _dbContext.Adds.Include(m => m.Profile)
                .Include(m => m.SubCategory).ToList();

            return active ? adds.Where(m => m.Active == true).ToList() : adds;
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public async Task<bool> CheckIfVendorIsAssigned(long vendorId)
        {
            return await _dbContext.Adds.AnyAsync(m => m.ProfileId == vendorId);
        }
    }
}
