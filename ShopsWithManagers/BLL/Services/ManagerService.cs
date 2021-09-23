using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IWorkingHistoryRepository _workingHistoryRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public ManagerService(IManagerRepository managerRepository, IWorkingHistoryRepository  workingHistoryRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _workingHistoryRepository = workingHistoryRepository;
            _mapper = mapper;
        }

        public void AddManager(ManagerModel manager)
        {
            _managerRepository.AddManager(_mapper.Map<Manager>(manager));

        }

        public void DismissFromWork(int managerId)
        {
            var currentManager = _managerRepository.GetManagerById(managerId);

            if (currentManager == null)
            {
                throw new Exception("No manager with such id!");
            }

            if (currentManager.CurrentShopId == null)
            {
                throw new Exception("Manager doesn't work!");
            }

            currentManager.CurrentShopId = null;
            _managerRepository.UpdateManager(currentManager);
            _workingHistoryRepository.EndWorkingHistoryForManager(managerId);
        }

        public void EmployManagerIntoShop(int managerId, int shopId)
        {
            var currentManager = _managerRepository.GetManagerById(managerId);

            if (currentManager == null)
            {
                throw new Exception("No manager with such id!");
            }

            if (currentManager.CurrentShopId.HasValue)
            {
                throw new Exception("Manager is already working!");
            }

            currentManager.CurrentShopId = shopId;
            _managerRepository.UpdateManager(currentManager);
            _workingHistoryRepository.AddWorkingHistoryLogForManager(managerId, shopId);
        }

        public ManagerModel GetManager(int managerId)
        {
            var manager = _managerRepository.GetManagerById(managerId);
            if(manager is null)
            {
                throw new Exception("No manager with such id!");
            }

            var managerModel = _mapper.Map<ManagerModel>(manager);

            return managerModel;
        }

        public AllManagersResponseModel GetManagers(int page, int pageSize, ManagerFilters filters)
        {
            var allManagers = _managerRepository.GetManagers(page, pageSize, filters);

            return _mapper.Map<AllManagersResponseModel>(allManagers);
        }
    }
}
