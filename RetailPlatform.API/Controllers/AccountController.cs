using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password)
        {
            if (_userService.CheckUserCredentials(username, password))
            {
                var fullName = _repositoryWrapper.User.GetUserFullNameByEmail(username);
                await HttpContext.SignInAsync(SetClaims(username, fullName));
                return RedirectToAction("AdminDashboard", "Home");
            }
            TempData["Error"] = "Error. Username or password is invalid.";
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
