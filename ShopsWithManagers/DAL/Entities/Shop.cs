using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
