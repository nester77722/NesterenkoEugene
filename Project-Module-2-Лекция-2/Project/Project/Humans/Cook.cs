using System;
using Project.Dishes;

namespace Project.Humans
{
    public class Cook : Human, ICook
    {
        public Cook(string name)
            : base(name)
        {
        }

        public Dish CookDish(string name, Product[] products)
        {
            return new Dish(name, products);
        }

        public void DecorateDish(Dish dish)
        {
            Console.WriteLine($"Повар {Name} украсил блюдо {dish.Name}.");
        }
    }
}
