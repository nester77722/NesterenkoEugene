using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Product
    {
        public Product(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount)
        {
            Name = name;

            Energy = energy;

            ProteinsCount = proteinsCount;

            FatsCount = fatsCount;

            CarbohydratesCount = carbohydratesCount;

            IsJuiceable = false;
        }

        public Product(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, bool isJuiceable)
        {
            Name = name;

            Energy = energy;

            ProteinsCount = proteinsCount;

            FatsCount = fatsCount;

            CarbohydratesCount = carbohydratesCount;

            IsJuiceable = isJuiceable;
        }

        public string Name { get; private set; }

        public double Energy { get; private set; }

        public double ProteinsCount { get; private set; }

        public double FatsCount { get; private set; }

        public double CarbohydratesCount { get; private set; }

        // Можно ли делать сок из продукта
        public bool IsJuiceable { get; private set; }
    }
}
