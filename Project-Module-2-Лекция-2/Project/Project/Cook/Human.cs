using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Cook
{
    public class Human
    {
        public Human(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
