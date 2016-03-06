namespace Abilities
{
    using System;
    using Interfaces;

    public class Enflame : DamageAbility
    {
        private const int EnflameDamage = 13;
        private const int EnflameHitChance = 5;
        private const int EnflameBaseCooldown = 3;
        private const int EnflameCurrentCooldown = 0;
        private const string EnflameHitMessage = "The whole body of the enemy starts burning!";
        private const string EnflameMissMessage = "Enflame missed!";

        public Enflame()
            : base(EnflameDamage, AbilityType.Fire, EnflameHitChance, EnflameBaseCooldown,
            EnflameCurrentCooldown, EnflameHitMessage, EnflameMissMessage)
        { }
    }
}