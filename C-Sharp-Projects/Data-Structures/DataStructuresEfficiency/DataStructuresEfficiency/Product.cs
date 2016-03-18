namespace DataStructuresEfficiency
{
    using System;

    public class Product : IEquatable<Product>, IComparable<Product>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(Product other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as Product);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
