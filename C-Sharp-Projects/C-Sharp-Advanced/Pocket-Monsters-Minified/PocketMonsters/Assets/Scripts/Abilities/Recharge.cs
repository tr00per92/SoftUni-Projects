namespace Abilities
{
    using System;
    using Interfaces;

    public class Recharge : HealAbility
    {
        private const int RechargeHeal = 8;
        private const int RechargeHitChance = 9;
        private const int RechargeBaseCooldown = 3;
        private const int RechargeCurrentCooldown = 0;
        private const string RechargeHitMessage = "The strong lightning force recharges the pokemon's health!";
        private const string RechargeMissMessage = "Recharge failed!";

        public Recharge()
            : base(RechargeHeal, AbilityType.Lightning, RechargeHitChance, RechargeBaseCooldown,
            RechargeCurrentCooldown, RechargeHitMessage, RechargeMissMessage)
        { }
    }
}