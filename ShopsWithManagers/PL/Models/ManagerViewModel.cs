using System.Collections.Generic;

namespace PL.Models
{
    public class ManagerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? CurrentShopId { get; set; }
        public IReadOnlyCollection<ManagerWorkingHistoryViewModel> WorkingHistories { get; set; }
    }
}
