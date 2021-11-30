using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
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

        [HttpGet]
        [Route("User/UserList")]
        public async Task<List<UserDTO>> UserList()
        {
            var users = await _userService.FetchUsers();
            var usersList = new List<UserDTO>();

            foreach (var user in users)
            {
                usersList.Add(new UserDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Telephone = user.Telephone
                    //SelectedRole = user.Role.ToString()
                });
            }
            
            return usersList;
        }

        public IActionResult CreateUser()
        {
            return View();
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
