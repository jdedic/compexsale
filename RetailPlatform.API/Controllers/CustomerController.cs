using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly IProfileService _profileService;
        private readonly IProfileCategoryService _profileCategoryService;

        public CustomerController(IRepositoryWrapper repositoryWrapper, IMapper mapper, IProfileService profileService,
                                  IProfileCategoryService profileCategoryService)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _profileService = profileService;
            _profileCategoryService = profileCategoryService;
        }

        #region Views
        [Authorize]
        public IActionResult PrivateAccountList()
        {
            return View();
        }

        [Authorize]
        public IActionResult BusinessAccountList()
        {
            return View();
        }

        [Authorize]
        public async Task<IEnumerable<ProfileModelDTO>> PrivateAccounts()
        {
            var privateAccounts = _mapper.Map<List<ProfileModelDTO>>(await _repositoryWrapper.Profile.GetPrivateProfiles());
            return privateAccounts.ToArray();
        }

        [Authorize]
        public async Task<IEnumerable<BusinessAccountModel>> BusinessAccounts()
        {
            var businessAccounts = _mapper.Map<List<BusinessAccountModel>>(await _repositoryWrapper.Profile.GetBusinessProfiles());
            return businessAccounts.ToArray();
        }

        [Authorize]
        public IActionResult CreatePrivateAccount()
        {
            return View();
        }

        [Authorize]
        public IActionResult CreateBusinessAccount()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> EditBusinessAccount(long id)
        {
            var vendor = await _repositoryWrapper.Profile.GetProfileById(id);
            EditBusinessAccountDTO model = _mapper.Map<EditBusinessAccountDTO>(vendor);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EditPrivateAccount(long id)
        {
            var vendor = await _repositoryWrapper.Profile.GetProfileById(id);
            EditPrivateAccountDTO model = _mapper.Map<EditPrivateAccountDTO>(vendor);
            return View(model);
        }
        #endregion

        #region CRUD
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePrivateAccount(PrivateAccountDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var customer = _mapper.Map<ProfileModel>(model);

            await _profileService.CreateProfile(customer, false, true);
            return RedirectToAction("PrivateAccountList", "Customer");
        }

        [Authorize]
        [HttpPost]
        [Route("Customer/EditPrivateAccount")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPrivateAccount(EditPrivateAccountDTO dto)
        {
            var vendor = await _repositoryWrapper.Profile.GetProfileById(dto.Id);
            if (!ModelState.IsValid)
            {
                if (dto.Password == null)
                {
                    ModelState.Remove("Password");
                }

                if (!ModelState.IsValid)
                    return View(dto);
            }

            var passwordUpdated = dto.Password != null ? true : false;
            dto.Password = passwordUpdated == false ? vendor.Password : dto.Password;
            await _profileService.UpdateProfile(_mapper.Map<ProfileModel>(dto), passwordUpdated, false, true);
            return Redirect("/Customer/PrivateAccountList");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBusinessAccount(CreateBusinessAccountDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _profileService.CreateProfile(_mapper.Map<ProfileModel>(model), false, true);
            return RedirectToAction("BusinessAccountList", "Customer");
        }

        [Authorize]
        [HttpPost]
        [Route("Customer/RemoveCustomer")]
        public async Task<IActionResult> RemoveCustomer(long id)
        {
            var vendor = await _repositoryWrapper.Profile.GetProfileById(id);
            await _profileCategoryService.RemoveProfileCategories(id);
            await _repositoryWrapper.Profile.Delete(vendor);
            return new JsonResult(new { done = "Done" });
        }

        [Authorize]
        [HttpPost]
        [Route("Customer/EditBusinessAccount")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBusinessAccount(EditBusinessAccountDTO dto)
        {
            var vendor = await _repositoryWrapper.Profile.GetProfileById(dto.Id);
            if (!ModelState.IsValid)
            {
                if (dto.Password == null)
                {
                    ModelState.Remove("Password");
                }

                if (!ModelState.IsValid)
                    return View(dto);
            }

            var passwordUpdated = dto.Password != null ? true : false;
            dto.Password = passwordUpdated == false ? vendor.Password : dto.Password;
            await _profileService.UpdateProfile(_mapper.Map<ProfileModel>(dto), passwordUpdated, false, true);
            return Redirect("/Customer/BusinessAccountList");
        }
        #endregion
    }
}
