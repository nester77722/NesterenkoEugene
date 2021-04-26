namespace Project
{
    public class Fruit : Product
    {
        public Fruit(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, double millilitersOfJuicePerKilogram)
    : base(name, energy, proteinsCount, fatsCount, carbohydratesCount, true)
        {
            MillilitersOfJuicePerKilogram = millilitersOfJuicePerKilogram;
        }

        public double MillilitersOfJuicePerKilogram { get; private set; }
    }
}
