using System.Collections.Generic;

namespace MyProject
{
    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> AddressList { get; set; }
    }
}