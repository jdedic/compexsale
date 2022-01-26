using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using System.Threading.Tasks;

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

        [HttpPost]
        [Route("Client/Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ProfileDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return Ok();
            //return Redirect("/User/UserList");
        }


    }
}
