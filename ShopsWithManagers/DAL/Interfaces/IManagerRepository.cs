using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IManagerRepository
    {
        void AddNewManager(Manager manager);
        void UpdateManager(Manager manager);
        AllManagersResponse GetManagers(int page, int pageSize, ManagerFilters filters);
        Manager GetManager(int managerId);
    }
}
