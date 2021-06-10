using System;

namespace Bridge
{
    class ConsoleWriterVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = $"Person {acc.Name } has number {acc.Number}";
            Console.WriteLine(result);
        }

        public void VisitCompanyAc(Company acc)
        {
            string result = $"Company {acc.Name} has number {acc.Number} and RegNumber {acc.RegNumber}";
            Console.WriteLine(result);
        }
    }
}
