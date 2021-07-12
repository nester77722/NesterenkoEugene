using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

        [Required]
        public decimal Total { get; set; }

    }
}
