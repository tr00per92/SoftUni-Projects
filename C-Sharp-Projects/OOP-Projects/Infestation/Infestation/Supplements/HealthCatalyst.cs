namespace Infestation
{
    public class HealthCatalyst : Supplement
    {
        private const int HealthEff = 3;

        public HealthCatalyst()
            : base(0, HealthCatalyst.HealthEff, 0)
        {
        }
    }
}
