using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace RetailPlatform.Infrastructure.Repository
{
    public class AddRepository : BaseRepository<Add>, IAddRepository
    {
        public AddRepository(RetailContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Add> FetchActiveAdds()
        {
            return _dbContext.Adds.Where(m => m.Active == true).Include(m => m.Profile)
                .Include(m => m.SubCategory).ToList();
        }
    }
}
