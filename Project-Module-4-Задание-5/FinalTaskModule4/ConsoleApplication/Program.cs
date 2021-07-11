using System;
using ModuleDal;
using ModuleDal.Models;
//using ModulePL;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var ctrl = new StudentsController();

            //var student = ctrl.GetById(1);

            //Console.WriteLine($"{student.FullName} {student.Age}");
            //foreach (var item in student.Payments)
            //{
            //    Console.WriteLine($"{item.Date} {item.Value}");
            //}
            Student student = new Student() { FirstName = "John", LastName = "Collins", Age = 23 };
            ModuleContext context = new ModuleContext();
            context.Add(student);
            context.SaveChanges();
        }
    }
}
