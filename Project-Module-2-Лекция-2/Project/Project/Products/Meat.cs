namespace Project
{
    public class Meat : Product
    {
        public Meat(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, AnimalsType animalsType)
            : base(name, energy, proteinsCount, fatsCount, carbohydratesCount, false)
        {
            AnimalsType = animalsType;
        }

        public Meat(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, bool isFrozen, AnimalsType animalsType)
            : this(name, energy, proteinsCount, fatsCount, carbohydratesCount, animalsType)
        {
            IsFrozen = isFrozen;
        }

        public bool IsFrozen { get; set; }

        public AnimalsType AnimalsType { get; private set; }
    }
}
