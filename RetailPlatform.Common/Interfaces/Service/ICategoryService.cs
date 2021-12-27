using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> FetchCategories();
        Task CreateCategory(Category model);
    }
}
