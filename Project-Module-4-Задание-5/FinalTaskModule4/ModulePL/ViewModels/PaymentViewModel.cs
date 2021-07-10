using System;

namespace ModulePL.ViewModels
{
    public class PaymentViewModel
    {
        public PaymentViewModel(DateTime? date, int value )
        {
            Date = date;
            Value = value;
        }

        public DateTime? Date { get; set; }
        public int Value { get; set; }
    }
}
