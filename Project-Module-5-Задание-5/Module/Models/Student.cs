using System.Collections.Generic;

namespace ModuleDal.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
