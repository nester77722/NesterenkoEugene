using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Cook
{
    public class Cook : Human, ICook
    {
        public Cook(string name)
            : base(name)
        {
        }

        public Dish.Dish CookDish(string name, Product[] products)
        {
            return new Dish.Dish(name, products);
        }

        public void DecorateDish()
        {
            Console.WriteLine($"Cook {Name} decorated dish.");
        }
    }
}
