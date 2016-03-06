namespace Abilities
{
    using System;
    using Interfaces;

    public class Armageddon : DamageAbility
    {
        private const int ArmageddonDamage = 20;
        private const int ArmageddonHitChance = 3;
        private const int ArmageddonBaseCooldown = 5;
        private const int ArmageddonCurrentCooldown = 0;
        private const string ArmageddonHitMessage = "The unstopable flames burn everything around!";
        private const string ArmageddonMissMessage = "Summoning Armageddon failed!";

        public Armageddon()
            : base(ArmageddonDamage, AbilityType.Fire, ArmageddonHitChance,
            ArmageddonBaseCooldown, ArmageddonCurrentCooldown, ArmageddonHitMessage, ArmageddonMissMessage)
        { } 
    }
}