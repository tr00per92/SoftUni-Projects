namespace Abilities
{
    using System;
    using Interfaces;

    public class GlacialStorm : DamageAbility
    {
        private const int GlacialStormDamage = 12;
        private const int GlacialStormHitChance = 9;
        private const int GlacialStormBaseCooldown = 4;
        private const int GlacialStormCurrentCooldown = 0;
        private const string GlacialStormHitMessage = "The Glacial Storm freezes your enemy blood!";
        private const string GlacialStormMissMessage = "Glacial Storm failed to hit!";

        public GlacialStorm()
            : base(GlacialStormDamage, AbilityType.Frost, GlacialStormHitChance,
            GlacialStormBaseCooldown, GlacialStormCurrentCooldown, GlacialStormHitMessage, GlacialStormMissMessage)
        {

        }
    }
}