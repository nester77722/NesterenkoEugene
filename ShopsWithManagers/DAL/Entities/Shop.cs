using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
