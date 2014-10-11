using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_PcCatalogue
{
    class Computer
    {
        private string name;
        private ICollection<Component> components;

        public Computer(string name, List<Component> components)
        {
            this.Name = name;
            this.Components = components;
        }
        public Computer(List<Component> components) : this("Unnamed", components) { }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }
                this.name = value;
            }
        }
        public ICollection<Component> Components
        {
            get { return this.components; }
            set 
            {
                if (value.Count < 1)
                {
                    throw new ArgumentException("The computer must have at least one component!");
                }
                this.components = value;
            }
        }
        public decimal Price
        {
            get { return this.components.Sum(component => component.Price); }
        }

        public string getInfo()
        {
            StringBuilder info = new StringBuilder();
            info.Append("Computer name: " + this.Name + "\n");
            foreach (var component in this.Components)
            {
                info.AppendFormat("{0} - Price: {1:C2} - Details: {2} \n", component.Name, component.Price, component.Details ?? "None");
            }
            info.AppendFormat("Total computer price: {0:C2}", this.Price);
            return info.ToString();
        }
    }
}
