using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ShopsDBContext _dbContext;

        public ManagerRepository(ShopsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddManager(Manager manager)
        {
            _dbContext.Managers.Add(manager);
            _dbContext.SaveChanges();
        }

        public Manager GetManagerById(int managerId)
        {
            return _dbContext.Managers.Include(manager => manager.WorkingHistories).
                FirstOrDefault(manager => manager.Id == managerId);
        }

        public ManagersResponse GetManagers(int page, int pageSize, ManagerFilters filters)
        {
            var query = _dbContext.Managers.AsQueryable().AsNoTracking();

            if (filters.IsTimeFilterEnabled.HasValue && filters.IsTimeFilterEnabled.Value)
            {
                var managersResponse = from managers in _dbContext.Managers
                                       join history in _dbContext.ManagersWorkingHistory
                                       on managers.Id equals history.ManagerId
                                       orderby history.StartedWorkingAt
                                       select managers;

                query = managersResponse;
            }

            if (filters.ShopId.HasValue && filters.ShopId.Value != 0)
            {
                query = query.Where(manager => manager.CurrentShopId == filters.ShopId);
            }

            if(filters.Status is not null)
            {
                query = query.Where(manager => manager.Status.StartsWith(filters.Status));
            }

            return new ManagersResponse
            {
                Managers = query.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalManagers = query.Count()
            };
        }

        public void UpdateManager(Manager manager)
        {
            if (manager is not null)
            {
                _dbContext.Managers.Update(manager);
                _dbContext.SaveChanges();
            }
        }
    }
}
