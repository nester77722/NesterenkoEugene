using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        public delegate void MoneyChanged(string message);
        public event MoneyChanged Notify;
        public BankAccount(int amountOfMoney, string name)
        {
            AmountOfMoney = amountOfMoney;
            Name = name;
        }
        public int AmountOfMoney { get; private set; }
        public string Name { get; init; }
        public void Add(int amountOfMoney)
        {
            AmountOfMoney += amountOfMoney;
            Notify?.Invoke($"{Name} зачислил: {amountOfMoney}");
        }
        public void Take(int amountOfMoney)
        {
            if (AmountOfMoney >= amountOfMoney)
            {
                AmountOfMoney -= amountOfMoney;
                Notify?.Invoke($"{Name} снял: {amountOfMoney}");   // 2.Вызов события
            }
        }
    }
}
