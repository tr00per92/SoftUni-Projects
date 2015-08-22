namespace Estates.Data
{
    using System.Linq;

    using Engine;
    using Interfaces;

    internal class UpdatedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByPriceCommand(string minPrice, string maxPrice)
        {
            var offers = this.Offers
                .Where(offer => offer.Type == OfferType.Rent)
                .Cast<RentOffer>()
                .Where(offer => offer.PricePerMonth <= decimal.Parse(maxPrice) &&
                    offer.PricePerMonth >= decimal.Parse(minPrice))
                .OrderBy(offer => offer.PricePerMonth)
                .ThenBy(offer => offer.Estate.Name);

            return base.FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(offer => offer.Estate.Location == location &&
                    offer.Type == OfferType.Rent)
                .OrderBy(offer => offer.Estate.Name);

            return base.FormatQueryResults(offers);
        }
    }
}
