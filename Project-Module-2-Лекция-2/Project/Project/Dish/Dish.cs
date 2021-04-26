using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dish
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

        public double Energy()
        {
            double count = 0;

            foreach (var product in _products)
            {
                count += product.Energy;
            }

            return count;
        }
    }
}
