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
        public List<Add> FetchAdds(bool active)
        {
            var adds = _dbContext.Adds.Include(m => m.UnitType).ToList();

            return active ? adds.Where(m => m.Active == true).ToList() : adds;
        }

        public async Task<IEnumerable<UnitType>> GetUnits()
        {
            return await _dbContext.UnitTypes.ToListAsync();
        }

        public async Task<IEnumerable<JobType>> GetJobTypes()
        {
            return await _dbContext.JobTypes.ToListAsync();
        }


        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public async Task<bool> CheckIfVendorIsAssigned(long vendorId)
        {
            return await _dbContext.Adds.AnyAsync(m => m.ProfileId == vendorId);
        }

        public async Task<Add> GetAddWithUnit(long id)
        {
            return await _dbContext.Adds.Include(m => m.SubCategory).Include(m => m.UnitType).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
