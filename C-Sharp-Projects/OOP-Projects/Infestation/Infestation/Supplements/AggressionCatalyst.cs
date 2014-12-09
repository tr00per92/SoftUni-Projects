namespace Infestation
{
    public class AggressionCatalyst : Supplement
    {
        private const int AggressionEff = 3;

        public AggressionCatalyst()
            : base(0, 0, AggressionCatalyst.AggressionEff)
        {
        }
    }
}
