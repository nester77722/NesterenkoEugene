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

        public Product[] GetSortedProductsFromDish(Dish dish, SortingType sortingType)
        {
            var products = dish.GetProducts();

            Product[] sortedProducts;

            switch (sortingType)
            {
                case SortingType.ByEnergy:
                    {
                        sortedProducts = products.OrderBy(product => product.Energy).ToArray();
                        break;
                    }

                case SortingType.ByCarbonhydrates:
                    {
                        sortedProducts = products.OrderBy(product => product.CarbohydratesCount).ToArray();
                        break;
                    }

                case SortingType.ByProteins:
                    {
                        sortedProducts = products.OrderBy(product => product.ProteinsCount).ToArray();
                        break;
                    }

                case SortingType.ByFats:
                    {
                        sortedProducts = products.OrderBy(product => product.FatsCount).ToArray();
                        break;
                    }

                default:
                    {
                        sortedProducts = products;
                        break;
                    }
            }

            return sortedProducts;
        }

        public void ServeDish(Dish dish)
        {
            System.Console.WriteLine($"Официант {Name} подал блюдо {dish.Name}");
        }
    }
}
