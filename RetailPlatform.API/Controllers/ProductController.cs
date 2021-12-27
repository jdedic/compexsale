using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAddService _addService;
        private readonly IMapper _mapper;

        public ProductController(IAddService addService, IMapper mapper)
        {
            _addService = addService;
            _mapper = mapper;
        }
        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult Adds()
        {
            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<AddDTO>> Get()
        {
            return _mapper.Map<IEnumerable<AddDTO>>(_addService.FetchActiveAdds());
        }
    }
}
