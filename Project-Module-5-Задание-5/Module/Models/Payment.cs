using System;

namespace ModuleDal.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }
        public int Value { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
