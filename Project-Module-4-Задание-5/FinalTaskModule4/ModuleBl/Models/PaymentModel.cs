using System;

namespace ModuleBL.Models
{
    public class PaymentModel
    {
        public PaymentModel(int id, DateTime? date, int value)
            : this(id, date, value, null)
        {
        }

        public PaymentModel(int id, DateTime? date, int value, StudentModel student)
        {
            Id = id;
            Date = date;
            Value = value;
            Student = student;
        }
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Value { get; set; }
        public StudentModel Student { get; set; }
    }
}
