using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IAddRepository : IBaseRepository<Add>
    {
        IEnumerable<Add> FetchAdds(bool active);
        List<Category> GetCategories();
        Task<bool> CheckIfVendorIsAssigned(long vendorId);
    }
}
