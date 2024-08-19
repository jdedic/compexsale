using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetCategoryById(long id);
        List<Category> GetCategories();
        Task<long> GetCategoryByName(string name);
        Task<SubCategory> GetSubcategoryById(long id);
    }
}
