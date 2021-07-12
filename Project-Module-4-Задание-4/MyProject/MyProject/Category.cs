using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
