namespace ShoppingCenter
{
    using System;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public string Producer { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            if (other == null)
            {
                return 1;
            }

            var result = string.Compare(this.Name, other.Name, StringComparison.InvariantCulture);
            if (result == 0)
            {
                result = string.Compare(this.Producer, other.Producer, StringComparison.InvariantCulture);
            }

            if (result == 0)
            {
                result = this.Price.CompareTo(other.Price);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }
}