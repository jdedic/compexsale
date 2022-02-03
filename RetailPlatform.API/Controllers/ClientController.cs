using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class ClientController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public ClientController(IRepositoryWrapper repositoryWrapper,IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult ProductPreview()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Vendor()
        {
            return View();
        }

        public IActionResult Register()
        {
            ProfileDTO model = new ProfileDTO();
            return View(model);
        }

        public IActionResult Logistic()
        {
            return View();
        }

        [HttpPost]
        [Route("Client/Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ProfileDTO model)
        {
         
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.LegalEntity == true && (string.IsNullOrEmpty(model.CompanyName) || string.IsNullOrEmpty(model.PIB) || (model.IsCustomer == model.IsVendor) || model.AgreeWithTermsAndConditions == false)) 
            {
                TempData["Error"] = "Popunite sva obavezna polja. (Polja sa označena crvenom zvezdicom)";
                return View(model);
            }

            if (model.LegalEntity == false && (string.IsNullOrEmpty(model.FullName) || string.IsNullOrEmpty(model.JMBG) || (model.IsCustomer == model.IsVendor) || model.AgreeWithTermsAndConditions == false))
            {
                TempData["Error"] = "Popunite sva obavezna polja. (Polja sa označena crvenom zvezdicom)";
                return View(model);
            }

            await _repositoryWrapper.Profile.CreateProfile(_mapper.Map<ProfileModel>(model));
            return RedirectToAction("Login", "Account");
        }


    }
}
