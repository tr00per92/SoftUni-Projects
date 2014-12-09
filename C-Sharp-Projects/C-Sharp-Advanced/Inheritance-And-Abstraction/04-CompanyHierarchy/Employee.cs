using System;

namespace _04_CompanyHierarchy
{
    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;

        protected Employee(int id, string firstName, string lastName,
            Department department, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Department = department;
            this.salary = salary;
        }

        public Department Department { get; set; }

        public decimal Salary
        {
            get { return this.salary; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The salary must be a positive number.");
                }

                this.salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nDepartment: {0}, Salary: {1}",
                this.Department.ToString(), this.Salary);
        }
    }
}
