using Microsoft.AspNetCore.Mvc.Rendering;
using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IAddService
    {
        List<Add> FetchAdds(bool active, bool visible);
        List<Add> FilterAdds(long categoryId, string location, string name, long jobTypeId);
        Task RemoveAdd(long id);
        Task<IEnumerable<SelectListItem>> FilteredCategories(string name=null);
        Task<long> CreateAdd(Add model);
        Task<Add> GetAddById(long id);
        Task<Add> EditAdd(Add add);
        Task<IEnumerable<SelectListItem>> GetUnits();
        Task<IEnumerable<SelectListItem>> GetJobTypes();
        Task<List<Add>> FetchAddsBySubCategory(string category, long jobTypeId);
        List<Add> FetchRequests();
        Task<long> CreateRequest(Add model);
        Task EditRequest(Add add);
        IQueryable<Add> GetAdds();
        Task<List<string>> GetUsersBySubCategories(int subcategory1, int subcategory2, int subcategory3);

        Task<IEnumerable<SelectListItem>> FilteredVendors(bool isLegalEntity);
    }
}
