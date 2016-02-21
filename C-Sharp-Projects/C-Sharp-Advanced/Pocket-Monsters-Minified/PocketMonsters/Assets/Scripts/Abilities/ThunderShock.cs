namespace Abilities
{
    using System;
    using Interfaces;

    public class Thundershock : DamageAbility
    {
        private const int ThundershockDamage = 7;
        private const int ThundershockHitChance = 9;
        private const int ThundershockBaseCooldown = 2;
        private const int ThundershockCurrentCooldown = 0;
        private const string ThundershockHitMessage = "The target has been thudnershocked!";
        private const string ThundershockMissMessage = "Thundershock has missed the target!";

        public Thundershock()
            : base(ThundershockDamage, AbilityType.Lightning, ThundershockHitChance, ThundershockBaseCooldown,
            ThundershockCurrentCooldown, ThundershockHitMessage, ThundershockMissMessage)
        { }
    }
}
