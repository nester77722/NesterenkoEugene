using System;

namespace PL.Models
{
    public class ManagerWorkingHistoryViewModel
    {
        public DateTime StartedWorkingAt { get; set; }
        public DateTime? StoppedWorkingAt { get; set; }
        public int ManagerId { get; set; }
        public int ShopId { get; set; }
    }
}
