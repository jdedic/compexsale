using Microsoft.AspNetCore.Mvc;

namespace RetailPlatform.API.Views
{
    public class ClientController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
