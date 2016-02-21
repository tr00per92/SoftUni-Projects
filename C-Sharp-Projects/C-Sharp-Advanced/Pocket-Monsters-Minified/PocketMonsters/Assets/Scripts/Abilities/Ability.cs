namespace Abilities
{
    using System;
    using Interfaces;

    public abstract class Ability : IAbility
    {
        private int abilityPower;

        protected Ability(int abilityPower, AbilityType type)
        {
            this.AbilityPower = abilityPower;
            this.Type = type;
        }

        public int AbilityPower
        {
            get { return this.abilityPower; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid ability power value.");
                }

                this.abilityPower = value;
            }
        }

        public AbilityType Type { get; protected set; }

    }
}
