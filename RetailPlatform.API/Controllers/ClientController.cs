using Microsoft.AspNetCore.Mvc;

namespace RetailPlatform.API.Controllers
{
    public class ClientController : Controller
    {
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
    }
}
