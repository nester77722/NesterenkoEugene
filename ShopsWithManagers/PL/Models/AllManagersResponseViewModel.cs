using System.Collections.Generic;

namespace PL.Models
{
    public class AllManagersResponseViewModel
    {
        public IReadOnlyCollection<ManagerViewModel> Managers;
        public int TotalManagers { get; set; }
    }
}
