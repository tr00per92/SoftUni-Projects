namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo target = attackableUnits
                .Where(unit => unit.Power <= this.Aggression)
                .OrderByDescending(unit => unit.Health)
                .FirstOrDefault();
            return target;
        }
    }
}
