using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Manager
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        public int? CurrentShopId { get; set; }
        [ForeignKey("CurrentShopId")]
        public virtual Shop Shop { get; set; }
        public virtual IEnumerable<ManagerWorkingHistory> WorkingHistories { get; set; }
    }
}
