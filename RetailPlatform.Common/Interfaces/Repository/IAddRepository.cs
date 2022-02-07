﻿using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IAddRepository : IBaseRepository<Add>
    {
        List<Add> FetchAdds(bool active);
        List<Category> GetCategories();
        Task<bool> CheckIfVendorIsAssigned(long vendorId);
        Task<IEnumerable<UnitType>> GetUnits();
        Task<IEnumerable<JobType>> GetJobTypes();
    }
}
