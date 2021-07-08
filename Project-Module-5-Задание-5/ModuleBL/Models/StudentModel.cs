using System.Collections.Generic;

namespace ModuleBL.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int? Age { get; set; }
        public IEnumerable<PaymentModel> Payments { get; set; }
    }
}
