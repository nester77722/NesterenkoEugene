using System.Collections.Generic;

namespace BLL.Models
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? CurrentShopId { get; set; }

        public IReadOnlyCollection<ManagerWorkingHistoryModel> WorkingHistories { get; set; }
    }
}
