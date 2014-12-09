namespace _04_CompanyHierarchy
{
    public interface IManager : IEmployee
    {
        void AddEmployee(IRegularEmployee employee);

        void RemoveEmployee(IRegularEmployee employee);
    }
}