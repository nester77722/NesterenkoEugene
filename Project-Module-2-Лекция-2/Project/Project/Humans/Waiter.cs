using System.Linq;
using Project.Dishes;

namespace Project.Humans
{
    public class Waiter : Human, IWaiter
    {
        public Waiter(string name)
             : base(name)
        {
        }

        public Product[] GetProductsFromDishSortedByCarbohydrates(Dish dish)
        {
            var products = dish.GetProducts();

            Product[] sortedProducts = products.OrderBy(o => o.CarbohydratesCount).ToArray();

            return sortedProducts;
        }

        public Product[] GetProductsFromDishSortedByEnergy(Dish dish)
        {
            var products = dish.GetProducts();

            Product[] sortedProducts = products.OrderBy(o => o.Energy).ToArray();

            return sortedProducts;
        }

        public Product[] GetProductsFromDishSortedByFats(Dish dish)
        {
            var products = dish.GetProducts();

            Product[] sortedProducts = products.OrderBy(o => o.FatsCount).ToArray();

            return sortedProducts;
        }

        public Product[] GetProductsFromDishSortedByProteins(Dish dish)
        {
            var products = dish.GetProducts();

            Product[] sortedProducts = products.OrderBy(o => o.ProteinsCount).ToArray();

            return sortedProducts;
        }
    }
}
