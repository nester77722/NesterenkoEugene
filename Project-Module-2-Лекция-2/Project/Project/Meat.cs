using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Meat : Product
    {
        public Meat(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, Animals animals)
            : base(name, energy, proteinsCount, fatsCount, carbohydratesCount, false)
        {
            Animals = animals;
        }

        public Meat(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, bool isFrozen, Animals animals)
            : this(name, energy, proteinsCount, fatsCount, carbohydratesCount, animals)
        {
            IsFrozen = isFrozen;
        }

        public bool IsFrozen { get; set; }

        public Animals Animals { get; private set; }
    }
}
