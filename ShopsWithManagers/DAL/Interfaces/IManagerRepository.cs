using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IManagerRepository
    {
        void AddManager(Manager manager);
        void UpdateManager(Manager manager);
        ManagersResponse GetManagers(int page, int pageSize, ManagerFilters filters);
        Manager GetManagerById(int managerId);
    }
}