using RetailPlatform.Common.Entities;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        bool IsCategoryAssigned(long id);
        Task<Category> GetCategoryById(long id);
    }
}
