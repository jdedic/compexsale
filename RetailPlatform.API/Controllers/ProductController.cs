using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.API.Models.DTO.Add;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAddService _addService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductController(
            IAddService addService,
            IMapper mapper,
            IEmailService emailService,
            IRepositoryWrapper repositoryWrapper)
        {
            _addService = addService;
            _mapper = mapper;
            _emailService = emailService;
            _repositoryWrapper = repositoryWrapper;
        }


        public async Task<IActionResult> CreateProduct()
        {
            CreateAddDTO add = new CreateAddDTO();
            add.FilteredCategories = await _addService.FilteredCategories();
            add.Units = await _addService.GetUnits();
            add.JobTypes = await _addService.GetJobTypes();
            return View(add);
        }

        public async Task<IActionResult> EditProduct(long id)
        {
            EditAddDTO model = _mapper.Map<EditAddDTO>(await _addService.GetAddById(id));
            model.FilteredCategories = await _addService.FilteredCategories();
            model.Units = await _addService.GetUnits();
            model.JobTypes = await _addService.GetJobTypes();
            return View(model);
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("Product/CreateProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateAddDTO add)
        {
            if (!ModelState.IsValid)
            {
                add.FilteredCategories = await _addService.FilteredCategories();
                add.Units = await _addService.GetUnits();
                add.JobTypes = await _addService.GetJobTypes();
                return View(add);
            }

            if (add.FirstImg != null)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + add.FirstImg.FileName;
                var filePath = @"wwwroot\images\adds\" + fileName;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await add.FirstImg.CopyToAsync(fileStream);
                }
                add.ImgUrl1 = $"/images/adds/{fileName}";
            }

            if (add.SecondImg != null)
            {
                var backgroundFileName = Guid.NewGuid().ToString() + "_" + add.SecondImg.FileName;
                var backgroundFilePath = @"wwwroot\images\adds\" + backgroundFileName;
                using (var fileStream = new FileStream(backgroundFilePath, FileMode.Create))
                {
                    await add.SecondImg.CopyToAsync(fileStream);
                }
                add.ImgUrl2 = $"/images/adds/{backgroundFileName}";
            }

            if (add.ThirdImg != null)
            {
                var imageFileName = Guid.NewGuid().ToString() + "_" + add.ThirdImg.FileName;
                var imageFilePath = @"wwwroot\images\adds\" + imageFileName;
                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    await add.ThirdImg.CopyToAsync(fileStream);
                }
                add.ImgUrl3 = $"/images/adds/{imageFileName}";
            }

            if (add.FourthImg != null)
            {
                var fourthImageFileName = Guid.NewGuid().ToString() + "_" + add.FourthImg.FileName;
                var fourthFilePath = @"wwwroot\images\adds\" + fourthImageFileName;
                using (var fileStream = new FileStream(fourthFilePath, FileMode.Create))
                {
                    await add.FourthImg.CopyToAsync(fileStream);
                }
                add.ImgUrl4 = $"/images/adds/{fourthImageFileName}";
            }

            await _addService.CreateAdd(_mapper.Map<Add>(add));
            return Redirect("/adds");
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("Product/EditProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditAddDTO add)
        {
            if (!ModelState.IsValid)
            {
                add.FilteredCategories = await _addService.FilteredCategories();
                add.Units = await _addService.GetUnits();
                add.JobTypes = await _addService.GetJobTypes();
                return View(add);
            }
            
            var entity = await _repositoryWrapper.Add.GetByIdAsync(add.Id);

            if(entity == null)
            {
                return BadRequest();
            }
           
            if (add.FirstImg != null)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + add.FirstImg.FileName;
                var filePath = @"wwwroot\images\adds\" + fileName;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await add.FirstImg.CopyToAsync(fileStream);
                }
                add.ImgUrl1 = $"/images/adds/{fileName}";
            }

            if (add.SecondImg != null)
            {
                var backgroundFileName = Guid.NewGuid().ToString() + "_" + add.SecondImg.FileName;
                var backgroundFilePath = @"wwwroot\images\adds\" + backgroundFileName;
                using (var fileStream = new FileStream(backgroundFilePath, FileMode.Create))
                {
                    await add.SecondImg.CopyToAsync(fileStream);
                }
                add.ImgUrl2 = $"/images/adds/{backgroundFileName}";
            }

            if (add.ThirdImg != null)
            {
                var imageFileName = Guid.NewGuid().ToString() + "_" + add.ThirdImg.FileName;
                var imageFilePath = @"wwwroot\images\adds\" + imageFileName;
                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    await add.ThirdImg.CopyToAsync(fileStream);
                }
                add.ImgUrl3 = $"/images/adds/{imageFileName}";
            }

            if (add.FourthImg != null)
            {
                var fourthImageFileName = Guid.NewGuid().ToString() + "_" + add.FourthImg.FileName;
                var fourthFilePath = @"wwwroot\images\adds\" + fourthImageFileName;
                using (var fileStream = new FileStream(fourthFilePath, FileMode.Create))
                {
                    await add.FourthImg.CopyToAsync(fileStream);
                }
                add.ImgUrl4 = $"/images/adds/{fourthImageFileName}";
            }

            await _addService.EditAdd(_mapper.Map<EditAddDTO, Add>(add, entity));

            if (add.Confirmed)
            {
                await _emailService.SendEmailForRefusedAdd("jdedic2393@gmail.com", add.ReasonForRefusal);
            }
            return Redirect("/adds");
        }

        [HttpGet]
        [Route("adds")]
        public IActionResult Adds()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<AddDTO> Get()
        {
            var adds = _addService.FetchAdds(false);
            List<AddDTO> addsList = new List<AddDTO>();
            adds.ForEach(m =>
            {
                var add = _mapper.Map<AddDTO>(m);
                add.CreatedBy = _repositoryWrapper.Profile.GetProfileInfoById(m.ProfileId);
                add.Category = _repositoryWrapper.SubCategory.GetSubcategoryById(m.Id);

                addsList.Add(add);
            });
            return addsList;
        }

        public IActionResult ProductPreview()
        {
            return View();
        }

        [HttpPost]
        [Route("Product/RemoveAdd")]
        public async Task<IActionResult> RemoveAdd(long id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            await _addService.RemoveAdd(id);
            return new JsonResult(new { done = "Done" });
        }
    }
}
