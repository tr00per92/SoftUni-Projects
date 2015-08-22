namespace Estates.Data
{
    using System;

    using Interfaces;

    public abstract class Estate : IEstate
    {
        private double area;

        public string Name { get; set; }

        public EstateType Type { get; set; }

        public string Location { get; set; }

        public bool IsFurnished { get; set; }

        public double Area
        {
            get
            {
                return this.area;
            }

            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException("Area", "The area must be between 0 and 10000.");
                }

                this.area = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}",
                this.Type, this.Name, this.Area, this.Location, this.IsFurnished ? "Yes" : "No");
        }
    }
}
