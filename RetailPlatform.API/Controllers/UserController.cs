using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
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
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserController(IUserService userService, IRoleService roleService, IMapper mapper,
                              IRepositoryWrapper repositoryWrapper)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
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

        public async Task<IActionResult> CreateUser()
        {
            UserDTO user = new UserDTO();
            user.FilteredRoleTypes = _roleService.FilterRoleTypes();
            return View(user);
        }

        [HttpPost]
        [Route("User/CreateUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                user.FilteredRoleTypes = _roleService.FilterRoleTypes();
                return View(user);
            }

            await _userService.CreateUser(_mapper.Map<User>(user), user.SelectedRole);
            return Redirect("/User/UserList");
        }

        public async Task<IActionResult> EditUser(long id)
        {
            var user = await _repositoryWrapper.User.GetUserById(id);
            EditUserDTO model = _mapper.Map<EditUserDTO>(user);
            model.FilteredRoleTypes = _roleService.FilterRoleTypes();
            model.SelectedRole = user.Role.Name;
            return View(model);
        }

        [HttpPost]
        [Route("User/EditUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserDTO dto)
        {
            var user = await _repositoryWrapper.User.GetUserById(dto.Id);
            if (!ModelState.IsValid)
            {
                if (user.Email.Equals(dto.Email))
                {
                    ModelState.Remove("Email");
                }

                if(dto.Password == null)
                {
                    ModelState.Remove("Password");
                }

                dto.FilteredRoleTypes = _roleService.FilterRoleTypes();
                if(!ModelState.IsValid)
                     return View(dto);
            }

            var passwordUpdated = dto.Password != null ? true : false;
            dto.Password = passwordUpdated == false ? user.Password : dto.Password;
            await _userService.UpdateUser(_mapper.Map<User>(dto), dto.SelectedRole, passwordUpdated);
            return Redirect("/User/UserList");
        }

        [HttpPost]
        [Route("User/RemoveUser")]
        public async Task<IActionResult> RemoveUser(long id)
        {
            var user = await _repositoryWrapper.User.GetUserById(id);
            await _repositoryWrapper.User.Delete(user);
            return new JsonResult(new { done = "Done" });
        }
    }
}
