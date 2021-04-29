namespace Project.Dishes
{
    public class Dish
    {
        private Product[] _products;

        public Dish(string name, Product[] products)
        {
            Name = name;

            _products = products;
        }

        public string Name { get; private set; }

        public double Energy
        {
            get
            {
                double count = 0;

                foreach (var product in _products)
                {
                    count += product.Energy;
                }

                return count;
            }
        }

        public Product[] GetProducts()
        {
            return _products;
        }
    }
}
