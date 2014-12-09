namespace WarMachines.Machines
{
    using Interfaces;

    public class Tank : Machine, ITank
    {
        private const double InitialHeathPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, Tank.InitialHeathPoints, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            if (this.DefenseMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format("\n *Defense: {0}", this.DefenseMode ? "ON" : "OFF").TrimEnd();
        }
    }
}
