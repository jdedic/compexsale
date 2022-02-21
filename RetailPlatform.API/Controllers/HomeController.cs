using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RetailPlatform.API.Models;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.API.Models.DTO.HomePage;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly IAddService _addService;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public HomeController(
            ILogger<HomeController> logger,
            IEmailService emailService,
            IAddService addService,
            IMapper mapper,
            IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _emailService = emailService;
            _addService = addService;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IActionResult> Index()
        {
            //fetch first 20 products
            //fetch subcategories
            HomepageModel model = new HomepageModel();
            model.FilteredCategories = await _addService.FilteredCategories();
            var adds = _addService.FetchAdds(true);
            model.Adds = new List<AddModel>();
            adds.Take(20).ToList().ForEach(m =>
            {
                var add = _mapper.Map<AddModel>(m);
                add.Category = _repositoryWrapper.SubCategory.GetSubcategoryById(m.SubCategoryId);
                model.Adds.Add(add);
            });
            return View(model);
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("Home/SendEmail")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(EmailModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _emailService.SendWelcomEmail(model.Email);
            return Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        //[Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("Home/AddsGrid")]
        public async Task<IActionResult> AddsGrid([Required]string title)
        {
            var adds = await _addService.FetchAddsBySubCategory(title);
            AddsGrid model = new AddsGrid();
            model.Title = title;
            model.FilteredCategories = await _addService.FilteredCategories(title);
            var subcategoryModel = await _repositoryWrapper.SubCategory.FetchSubcategoryByNameAsync(title);
            model.SelectedCategory = subcategoryModel != null ? subcategoryModel.Id.ToString() : "";
            model.Adds = new List<AddModel>();
            if(adds != null)
            {
                adds.ForEach(m =>
                {
                    var add = _mapper.Map<AddModel>(m);
                    add.Category = _repositoryWrapper.SubCategory.GetSubcategoryById(m.Id);
                    model.Adds.Add(add);
                });
            }
           
            return View(model);
        }

        [Authorize(Roles="Admin")]
        public IActionResult Secured()
        {
            return View();
        }

        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
