using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        [Required]
        public decimal Total { get; set; }

    }
}
