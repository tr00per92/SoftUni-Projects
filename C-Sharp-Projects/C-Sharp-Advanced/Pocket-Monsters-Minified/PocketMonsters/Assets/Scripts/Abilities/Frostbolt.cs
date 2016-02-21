namespace Abilities
{
    using System;
    using Interfaces;

    public class Frostbolt : DamageAbility
    {
        private const int FrostboltDamage = 5;
        private const int FrostboltHitChance = 9;
        private const int FrostboltBaseCooldown = 1;
        private const int FrostboltCurrentCooldown = 0;
        private const string FrostboltHitMessage = "The target has been hit by a massive frostbolt!";
        private const string FrostboltMissMessage = "Frostbolt has missed the target!";

        public Frostbolt()
            : base(FrostboltDamage, AbilityType.Frost, FrostboltHitChance,
            FrostboltCurrentCooldown, FrostboltBaseCooldown, FrostboltHitMessage, FrostboltMissMessage)
        { }
    }
}