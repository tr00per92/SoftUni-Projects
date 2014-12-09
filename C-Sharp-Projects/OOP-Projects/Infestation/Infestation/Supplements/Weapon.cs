namespace Infestation
{
    public class Weapon : Supplement
    {
        public Weapon()
            : base(0, 0, 0)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = 10;
                this.AggressionEffect = 3;
            }
        }
    }
}
