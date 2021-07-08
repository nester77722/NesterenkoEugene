using System.Collections.Generic;

namespace ModulePL.ViewModels
{
    public class StudentViewModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
