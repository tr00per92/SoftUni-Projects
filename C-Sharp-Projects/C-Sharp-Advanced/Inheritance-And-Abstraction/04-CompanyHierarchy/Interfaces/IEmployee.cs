namespace _04_CompanyHierarchy
{
    public interface IEmployee : IPerson
    {
        Department Department { get; set; }

        decimal Salary { get; set; }
    }
}