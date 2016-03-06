namespace Abilities
{
    using System;
    using Interfaces;

    public class Balefrost : DamageAbility
    {
        private const int BalefrostDamage = 8;
        private const int BalefrostHitChance = 8;
        private const int BalefrostBaseCooldown = 2;
        private const int BalefrostCurrentCooldown = 0;
        private const string BalefrostHitMessage = "Huge ice spikes shatter the ground and hit the enemy";
        private const string BalefrostMissMessage = "Balefrost has missed the target!";

        public Balefrost()
            : base(BalefrostDamage, AbilityType.Frost, BalefrostHitChance, BalefrostBaseCooldown,
            BalefrostCurrentCooldown, BalefrostHitMessage, BalefrostMissMessage)
        { }
    }
}