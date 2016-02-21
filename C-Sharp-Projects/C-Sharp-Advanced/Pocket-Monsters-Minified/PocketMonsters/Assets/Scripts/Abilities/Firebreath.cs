namespace Abilities
{
    using System;
    using Interfaces;

    public class Firebreath : DamageAbility
    {
        private const int FirebreathHeal = 4;
        private const int FirebreathDamage = 4;
        private const int FirebreathHitChance = 8;
        private const int FirebreathBaseCooldown = 2;
        private const int FirebreathCurrentCooldown = 0;
        private const string FirebreathHitMessage = "The force of fire stole some hit points from the enemy!";
        private const string FirebreathMissMessage = "Firebreath has missed the target!";

        public Firebreath()
            : base(FirebreathDamage, AbilityType.Fire, FirebreathHitChance, FirebreathBaseCooldown,
            FirebreathCurrentCooldown, FirebreathHitMessage, FirebreathMissMessage)
        { }
    }
}