using Project.Dishes;

namespace Project.Humans
{
    public interface IWaiter
    {
        public Product[] GetProductsFromDishSortedByEnergy(Dish dish);
        public Product[] GetProductsFromDishSortedByCarbohydrates(Dish dish);
        public Product[] GetProductsFromDishSortedByProteins(Dish dish);
        public Product[] GetProductsFromDishSortedByFats(Dish dish);

        public void ServeDish(Dish dish);
    }
}
