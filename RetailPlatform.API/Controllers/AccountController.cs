using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class AccountController : RetailController
    {
        private readonly IUserService _userService;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public AccountController(IUserService userService, IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _userService = userService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.Remove("Email");
                if(ModelState.IsValid == false)
                    return View("login");
            }

            if (_userService.CheckUserCredentials(model.Username, model.Password))
            {
                var user = _repositoryWrapper.User.GetUserByEmail(model.Username);
                await HttpContext.SignInAsync(SetClaims(model.Username, user.FirstName + " " + user.LastName, user.Id.ToString()));
                return RedirectToAction("AdminDashboard", "Home");
            }
            TempData["Error"] = "Error. Username or password is invalid.";
            return View("login");
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.Remove("Username");
                ModelState.Remove("Password");

                if (ModelState.IsValid == false)
                    return View("login");
            }

            if (_userService.CheckUserCredentials(model.Username, model.Password))
            {
                var user = _repositoryWrapper.User.GetUserByEmail(model.Username);
                await HttpContext.SignInAsync(SetClaims(model.Username, user.FirstName + " " + user.LastName, user.Id.ToString()));
                return RedirectToAction("AdminDashboard", "Home");
            }
            TempData["Message"] = "Zahtev za promenu šifre je uspešno poslat.";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
