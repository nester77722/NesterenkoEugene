using System;
using System.IO;

namespace Bridge
{
    class FileWriterVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = $"Person {acc.Name } has number {acc.Number}";
            
            using (StreamWriter writer = new StreamWriter("outputText.txt", true))
            {
                writer.WriteLine(result);
            }
        }

        public void VisitCompanyAc(Company acc)
        {
            string result = $"Company {acc.Name} has number {acc.Number} and RegNumber {acc.RegNumber}";

            using (StreamWriter writer = new StreamWriter("outputText.txt", true))
            {
                writer.WriteLine(result);
            }
        }
    }
}
