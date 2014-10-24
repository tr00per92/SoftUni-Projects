namespace FurnitureManufacturer.Models
{
    using System;

    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.1m;

        public ConvertibleChair(string model, decimal price, decimal height,
            MaterialType material, int numberOfLegs)
            : base(model, price, height, material, numberOfLegs)
        {
            this.NormalHeight = height;
        }

        public decimal NormalHeight { get; private set; }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.Height = this.IsConverted ? this.NormalHeight : ConvertedHeight;
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4:F2}, Legs: {5}, State: {6}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal");
        }
    }
}
