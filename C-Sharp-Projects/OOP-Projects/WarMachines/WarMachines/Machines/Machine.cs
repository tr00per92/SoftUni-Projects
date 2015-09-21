namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class Machine : IMachine
    {
        protected Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var result = string.Format("- {0}\n *Type: {1}\n *Health: {2}\n *Attack: {3}\n *Defense: {4}\n *Targets: {5}",
                this.Name,
                this.GetType().Name,
                this.HealthPoints,
                this.AttackPoints,
                this.DefensePoints,
                this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets));

            return result.TrimEnd();
        }
    }
}
