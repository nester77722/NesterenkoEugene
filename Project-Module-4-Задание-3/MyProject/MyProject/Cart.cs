using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class Cart
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
