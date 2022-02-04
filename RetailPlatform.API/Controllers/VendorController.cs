using AutoMapper;
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

        public IActionResult VendorList()
        {
            return View();
        }

        public async Task<IEnumerable<ProfileModelDTO>> PrivateAccounts()
        {
            var privateAccounts = _mapper.Map<List<ProfileModelDTO>>(await _repositoryWrapper.Profile.GetPrivateAccountProfiles()); ;
            return privateAccounts.ToArray();
        }

        public IActionResult CreateVendor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVendor(PrivateAccountDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.LegalEntity = false;
            model.IsVendor = true;
            model.AgreeWithTermsAndConditions = true;
            await _profileService.CreateProfile(_mapper.Map<ProfileModel>(model));
            return RedirectToAction("VendorList", "Vendor");
        }

        public async Task<IActionResult> EditVendor(long id)
        {
            var vendor = await _repositoryWrapper.Profile.GetVendorById(id);
            EditPrivateAccountDTO model = _mapper.Map<EditPrivateAccountDTO>(vendor);
            return View(model);
        }

        [HttpPost]
        [Route("Vendor/EditVendor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVendor(EditPrivateAccountDTO dto)
        {
            var vendor = await _repositoryWrapper.Profile.GetVendorById(dto.Id);
            if (!ModelState.IsValid)
            {
                if (dto.Password == null)
                {
                    ModelState.Remove("Password");
                }

                if (!ModelState.IsValid)
                    return View(dto);
            }

            dto.IsVendor = true;
            dto.LegalEntity = false;
            dto.AgreeWithTermsAndConditions = true;
            var passwordUpdated = dto.Password != null ? true : false;
            dto.Password = passwordUpdated == false ? vendor.Password : dto.Password;
            await _profileService.UpdateProfile(_mapper.Map<ProfileModel>(dto), passwordUpdated);
            return Redirect("/Vendor/VendorList");
        }
    }
}
