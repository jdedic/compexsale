﻿using Microsoft.EntityFrameworkCore;
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
            var adds = _dbContext.Adds.ToList();

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
    }
}
