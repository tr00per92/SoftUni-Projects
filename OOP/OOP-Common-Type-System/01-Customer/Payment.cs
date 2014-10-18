using System;

namespace _01_Customer
{
    public class Payment : ICloneable
    {
        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public override bool Equals(object obj)
        {
            Payment otherPayment = obj as Payment;
            if (otherPayment == null)
            {
                return false;
            }

            if (this.ProductName != otherPayment.ProductName)
            {
                return false;
            }

            if (this.Price != otherPayment.Price)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return (int)this.Price ^ this.ProductName.GetHashCode();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Payment Clone()
        {
            return new Payment(string.Copy(this.ProductName), this.Price);
        }
    }
}
