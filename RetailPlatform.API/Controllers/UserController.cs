using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult UserList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var result = await _userService.FetchUsers();
            return result.ToArray();
        }

        public IActionResult CreateUser()
        {
            UserDTO user = new UserDTO();
            return View(user);
        }

        [HttpPost]
        [Route("User/CreateUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }


           
            return Redirect("/User/UserList");
        }
    }
}
