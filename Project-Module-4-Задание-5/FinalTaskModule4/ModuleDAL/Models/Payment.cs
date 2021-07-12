using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuleDal.Models
{
    public class Payment
    {
        [Required]
        public int Id { get; set; }

        public DateTime? Date { get; set; }
        public int Value { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
