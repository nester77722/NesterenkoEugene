using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Cook
{
    public interface ICook
    {
        public Dish.Dish CookDish(string name, Product[] products);

        public void DecorateDish();
    }
}
