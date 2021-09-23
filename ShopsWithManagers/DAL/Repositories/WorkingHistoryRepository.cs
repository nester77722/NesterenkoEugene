using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class WorkingHistoryRepository : IWorkingHistoryRepository
    {
        private readonly ShopsDBContext _dbContext;

        public WorkingHistoryRepository(ShopsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void AddWorkingHistoryLogForManager(int managerId, int shopId)
        {
            var newWorkingHistoryLog = new ManagerWorkingHistory
            {
                ManagerId = managerId,
                ShopId = shopId,
                StartedWorkingAt = DateTime.UtcNow
            };

            await _dbContext.ManagersWorkingHistory.AddAsync(newWorkingHistoryLog);
            _dbContext.SaveChanges();
        }

        public void EndWorkingHistoryForManager(int managerId)
        {
            var managerWorkingHistory = GetManagerWorkingHistory(managerId);
            var workingHistoryLog = managerWorkingHistory.FirstOrDefault(log => log.StoppedWorkingAt == null);

            workingHistoryLog.StoppedWorkingAt = DateTime.UtcNow;

            _dbContext.SaveChanges();
        }

        public IEnumerable<ManagerWorkingHistory> GetManagerWorkingHistory(int managerId)
        {
            var workingHistory = _dbContext.ManagersWorkingHistory.Where(history => history.ManagerId == managerId).ToList();

            return workingHistory;
        }
    }
}
