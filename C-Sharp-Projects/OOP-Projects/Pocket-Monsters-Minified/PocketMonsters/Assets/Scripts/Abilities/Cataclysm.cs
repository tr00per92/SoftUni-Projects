namespace Abilities
{
    using System;
    using Interfaces;

    public class Cataclysm : DamageAbility
    {
        private const int CataclysmDamage = 100; 
        private const int CataclysmHitChance = 1;
        private const int CataclysmBaseCooldown = 5;
        private const int CataclysmCurrentCooldown = 0;
        private const string CataclysmHitMessage = "A massive hole from the ground devours enemy unit!";
        private const string CataclysmMissMessage = "Cataclysm has failed to begin!";

        public Cataclysm()
            : base(CataclysmDamage, AbilityType.Earth, CataclysmHitChance, CataclysmBaseCooldown,
            CataclysmCurrentCooldown, CataclysmHitMessage, CataclysmMissMessage)
        { }
    }
}