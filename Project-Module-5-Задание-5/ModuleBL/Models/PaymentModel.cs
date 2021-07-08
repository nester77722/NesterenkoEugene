using System;

namespace ModuleBL.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Value { get; set; }
        public StudentModel Student { get; set; }
    }
}
