using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Abilities
{
	public abstract class HealAbility : SpecialAbility, IHealingAbility
    {
         public HealAbility(int abilityPower, AbilityType type, int hitChance,
            int baseCooldown, int currentCooldown, string hitMsg, string missMsg)
            : base(abilityPower, type, hitChance, baseCooldown, currentCooldown, hitMsg, missMsg)
        { }
        
         public void Heal(IPokemon target)
         {
             target.CurrentHealth += this.AbilityPower;
             if (target.CurrentHealth > target.MaxHealth)
             {
                 target.CurrentHealth = target.MaxHealth;
             }
         }
    }
}
