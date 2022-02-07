using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.Infrastructure.Repository
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(RetailContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await _dbContext.SubCategories.Include(m => m.Category).ToListAsync();
        }

        public bool IsCategoryAssigned(long id)
        {
            return _dbContext.SubCategories.Any(m => m.CategoryId > id);
        }

        public async Task<SubCategory> GetSubCategoryById(long id)
        {
            return await _dbContext.SubCategories.Include(m => m.Category).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool IsAssignToProduct(long id)
        {
            return _dbContext.Adds.Any(m => m.SubCategoryId == id);
        }

        public string GetSubcategoryById(long id)
        {
            return _dbContext.SubCategories.Where(m => m.Id == id).Select(m => m.Name).FirstOrDefault();
        }
    }
}
