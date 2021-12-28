using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<Category>> FetchCategories()
        {
            List<Category> list = new List<Category>();
            foreach(var category in await _repositoryWrapper.Category.FindAllAsync())
            {
                category.IsAssigned = _repositoryWrapper.SubCategory.IsCategoryAssigned(category.Id);
                list.Add(category);
            }
            return list;
        }

        public async Task CreateCategory(Category model)
        {
            await _repositoryWrapper.Category.Create(model);
        }
    }
}
