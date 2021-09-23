using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IWorkingHistoryRepository
    {
        void AddWorkingHistoryLogForManager(int managerId, int shopId);
        void EndWorkingHistoryForManager(int managerId);
        public IEnumerable<ManagerWorkingHistory> GetManagerWorkingHistory(int managerId);
    }
}
