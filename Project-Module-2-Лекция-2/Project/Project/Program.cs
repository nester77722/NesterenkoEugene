using System;
using Project.Humans;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cook cook = new Cook("Богдан");

            Product[] products =
            {
                new Vegetable("Помидор", 20, 10, 5, 50, 800),
                new Meat("Куриная грудка", 20, 10, 5, 100, AnimalsType.Chicken),
                new Vegetable("Огурец", 20, 10, 5, 80, 800),
                new Vegetable("Перец болгарский", 20, 10, 5, 50, 800),
                new Fruit("Авокадо", 20, 10, 5, 120, 800),
                new Spice("Соль", 0, 0, 0, 0, true, false),
                new Spice("Перец молотый", 0.5, 0.2, 0, 0.3, false, true)
            };

            var dish = cook.CookDish("Салат с куриной грудкой", products);

            cook.DecorateDish(dish);

            Waiter waiter = new Waiter("Павел");

            waiter.ServeDish(dish);

            var sortedProducts = waiter.GetSortedProductsFromDish(dish, SortingType.ByCarbonhydrates);

            Console.WriteLine("\nПродукты отсортированные по количеству углеводов:\n");

            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"{product.Name} {product.CarbohydratesCount}");
            }
        }
    }
}
