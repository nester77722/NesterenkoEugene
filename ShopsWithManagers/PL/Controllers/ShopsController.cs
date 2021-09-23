using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Collections.Generic;

namespace PL.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;
        private readonly IMapper _mapper;

        public ShopsController(IShopService shopService, IMapper mapper)
        {
            _shopService = shopService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<ShopViewModel> GetShops()
        {
            var shopsModels = _shopService.GetShops();
            var shopsViewModels = _mapper.Map<IEnumerable<ShopViewModel>>(shopsModels);

            return shopsViewModels;
        }
    }
}
