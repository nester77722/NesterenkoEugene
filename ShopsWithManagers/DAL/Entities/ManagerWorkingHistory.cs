using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ManagerWorkingHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartedWorkingAt { get; set; }
        public DateTime? StoppedWorkingAt { get; set; }

        [Required]
        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Manager Manager{ get; set; }

        [Required]
        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }
    }
}
