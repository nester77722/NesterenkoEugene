using System;

namespace BLL.Models
{
    public class ManagerWorkingHistoryModel
    {
        public int Id { get; set; }
        public DateTime StartedWorkingAt { get; set; }
        public DateTime? StoppedWorkingAt { get; set; }
        public int ManagerId { get; set; }
        public int ShopId { get; set; }

    }
}
