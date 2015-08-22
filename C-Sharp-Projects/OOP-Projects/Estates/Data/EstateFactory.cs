namespace Estates.Data
{
    using System;

    using Interfaces;
    
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new UpdatedEstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment:
                    return new Apartment();
                case EstateType.House:
                    return new House();
                case EstateType.Office:
                    return new Office();
                case EstateType.Garage:
                    return new Garage();
                default:
                    throw new ArgumentException("Unsupported estate type.");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent:
                    return new RentOffer();
                case OfferType.Sale:
                    return new SaleOffer();
                default:
                    throw new ArgumentException("Unsupported offer type.");
            }
        }
    }
}
