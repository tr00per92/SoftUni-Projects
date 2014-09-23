using System;

namespace _01_LaptopShop
{
    class Battery
    {
        private double lifeInHours;

        public Battery(string description = null, double lifeInHours = 0)
        {
            this.Description = description;
            this.LifeInHours = lifeInHours;
        }

        public string Description { get; set; }
        public double LifeInHours
        {
            get { return this.lifeInHours; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.lifeInHours = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("{0}", this.Description ?? "Not specified");
            if (this.LifeInHours > 0)
            {
                result += string.Format("\nBattery Life: {0} hours", this.LifeInHours);
            }
            return result;
        }
    }
}
