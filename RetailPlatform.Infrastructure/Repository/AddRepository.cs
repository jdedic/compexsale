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

        public List<Add> FetchAddsByJobTypeId(long jobTypeId)
        {
            var adds = _dbContext.Adds.Include(m => m.UnitType).Include(m => m.SubCategory).Where(m => m.JobTypeId == jobTypeId).ToList();

            return adds.Where(m => m.Active == true).ToList();
        }

        public IQueryable<Add> GetAdds()
        {
            return _dbContext.Adds.Include(m => m.UnitType).Where(m => m.JobTypeId == 1).AsQueryable();
        }

        public List<Add> FetchRequests()
        {
            return _dbContext.Adds.Include(m => m.SubCategory).Include(m => m.Profile).Where(m => m.JobTypeId == 2).ToList();
        }

        public string FetchLastAdd(bool active)
        {
            var add = _dbContext.Adds.OrderBy(m => m.Id).LastOrDefault(m => m.Active == active);

            return add != null ? add.UniqueId : null;
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

        public async Task<string> GetCategoryByAddId(long? id)
        {
            return await _dbContext.SubCategories.Where(m => m.Id == id).Select(m => m.Name).FirstOrDefaultAsync();
        }

        public async Task<string> GetJobTypeName(long id)
        {
            return await _dbContext.JobTypes.Where(m => m.Id == id).Select(m => m.Name).FirstOrDefaultAsync();
        }

        public async Task<Add> GetAddAsync(long id)
        {
            return await _dbContext.Adds.Where(x => x.Id == id).Include(x => x.Profile).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetEmailsForRequests(int subcategoryId)
        {
            return await _dbContext.Adds.Include(m => m.Profile)
                                    .Where(m => m.SubCategoryId == subcategoryId && m.Profile.IsCustomer == true
                                    && m.Active == true).Select(m => m.Profile.Email).Distinct().ToListAsync();
        }
    }
}
