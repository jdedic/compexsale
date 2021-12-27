using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;

namespace RetailPlatform.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RetailContext dbContext) : base(dbContext)
        {

        }
    }
}
