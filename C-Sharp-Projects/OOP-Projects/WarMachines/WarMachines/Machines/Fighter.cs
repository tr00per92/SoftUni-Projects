namespace WarMachines.Machines
{
    using Interfaces;

    public class Fighter : Machine, IFighter
    {
        private const double InitialHeathPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, Fighter.InitialHeathPoints, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format("\n *Stealth: {0}", this.StealthMode ? "ON" : "OFF").TrimEnd();
        }
    }
}
