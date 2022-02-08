using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RetailPlatform.API.Models;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger,
            IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
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
