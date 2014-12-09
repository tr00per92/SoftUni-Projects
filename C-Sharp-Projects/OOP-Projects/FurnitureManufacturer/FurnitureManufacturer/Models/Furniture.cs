namespace FurnitureManufacturer.Models
{
    using System;

    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private const int MinimumModelLength = 3;

        private string model;
        private decimal price;
        private decimal height;
        private MaterialType material;

        protected Furniture(string model, decimal price, decimal height, MaterialType material)
        {
            this.Model = model;
            this.Price = price;
            this.Height = height;
            this.material = material;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model", "Cannot be null or empty.");
                }

                if (value.Length < MinimumModelLength)
                {
                    throw new ArgumentOutOfRangeException("Model", "Must be at least 3 symbols.");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material.ToString();
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price", "Must be a positive number.");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height", "Must be a positive number.");
                }

                this.height = value;
            }
        }
    }
}
