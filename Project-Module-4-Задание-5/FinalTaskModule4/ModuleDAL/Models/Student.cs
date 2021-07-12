using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModuleDal.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
            
        public ICollection<Payment> Payments { get; set; }
    }
}
