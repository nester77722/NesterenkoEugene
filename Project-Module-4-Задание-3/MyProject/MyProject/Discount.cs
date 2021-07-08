using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class Discount
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}
