namespace _04_CompanyHierarchy
{
    using System;

    public interface IProject
    {
        DateTime StartDate { get; set; }

        string Details { get; set; }

        string Name { get; set; }

        void CloseProject();
    }
}