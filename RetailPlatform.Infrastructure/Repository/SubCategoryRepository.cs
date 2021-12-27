using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;

namespace RetailPlatform.Infrastructure.Repository
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(RetailContext dbContext) : base(dbContext)
        {

        }
    }
}
