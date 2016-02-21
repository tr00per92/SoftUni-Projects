namespace Abilities
{
    using System;

    public abstract class SpecialAbility : Ability
    {
        private static readonly Random HitChanceCalculator = new Random();

        protected SpecialAbility(int abilityPower, AbilityType type, int hitChance,
            int baseCooldown, int currentCooldown, string hitMsg, string missMsg)
            : base(abilityPower, type)
        {
            this.HitChance = hitChance;
            this.BaseCooldown = baseCooldown;
            this.CurrentCooldown = currentCooldown;
            this.HitMessage = hitMsg;
            this.MissMessage = missMsg;
        }

        public int HitChance { get; protected set; }

        public int BaseCooldown { get; private set; }

        public int CurrentCooldown { get; set; }

        public string HitMessage { get; protected set; }

        public string MissMessage { get; protected set; }
        
        public static bool TargetIsHit(SpecialAbility ability)
        {
            int currentHitChance = SpecialAbility.HitChanceCalculator.Next(1, 11);

            return ability.HitChance >= currentHitChance;
        }
    }
}
