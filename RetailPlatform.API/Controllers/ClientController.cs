using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class ClientController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly IProfileService _profileService;
        private readonly IEmailService _emailService;

        public ClientController(IRepositoryWrapper repositoryWrapper,IMapper mapper,
                                IProfileService profileService, IEmailService emailService)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _profileService = profileService;
            _emailService = emailService;
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Business()
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

            if((model.IsVendor == false && model.IsCustomer == false) || model.AgreeWithTermsAndConditions == false)
            {
                TempData["Error"] = "Popunite sva obavezna polja. (Polja sa označena crvenom zvezdicom)";
                return View(model);
            }

            if(model.LegalEntity == true && (model.CompanyName == null || model.PIB == null)) 
            {
                TempData["Error"] = "Popunite sva obavezna polja. (Polja sa označena crvenom zvezdicom)";
                return View(model);
            }
            else if (model.LegalEntity == false && (model.FullName == null || model.JMBG == null))
            {
                TempData["Error"] = "Popunite sva obavezna polja. (Polja sa označena crvenom zvezdicom)";
                return View(model);
            }



            await _profileService.CreateProfile(_mapper.Map<ProfileModel>(model), model.IsVendor, model.IsCustomer);
            return RedirectToAction("ClientLogin", "Client");
        }

        [HttpPost]
        [Route("Client/SendEmail")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(ContactForm model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _emailService.SendContactClientEmail(model.Email, model.Name, model.Content);
            return RedirectToAction("Contact", "Client");
        }

        public IActionResult ClientLogin()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        [HttpPost("client-login")]
        public async Task<IActionResult> Validate(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.Remove("Email");
                if (ModelState.IsValid == false)
                    return View("ClientLogin");
            }

            if (_profileService.CheckUserCredentials(model.Username, model.Password))
            {
                var user = _repositoryWrapper.Profile.GetProfileByEmail(model.Username);
                var name = (user.IsVendor == true && user.LegalEntity == true) ? user.CompanyName : user.FullName;
                await HttpContext.SignInAsync(SetClaims(model.Username, name, user.Id.ToString(), user.IsCustomer, user.IsVendor, user.LegalEntity, ""));
                return RedirectToAction("AdminDashboard", "Home");
            }
            TempData["Error"] = "Error. Username or password is invalid.";
            return View("ClientLogin");
        }

        public ClaimsPrincipal SetClaims(string username, string name, string id, bool isCustomer, bool isVendor, bool isPrivateAccount, string assignedRole)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("username", username));
            claims.Add(new Claim("roleName", "Profile")); 
            claims.Add(new Claim("isCustomer", isCustomer.ToString()));
            claims.Add(new Claim("isVendor", isVendor.ToString()));
            claims.Add(new Claim("isPrivateAccount", isPrivateAccount.ToString()));
            claims.Add(new Claim("loggedUser", name));
            claims.Add(new Claim("userId", id));
            claims.Add(new Claim("assignedRole", assignedRole));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
            claims.Add(new Claim(ClaimTypes.Name, name));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}
