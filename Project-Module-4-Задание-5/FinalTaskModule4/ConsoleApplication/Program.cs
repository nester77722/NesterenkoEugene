using System;
using System.Linq;
using ModulePL;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ModuleContext context = new ModuleContext();
            //Student newStudent = new Student() { FirstName = "John", LastName = "Collins", Age = 23 };
            //context.Add(newStudent);
            //context.SaveChanges();

            //var student = (from s in context.Students
            //               where s.FirstName == "John" && s.LastName == "Collins"
            //               select s).First();

            //Payment payment = new Payment() { Date = DateTime.Parse("11.05.2012"), Student = student, Value = 1500 };
            //Payment payment1 = new Payment() { Date = DateTime.Parse("11.06.2012"), Student = student, Value = 1500 };
            //context.AddRange(payment, payment1);
            //context.SaveChanges();

            var ctrl = new StudentsController();

            var student = ctrl.GetById(1);

            Console.WriteLine($"{student.FullName} {student.Age}");
            foreach (var item in student.Payments)
            {
                Console.WriteLine($"{item.Date} {item.Value}");
            }
        }
    }
}
