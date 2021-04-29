namespace Project
{
    public abstract class Product
    {
        public Product(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, bool isJuiceable = false)
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

        public bool IsJuiceable { get; private set; }
    }
}
