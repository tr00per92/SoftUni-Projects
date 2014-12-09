namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, decimal price, decimal height,
            MaterialType material, int numberOfLegs)
            : base(model, price, height, material, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}
