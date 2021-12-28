using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RetailPlatform.Common.Interfaces.Service
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategory>> FetchSubCategories();
        IEnumerable<SelectListItem> FilterCategories();
        Task CreateSubCategory(SubCategory model, string selectedCategory);
        Task UpdateSubCategory(SubCategory model, string category);
    }
}
