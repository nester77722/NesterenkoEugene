using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class CartItem
    {
        [Required, Key]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
