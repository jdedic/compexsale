using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.API.Models.DTO.Add;
using RetailPlatform.API.Models.DTO.HomePage;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
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

        [Authorize]
        public async Task<IActionResult> CreateProduct()
        {
            CreateAddDTO add = new CreateAddDTO();
            add.FilteredCategories = await _addService.FilteredCategories();
            add.Units = await _addService.GetUnits();
            return View(add);
        }

        [Authorize]
        public async Task<IActionResult> CreateRequest()
        {
            CreateRequestDTO add = new CreateRequestDTO();
            add.FilteredCategories = await _addService.FilteredCategories();
            return View(add);
        }

        [Authorize]
        public async Task<IActionResult> EditProduct(long id)
        {
            EditAddDTO model = _mapper.Map<EditAddDTO>(await _addService.GetAddById(id));
            model.FilteredCategories = await _addService.FilteredCategories();
            model.Units = await _addService.GetUnits();
            model.JobTypes = await _addService.GetJobTypes();
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EditRequest(long id)
        {
            EditRequestDTO model = _mapper.Map<EditRequestDTO>(await _addService.GetAddById(id));
            model.FilteredCategories = await _addService.FilteredCategories();
            return View(model);
        }

        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("Product/CreateProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateAddDTO add)
        {
            add.ProfileId = Convert.ToInt16(User.FindFirstValue("userId"));
            if (!ModelState.IsValid)
            {
                add.FilteredCategories = await _addService.FilteredCategories();
                add.Units = await _addService.GetUnits();
                add.JobTypes = await _addService.GetJobTypes();
                return View(add);
            }

            if (add.FirstImg != null)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + add.FirstImg.FileName.Replace(" ", string.Empty);
                var filePath = @"wwwroot\images\adds\" + fileName;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await add.FirstImg.CopyToAsync(fileStream);
                }
                add.ImgUrl1 = $"/images/adds/{fileName}";
            } else
            {
                add.ImgUrl1 = "/images/icon/default-image.png";
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
            } else
            {
                add.ImgUrl2 = "/images/icon/default-image.png";
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
            } else
            {
                add.ImgUrl3 = "/images/icon/default-image.png";
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
            } else
            {
                add.ImgUrl4 = "/images/icon/default-image.png";
            }

            var id = await _addService.CreateAdd(_mapper.Map<Add>(add));
            var link = "https://compexsale.com/Product/EditProduct/" + id;
            var category = await _repositoryWrapper.Category.GetCategoryById(Int32.Parse(add.SelectedCategory));
            var user = await _repositoryWrapper.Profile.GetByIdAsync(add.ProfileId);
            await _emailService.SendEmailForCreatedAdd("Ponudi", add.Name, category.Name, user.Email, link);
            return Redirect("/adds");
        }

        [Authorize]
        [HttpPost]
        [Route("Product/CreateRequest")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRequest(CreateRequestDTO add)
        {
            add.ProfileId = Convert.ToInt16(User.FindFirstValue("userId"));
            if (!ModelState.IsValid)
            {
                add.FilteredCategories = await _addService.FilteredCategories();
                return View(add);
            }

            var id = await _addService.CreateRequest(_mapper.Map<Add>(add));
            var link = "https://compexsale.com/Product/EditRequest/" + id;
            var category = await _repositoryWrapper.Category.GetCategoryById(Int32.Parse(add.SelectedCategory));
            var user = await _repositoryWrapper.Profile.GetByIdAsync(add.ProfileId);
            await _emailService.SendEmailForCreatedAdd("Tražnji", add.Name, category.Name, user.Email, link);
            return Redirect("/requests");
        }


        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("Product/EditProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditAddDTO add)
        {
            var loggedRole = User.FindFirstValue("roleName").ToString();

            if (!ModelState.IsValid)
            {
                add.FilteredCategories = await _addService.FilteredCategories();
                add.Units = await _addService.GetUnits();
                add.JobTypes = await _addService.GetJobTypes();
                return View(add);
            }
            
            var entity = await _repositoryWrapper.Add.GetAddAsync(add.Id);
            var createdBy = await _repositoryWrapper.Profile.GetByIdAsync(entity.ProfileId);
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
            } else
            {
                add.ImgUrl1 = entity.ImgUrl1;
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
            } else
            {
                add.ImgUrl2 = entity.ImgUrl2;
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
            else
            {
                add.ImgUrl3 = entity.ImgUrl3;
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
            } else
            {
                add.ImgUrl4 = entity.ImgUrl4; 
            }

            if (add.Active && !entity.IsMailSent)
            {
                var id = "https://compexsale.com/Product/ProductPreview/" + entity.Id;
                await _emailService.SendEmailForAdd(createdBy.Email, id, entity.Name, null);
                var emails = await _addService.GetUsersBySubCategories(Convert.ToInt32(add.SelectedCategory1), Convert.ToInt32(add.SelectedCategory2), Convert.ToInt32(add.SelectedCategory3));
                foreach(var email in emails)
                {
                    await _emailService.SendEmailForAdd(email, id, entity.Name, null);
                }
                
                List<ProfileDTO> interestedProfiles = new List<ProfileDTO>();
                if (interestedProfiles.Any())
                {
                    await SendEmailToInterestedProfiles(interestedProfiles, id, entity.Name);
                }
            }

            var updatedAdd = await _addService.EditAdd(_mapper.Map<EditAddDTO, Add>(add, entity));
            if (loggedRole != "User")
            {
                add.Active = false;
            }

            await _addService.EditAdd(_mapper.Map<EditAddDTO, Add>(add, entity));

            if (!add.Confirmed)
            {
                await _emailService.SendEmailForRefusedAdd("jdedic2393@gmail.com", add.ReasonForRefusal);
            }

            return Redirect("/adds");
        }

        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("Product/EditRequest")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRequest(EditRequestDTO add)
        {
            if (!ModelState.IsValid)
            {
                add.FilteredCategories = await _addService.FilteredCategories();
                return View(add);
            }

            var entity = await _repositoryWrapper.Add.GetByIdAsync(add.Id);

            if (entity == null)
            {
                return BadRequest();
            }
            
            await _addService.EditRequest(_mapper.Map<EditRequestDTO, Add>(add, entity));
            return Redirect("/requests");
        }

        [Authorize]
        [HttpGet]
        [Route("adds")]
        public IActionResult Adds()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        [Route("requests")]
        public IActionResult Requests()
        {
            return View();
        }

        [HttpPost]
        [Route("Product/SendEmail")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(ProductPreviewDTO model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _emailService.SendContactClientEmail(model.Email, model.Name, model.Content);
            return View(new ContactForm());
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<AddDTO> Get()
        {
            var loggedRole = User.FindFirstValue("roleName").ToString();
            var userId = Convert.ToInt32(User.FindFirstValue("userId"));
            var adds = _addService.GetAdds();

            if (loggedRole != "User")
            {
                adds = adds.Where(m => m.ProfileId == userId).AsQueryable();
            }

            List<AddDTO> addsList = new List<AddDTO>();
            adds.ToList().ForEach(m =>
            {
                var add = _mapper.Map<AddDTO>(m);
                add.Unit = m.UnitType.Name;
                add.CreatedBy = _repositoryWrapper.Profile.GetProfileInfoById(m.ProfileId);
                add.Category = _repositoryWrapper.SubCategory.GetSubcategoryById(m.SubCategoryId);
                addsList.Add(add);
            });
            return addsList;
        }

        [HttpGet]
        public IEnumerable<RequestDTO> GetRequest()
        {
            var adds = _addService.FetchRequests();
            List<RequestDTO> requestList = new List<RequestDTO>();
            adds.ForEach(m =>
            {
                var add = _mapper.Map<RequestDTO>(m);
                add.CreatedBy = _repositoryWrapper.Profile.GetProfileInfoById(m.ProfileId);
                requestList.Add(add);
            });
            return requestList;
        }

        [HttpPost]
        [Route("Product/FilterProduct")]
        public IActionResult FilterProduct(long categoryId, string location, string name, long jobType)
        {
            var adds = _addService.FilterAdds(categoryId, location, name, jobType);
            List<AddModel> addsList = new List<AddModel>();
            adds.ForEach(m =>
            {
                var add = _mapper.Map<AddModel>(m);
                add.ImagePath = add.ImagePath == "https://compexsale.com" ? "/images/icon/default-image.png" : add.ImagePath;
                add.Category = _repositoryWrapper.SubCategory.GetSubcategoryById(m.SubCategoryId);
                addsList.Add(add);
            });
            return new JsonResult(new { adds = addsList });
        }

        public async Task<IActionResult> ProductPreview(long id)
        {
            var product = await _repositoryWrapper.Add.GetAddWithUnit(id);
            ProductPreviewDTO model = _mapper.Map<ProductPreviewDTO>(product);
            var jobType = await _repositoryWrapper.Add.GetJobTypeName(product.JobTypeId);
            model.IsRequest = jobType == "Tražnja" ? true : false;
            model.Date = product.CreationDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            model.Category = product.SubCategory.Name;
            model.Unit = product.UnitType.Name;
            model.SubCategoryId1 = product.SubCategoryId1 != null ? await _repositoryWrapper.Add.GetCategoryByAddId(product.SubCategoryId1) : string.Empty;
            model.SubCategoryId2 = product.SubCategoryId2 != null ? await _repositoryWrapper.Add.GetCategoryByAddId(product.SubCategoryId2) : string.Empty;
            model.SubCategoryId3 = product.SubCategoryId3 != null ? await _repositoryWrapper.Add.GetCategoryByAddId(product.SubCategoryId3) : string.Empty;
            return View(model);
        }

        [Authorize]
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

        [NonAction]
        public async Task SendEmailToInterestedProfiles(List<ProfileDTO> profiles, string id, string name)
        {
            foreach (var profile in profiles)
            {
                await _emailService.SendEmailForAdd(profile.Email, id, name, profile.FullName);
            }
        }
    }
}
