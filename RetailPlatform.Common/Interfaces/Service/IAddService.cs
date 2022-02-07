using Microsoft.AspNetCore.Mvc.Rendering;
using RetailPlatform.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IAddService
    {
        List<Add> FetchAdds(bool active);
        Task RemoveAdd(long id);
        Task<IEnumerable<SelectListItem>> FilteredCategories();
        Task CreateAdd(Add model);
        Task<Add> GetAddById(long id);
        Task EditAdd(Add add);
        Task<IEnumerable<SelectListItem>> GetUnits();
        Task<IEnumerable<SelectListItem>> GetJobTypes();
    }
}
