namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class InfestingUnit : Unit
    {
        protected InfestingUnit(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> infestableUnits = units.Where(this.CanAttackUnit);

            UnitInfo optimalInfestableUnit = this.GetOptimalAttackableUnit(infestableUnits);

            if (optimalInfestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalInfestableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits.OrderBy(unit => unit.Health).FirstOrDefault();
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool canInfest = this.Id != unit.Id &&
                this.UnitClassification ==
                InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification);

            return canInfest;
        }
    }
}
