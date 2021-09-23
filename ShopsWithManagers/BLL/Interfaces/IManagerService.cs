using BLL.Models;
using DAL;

namespace BLL.Interfaces
{
    public interface IManagerService
    {
        void AddManager(ManagerModel manager);
        void DismissFromWork(int managerId);
        void EmployManagerIntoShop(int managerId, int shopId);
        AllManagersResponseModel GetManagers(int page, int pageSize, ManagerFilters filters);
        ManagerModel GetManager(int managerId);
    }
}
