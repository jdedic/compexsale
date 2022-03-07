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
    public class VendorController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly IProfileService _profileService;

        public VendorController(IRepositoryWrapper repositoryWrapper, IMapper mapper, IProfileService profileService)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _profileService = profileService;
        }

        #region Views
        [Authorize]
        public IActionResult VendorList()
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
            var privateAccounts = _mapper.Map<List<ProfileModelDTO>>(await _repositoryWrapper.Profile.GetPrivateAccountProfiles()); 
            foreach (var item in privateAccounts)
            {
                item.IsAssigned = await _repositoryWrapper.Add.CheckIfVendorIsAssigned(item.Id);
            }
            return privateAccounts.ToArray();
        }

        [Authorize]
        public async Task<IEnumerable<BusinessAccountModel>> BusinessAccounts()
        {
            var businessAccounts = _mapper.Map<List<BusinessAccountModel>>(await _repositoryWrapper.Profile.GetBusinessAccountProfiles());
            foreach (var item in businessAccounts)
            {
                item.IsAssigned = await _repositoryWrapper.Add.CheckIfVendorIsAssigned(item.Id);
            }
            return businessAccounts.ToArray();
        }

        [Authorize]
        public IActionResult CreateVendor()
        {
            return View();
        }

        [Authorize]
        public IActionResult CreateBusinessAccount()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> EditVendor(long id)
        {
            var vendor = await _repositoryWrapper.Profile.GetProfileById(id);
            EditPrivateAccountDTO model = _mapper.Map<EditPrivateAccountDTO>(vendor);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EditBusinessAccount(long id)
        {
            var vendor = await _repositoryWrapper.Profile.GetProfileById(id);
            EditBusinessAccountDTO model = _mapper.Map<EditBusinessAccountDTO>(vendor);
            return View(model);
        }

        #endregion

        #region CRUD
        [Authorize]
        [HttpPost]
        [Route("Vendor/EditVendor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVendor(EditPrivateAccountDTO dto)
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
            await _profileService.UpdateProfile(_mapper.Map<ProfileModel>(dto), passwordUpdated, true, false);
            return Redirect("/Vendor/VendorList");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateVendor(PrivateAccountDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _profileService.CreateProfile(_mapper.Map<ProfileModel>(model), true, false);
            return RedirectToAction("VendorList", "Vendor");
        }

        [Authorize]
        [HttpPost]
        [Route("Vendor/RemoveVendor")]
        public async Task<IActionResult> RemoveVendor(long id)
        {
            var vendor = await _repositoryWrapper.Profile.GetProfileById(id);
            await _repositoryWrapper.Profile.Delete(vendor);
            return new JsonResult(new { done = "Done" });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBusinessAccount(CreateBusinessAccountDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _profileService.CreateProfile(_mapper.Map<ProfileModel>(model), true, false);
            return RedirectToAction("BusinessAccountList", "Vendor");
        }

        [Authorize]
        [HttpPost]
        [Route("Vendor/EditBusinessAccount")]
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
            await _profileService.UpdateProfile(_mapper.Map<ProfileModel>(dto), passwordUpdated, true, false);
            return Redirect("/Vendor/BusinessAccountList");
        }
        #endregion
    }
}
