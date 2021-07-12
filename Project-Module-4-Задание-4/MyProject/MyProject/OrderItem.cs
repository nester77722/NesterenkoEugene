using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class OrderItem
    {
        [Required, Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
