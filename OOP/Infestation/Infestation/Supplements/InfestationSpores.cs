namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int PowerEff = -1;
        private const int AggressionEff = 20;

        public InfestationSpores()
            : base(InfestationSpores.PowerEff, 0, InfestationSpores.AggressionEff)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.PowerEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
