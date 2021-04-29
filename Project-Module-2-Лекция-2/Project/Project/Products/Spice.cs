namespace Project
{
    public class Spice : Product
    {
        public Spice(string name, double energy, double proteinsCount, double fatsCount, double carbohydratesCount, bool isSalty, bool isSpicy)
            : base(name, energy, proteinsCount, fatsCount, carbohydratesCount, false)
        {
            IsSalty = isSalty;
            IsSpicy = isSpicy;
        }

        public bool IsSalty { get; private set; }

        public bool IsSpicy { get; private set; }
    }

    public record SpiceRecord(bool isSalty, bool isSpicy);
}
