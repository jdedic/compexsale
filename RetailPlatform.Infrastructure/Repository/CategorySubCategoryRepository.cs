using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;

namespace RetailPlatform.Infrastructure.Repository
{
    public class CategorySubCategoryRepository : BaseRepository<CategorySubCategory>, ICategorySubCategoryRepository
    {
        public CategorySubCategoryRepository(RetailContext dbContext) : base(dbContext)
        {

        }
    }
}
