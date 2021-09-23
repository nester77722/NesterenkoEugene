using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IWorkingHistoriesRepository
    {
        void AddNewWorkingHistoryLogForManager(int managerId, int shopId);
        void CompleteWorkingHistoryForManager(int managerId);
        public IEnumerable<ManagerWorkingHistory> GetManagerWorkingHistory(int managerId);
    }
}
