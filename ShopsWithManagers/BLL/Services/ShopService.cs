using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public ShopService(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public IEnumerable<ShopModel> GetShops()
        {
            var shops = _shopRepository.GetShops();
            var shopsModels = _mapper.Map<IEnumerable<ShopModel>>(shops);

            return shopsModels;
        }
    }
}
