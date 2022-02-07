using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface ISubCategoryRepository : IBaseRepository<SubCategory>
    {
        bool IsCategoryAssigned(long id);
        Task<IEnumerable<SubCategory>> GetSubCategories();
        Task<SubCategory> GetSubCategoryById(long id);
        bool IsAssignToProduct(long id);
        string GetSubcategoryById(long id);
    }
}
