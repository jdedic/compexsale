using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
