namespace Abilities
{
    using System;
    using Interfaces;

    public class Lightning : DamageAbility
    {
        private const int LightningDamage = 10;
        private const int LightningHitChance = 7;
        private const int LightningBaseCooldown = 3;
        private const int LightningCurrentCooldown = 0;
        private const string LightningHitMessage = "A huge bolt of electricity hits the enemy!";
        private const string LightningMissMessage = "Lightning misses the target!";

        public Lightning()
            : base(LightningDamage, AbilityType.Lightning, LightningHitChance,
            LightningBaseCooldown, LightningCurrentCooldown, LightningHitMessage, LightningMissMessage)
        { }
    }
}