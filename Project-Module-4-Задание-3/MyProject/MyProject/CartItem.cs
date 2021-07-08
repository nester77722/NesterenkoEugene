using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class CartItem
    {
        [Required]
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
