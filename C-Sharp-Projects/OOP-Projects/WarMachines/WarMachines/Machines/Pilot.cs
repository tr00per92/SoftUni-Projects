namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class Pilot : IPilot
    {
        public Pilot(string name)
        {
            this.Name = name;
            this.Machines = new List<IMachine>();
        }

        public IList<IMachine> Machines { get; private set; }

        public string Name { get; private set; }

        public void AddMachine(IMachine machine)
        {
            this.Machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();
            result.AppendFormat("{0} - {1} {2}",
                this.Name,
                this.Machines.Count == 0 ? "no" : this.Machines.Count.ToString(),
                this.Machines.Count == 1 ? "machine" : "machines");

            foreach (var machine in this.Machines)
            {
                result.AppendFormat("\n{0}", machine);
            }

            return result.ToString().TrimEnd();
        }
    }
}
