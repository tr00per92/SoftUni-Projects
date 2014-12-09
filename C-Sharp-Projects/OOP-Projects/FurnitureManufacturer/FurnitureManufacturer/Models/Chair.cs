namespace FurnitureManufacturer.Models
{
    using System;

    using Interfaces;

    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, decimal price, decimal height, MaterialType material, int numberOfLegs)
            : base(model, price, height, material)
        {
            this.numberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("NumberOfLegs", "Must be a positive number.");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
