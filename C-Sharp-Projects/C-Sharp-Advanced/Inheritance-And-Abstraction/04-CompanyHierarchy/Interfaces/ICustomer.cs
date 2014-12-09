namespace _04_CompanyHierarchy
{
    public interface ICustomer : IPerson
    {
        void PurchaseProduct(decimal price);
    }
}