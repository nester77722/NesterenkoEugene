using Project.Dishes;

namespace Project.Humans
{
    public interface ICook
    {
        public Dish CookDish(string name, Product[] products);

        public void DecorateDish();
    }
}
