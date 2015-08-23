namespace FarmersCreed.Units
{
    using System;

    public class Product : GameObject, IProduct
    {
        private int quantity;

        public Product(string id, ProductType productType, int quantity)
            : base(id)
        {
            this.Quantity = quantity;
            this.ProductType = productType;
        }

        public ProductType ProductType { get; set; }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Quantity", "Product quantity cannot be negative.");
                }

                this.quantity = value;
            }
        }
        
        public override string ToString()
        {
            return base.ToString() + string.Format(", Quantity: {0}, Product Type: {1}", this.Quantity, this.ProductType);
        }
    }
}
