namespace Project
{
    public class Vegetable : Product
    {
        public Vegetable(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount)
            : base(name, energy, proteinsCount, fatsCount, carbohydratesCount, false)
        {
        }

        public Vegetable(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, double millilitersOfJuicePerKilogram)
            : base(name, energy, proteinsCount, fatsCount, carbohydratesCount, true)
        {
            MillilitersOfJuicePerKilogram = millilitersOfJuicePerKilogram;
        }

        public double MillilitersOfJuicePerKilogram { get; private set; }
    }
}
