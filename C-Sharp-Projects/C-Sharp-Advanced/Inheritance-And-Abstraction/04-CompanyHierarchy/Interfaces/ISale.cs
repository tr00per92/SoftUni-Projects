using System;

namespace _04_CompanyHierarchy
{
    public interface ISale
    {
        DateTime Date { get; set; }

        string ProductName { get; set; }

        decimal Price { get; set; }
    }
}