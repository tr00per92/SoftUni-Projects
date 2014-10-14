using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class Healer : BasicCharacter, IHeal
    {
        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, 75, 50, team, 6)
        {
            this.HealingPoints = 60;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList
                .Where(t => t.Team == this.Team && t != this)
                .OrderBy(t => t.HealthPoints)
                .FirstOrDefault();
            return target;
        }

        public override string ToString()
        {
            return base.ToString() + ", Healing: " + this.HealingPoints;
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.HealingPoints += item.HealthEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.HealingPoints -= item.HealthEffect;
        }
    }
}
