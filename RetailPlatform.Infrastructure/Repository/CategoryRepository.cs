using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RetailContext dbContext) : base(dbContext)
        {

        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public async Task<Category> GetCategoryById(long id)
        {
            return await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<SubCategory> GetSubcategoryById(long id)
        { 
            return await _dbContext.SubCategories.AsNoTracking().FirstOrDefaultAsync(subCategory => subCategory.Id == id);
        }

        public async Task<long> GetCategoryByName(string name)
        {
            return await _dbContext.Categories.Where(m => m.Name.ToLower().Equals(name.ToLower()))
                        .Select(m => m.Id).FirstOrDefaultAsync();
        }
    }
}
