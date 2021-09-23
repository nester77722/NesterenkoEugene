using AutoMapper;
using BLL.Models;
using DAL.Entities;
using PL.Models;
using System.Collections;

namespace PL
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            CreateMap<Shop, ShopModel>();
            CreateMap<ShopModel, ShopViewModel>();

            CreateMap<Manager, ManagerModel>();
            CreateMap<ManagerModel, Manager>();

            CreateMap<ManagerModel, ManagerViewModel>();
            CreateMap<ManagerViewModel, ManagerModel>();

            CreateMap<ManagerWorkingHistory, ManagerWorkingHistoryModel>();
            CreateMap<ManagerWorkingHistoryModel, ManagerWorkingHistoryViewModel>();


            CreateMap<ManagersResponse, AllManagersResponseModel>();
            CreateMap<AllManagersResponseModel, AllManagersResponseViewModel>();
        }
    }
}
