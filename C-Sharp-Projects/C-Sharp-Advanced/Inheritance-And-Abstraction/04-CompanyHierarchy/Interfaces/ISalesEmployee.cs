namespace _04_CompanyHierarchy
{
    public interface ISalesEmployee : IRegularEmployee
    {
        void AddSale(Sale sale);

        void RemoveSale(Sale sale);
    }
}