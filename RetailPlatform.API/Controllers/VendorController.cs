using Microsoft.AspNetCore.Mvc;

namespace RetailPlatform.API.Controllers
{
    public class VendorController : Controller
    {
        public IActionResult VendorList()
        {
            return View();
        }

        public IActionResult CreateVendor()
        {
            return View();
        }
    }
}
