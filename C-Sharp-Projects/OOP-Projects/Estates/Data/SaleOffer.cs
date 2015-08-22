namespace Estates.Data
{
    using Interfaces;

    public class SaleOffer : Offer, ISaleOffer
    {
        public SaleOffer()
        {
            this.Type = OfferType.Sale;
        }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Price = {0}", this.Price);
        }
    }
}
