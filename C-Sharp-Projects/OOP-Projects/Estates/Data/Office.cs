namespace Estates.Data
{
    using Interfaces;

    public class Office : BuildingEstate, IOffice
    {
        public Office()
        {
            this.Type = EstateType.Office;
        }
    }
}
