using System.Collections.Generic;

namespace ModulePL.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel(string fullName, int? age)
            :this(fullName, age, null)
        {
        }

        public StudentViewModel(string fullName, int? age, IEnumerable<PaymentViewModel> payments)
        {
            FullName = fullName;
            Age = age == null ? 0 : (int)age;
            Payments = payments;
        }

        public string FullName { get; set; }
        public int Age { get; set; }

        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
