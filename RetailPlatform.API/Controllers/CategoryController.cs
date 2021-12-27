using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
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

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
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
    }
}
