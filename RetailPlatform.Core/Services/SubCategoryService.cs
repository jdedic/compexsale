using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RetailPlatform.Core.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SubCategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<SubCategory>> FetchSubCategories()
        {
            return await _repositoryWrapper.SubCategory.GetSubCategories();
        }

        public IEnumerable<SelectListItem> FilterCategories()
        {
            List<SelectListItem> roles = new List<SelectListItem>();

            foreach (var role in _repositoryWrapper.Category.GetCategories())
            {
                SelectListItem item = new SelectListItem
                {
                    Value = role.Name,
                    Text = role.Name
                };
                roles.Add(item);
            }

            return new SelectList(roles, "Value", "Text");
        }

        public async Task CreateSubCategory(SubCategory model, string selectedCategory)
        {
            model.CategoryId = await _repositoryWrapper.Category.GetCategoryByName(selectedCategory);
            await _repositoryWrapper.SubCategory.Create(model);
        }

        public async Task UpdateSubCategory(SubCategory model, string category)
        {
            model.CategoryId = await _repositoryWrapper.Category.GetCategoryByName(category);
            await _repositoryWrapper.SubCategory.Update(model);
        }

    }
}
