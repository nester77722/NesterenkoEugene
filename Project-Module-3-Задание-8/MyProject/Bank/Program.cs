using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount(100, "Ivan");
            bankAccount.Notify += DisplayMessage;
            bankAccount.Add(20);
            bankAccount.Take(30);
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
