using System.Collections.Generic;

namespace ModuleBL.Models
{
    public class StudentModel
    {
        public StudentModel(int id, string firstName, string lastName) 
            : this(id, firstName, lastName, 0, null)
        {
        }

        public StudentModel(int id, string firstName, string lastName, int? age)
            : this(id, firstName, lastName, age, null)
        {
        }

        public StudentModel(int id, string firstName, string lastName, IEnumerable<PaymentModel> payments)
            : this(id, firstName, lastName, 0, payments)
        {
        }

        public StudentModel(int id, string firstName, string lastName, int? age, IEnumerable<PaymentModel> payments)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Payments = payments;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public IEnumerable<PaymentModel> Payments { get; set; }
    }
}
