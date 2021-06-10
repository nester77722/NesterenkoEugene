using System;

namespace Bridge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Add(new Person { Name = "Иван Алексеев", Number = "82184931" });
            bank.Add(new Company { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445" });
            bank.Accept(new ConsoleWriterVisitor());
            bank.Accept(new FileWriterVisitor());

            Console.Read();
        }
    }
}
