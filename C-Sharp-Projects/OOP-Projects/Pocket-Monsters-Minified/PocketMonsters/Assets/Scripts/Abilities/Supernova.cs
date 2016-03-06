namespace Abilities
{
    using System;
    using Interfaces;

    public class SuperNova : DamageAbility
    {
        private const int SuperNovaDamage = 16;
        private const int SuperNovaHitChance = 5;
        private const int SuperNovaBaseCooldown = 4;
        private const int SuperNovaCurrentCooldown = 0;
        private const string SuperNovaHitMessage = "The SuperNova released the ultimate force!";
        private const string SuperNovaMissMessage = "SuperNova has missed the target!";

        public SuperNova()
            : base(SuperNovaDamage, AbilityType.Lightning, SuperNovaHitChance, SuperNovaBaseCooldown,
            SuperNovaCurrentCooldown, SuperNovaHitMessage, SuperNovaMissMessage)
        { }
    }
}