using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }

        public int? CurrentShopId { get; set; }
        [ForeignKey("CurrentShopId")]
        public virtual Shop Shop { get; set; }
        public virtual IEnumerable<ManagerWorkingHistory> WorkingHistories { get; set; }
    }
}
