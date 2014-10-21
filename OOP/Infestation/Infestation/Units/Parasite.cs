namespace Infestation
{
    public class Parasite : InfestingUnit
    {
        private const int BaseHealth = 1;
        private const int BasePower = 1;
        private const int BaseAggression = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.BaseHealth, Parasite.BasePower, Parasite.BaseAggression)
        {
        }
    }
}
