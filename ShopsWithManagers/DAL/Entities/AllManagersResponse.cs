using System.Collections.Generic;

namespace DAL.Entities
{
    public class AllManagersResponse
    {
        public IReadOnlyCollection<Manager> Managers { get; set; }
        public int TotalManagers { get; set; }
    }
}
