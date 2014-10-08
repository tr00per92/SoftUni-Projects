using System;

namespace _04_CompanyHierarchy
{
    public class Sale : ISale
    {
        private string productName;
        private decimal price;

        public Sale(DateTime date, decimal price, string productName)
        {
            this.Date = date;
            this.Price = price;
            this.ProductName = productName;
        }

        public DateTime Date { get; set; }

        public string ProductName
        {
            get { return this.productName; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The product name cannot be empty.");
                }

                this.productName = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price must be a positive number.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}",
                this.Date.ToString("dd-MM-yy"), this.ProductName, this.Price);
        }
    }
}
