using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper,
                             IRepositoryWrapper repositoryWrapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public IActionResult CategoryList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            var result = await _categoryService.FetchCategories();
            return result.ToArray();
        }

        [HttpPost]
        [Route("Category/CreateCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _categoryService.CreateCategory(_mapper.Map<Category>(category));
            return Redirect("/Category/CategoryList");
        }

        [HttpPost]
        [Route("Category/EditCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryDTO dto)
        {
            var result = await _repositoryWrapper.Category.GetCategoryById(dto.Id); 

            if(result == null)
            {
                return BadRequest();
            }

            await _repositoryWrapper.Category.Update(_mapper.Map<Category>(dto));
            return Redirect("/Category/CategoryList");
        }

        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _repositoryWrapper.Category.GetCategoryById(id);
            CategoryDTO dto = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
            return PartialView("EditCategory", dto);
        }

        [HttpPost]
        [Route("Category/RemoveCategory")]
        public async Task<IActionResult> RemoveCategory(long id)
        {
            var category = await _repositoryWrapper.Category.GetCategoryById(id);
            await _repositoryWrapper.Category.Delete(category);
            return new JsonResult(new { done = "Done" });
        }
    }
}
