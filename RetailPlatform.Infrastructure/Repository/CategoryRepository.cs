using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RetailContext dbContext) : base(dbContext)
        {

        }

        public bool IsCategoryAssigned(long id)
        {
            return _dbContext.CategorySubCategories.Any(m => m.CategoryId > id);
        }

        public async Task<Category> GetCategoryById(long id)
        {
            return await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
