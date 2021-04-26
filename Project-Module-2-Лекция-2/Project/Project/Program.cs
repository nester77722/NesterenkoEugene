using System;
using System.Linq;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cook.Cook cook = new Cook.Cook("Ivan");

            Product[] products =
            {
                new Vegetable("Tomato", 20, 10, 5, 25, 800),
                new Meat("Куриная грудка", 20, 10, 5, 25, Animals.Chicken),
                new Vegetable("Сucumber", 20, 10, 5, 25, 800),
                new Vegetable("Pepper", 20, 10, 5, 25, 800),
                new Fruit("Apple", 20, 10, 5, 25, 800),
                new Spice("Salt", 20, 10, 5, 25, true, false)
            };

            var dish = cook.CookDish("Салат с куриной грудкой", products);

            cook.DecorateDish();

            Console.WriteLine(dish.Energy);
        }
    }
}
