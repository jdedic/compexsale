using Microsoft.AspNetCore.Mvc;

namespace RetailPlatform.API.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerList()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
    }
}
