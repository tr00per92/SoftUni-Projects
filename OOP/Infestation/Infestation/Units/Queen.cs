namespace Infestation
{
    public class Queen : InfestingUnit
    {
        private const int BaseHealth = 30;
        private const int BasePower = 1;
        private const int BaseAggression = 1;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.BaseHealth, Queen.BasePower, Queen.BaseAggression)
        {
        }
    }
}
