using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SubCategoryController(ISubCategoryService subCategoryService, IMapper mapper,
                                     IRepositoryWrapper repositoryWrapper)
        {
            _subCategoryService = subCategoryService;
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult SubCategoryList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<SubCategoryModel>> Get()
        {
            var result = await _subCategoryService.FetchSubCategories();
            var subCategories = _mapper.Map<List<SubCategoryModel>>(result);
            foreach (var subCategory in subCategories)
            {
                subCategory.IsAssigned = _repositoryWrapper.SubCategory.IsAssignToProduct(subCategory.Id);
            }
            return subCategories.ToArray();
        }

        [Authorize]
        public async Task<IActionResult> CreateSubCategory()
        {
            SubCategoryDTO dto = new SubCategoryDTO();
            dto.FilteredCategories = _subCategoryService.FilterCategories();
            return PartialView("AddSubcategory", dto);
        }

        [Authorize]
        [HttpPost]
        [Route("SubCategory/CreateSubCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubCategory(SubCategoryDTO dto)
        {
            if (!ModelState.IsValid)
            {
                dto.FilteredCategories = _subCategoryService.FilterCategories();
                return PartialView("AddSubcategory", dto);
            }

            await _subCategoryService.CreateSubCategory(_mapper.Map<SubCategory>(dto), dto.SelectedCategory);
            return Redirect("/SubCategory/SubCategoryList");
        }

        [Authorize]
        public async Task<IActionResult> EditSubcategory(long id)
        {
            var subCategory = await _repositoryWrapper.SubCategory.GetSubCategoryById(id);
            SubCategoryDTO model = _mapper.Map<SubCategoryDTO>(subCategory);
            model.FilteredCategories = _subCategoryService.FilterCategories();
            model.SelectedCategory = subCategory.Category.Name;
            return PartialView("EditSubCategory", model);
        }

        [Authorize]
        [HttpPost]
        [Route("SubCategory/EditSubCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubCategory(SubCategoryDTO dto)
        {
            var subcategory = await _repositoryWrapper.SubCategory.GetSubCategoryById(dto.Id);
            if (!ModelState.IsValid)
            {
                dto.FilteredCategories = _subCategoryService.FilterCategories();
                return PartialView("EditSubcategory", dto);
            }

            await _subCategoryService.UpdateSubCategory(_mapper.Map<SubCategory>(dto), dto.SelectedCategory);
            return Redirect("/SubCategory/SubCategoryList");
        }

        [Authorize]
        [HttpPost]
        [Route("SubCategory/RemoveSubCategory")]
        public async Task<IActionResult> RemoveSubCategory(long id)
        {
            var subcategory = await _repositoryWrapper.SubCategory.GetSubCategoryById(id);
            await _repositoryWrapper.SubCategory.Delete(subcategory);
            return new JsonResult(new { done = "Done" });
        }
    }
}
