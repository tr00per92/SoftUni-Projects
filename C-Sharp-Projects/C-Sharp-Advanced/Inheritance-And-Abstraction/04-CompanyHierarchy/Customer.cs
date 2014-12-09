using System;

namespace _04_CompanyHierarchy
{
    public class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;

        public Customer(int id, string firstName, string lastName)
            : base(id, firstName, lastName)
        {
            this.netPurchaseAmount = 0;
        }

        public void PurchaseProduct(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("The price cannot be negative.");
            }

            this.netPurchaseAmount += price;
        }

        public override string ToString()
        {
            return base.ToString() + " Net purchase amount: " + this.netPurchaseAmount;
        }
    }
}
