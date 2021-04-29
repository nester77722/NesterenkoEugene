using Project.Dishes;

namespace Project.Humans
{
    public interface IWaiter
    {
        public Product[] GetSortedProductsFromDish(Dish dish, SortingType sortingType);

        public void ServeDish(Dish dish);
    }
}
