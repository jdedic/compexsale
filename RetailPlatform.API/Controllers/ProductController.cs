using Microsoft.AspNetCore.Mvc;

namespace RetailPlatform.API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult ProductPreview()
        {
            return View();
        }
    }
}
