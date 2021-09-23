using System.Collections.Generic;

namespace BLL.Models
{
    public class AllManagersResponseModel
    {
        public IReadOnlyCollection<ManagerModel> Managers { get; set; }
        public int TotalManagers { get; set; }
    }
}
