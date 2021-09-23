using System.Collections.Generic;

namespace DAL.Entities
{
    public class ManagersResponse
    {
        public IReadOnlyCollection<Manager> Managers { get; set; }
        public int TotalManagers { get; set; }
    }
}
