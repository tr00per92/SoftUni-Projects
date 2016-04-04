namespace EntityFramework
{
    using System;
    using System.Linq;

    public static class Dao
    {
        public static void AddEmployee(
            string firstName, 
            string lastName,
            string jobTitle,
            string department,
            decimal salary)
        {
            using (var db = new SoftUniEntities())
            {
                var newEmployee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    JobTitle = jobTitle,
                    Department = db.Departments.First(d => d.Name == department),
                    Salary = salary,
                    HireDate = DateTime.Now
                };

                db.Employees.Add(newEmployee);
                db.SaveChanges();
            }
        }

        public static void DeleteEmployee(int employeeId)
        {
            using (var db = new SoftUniEntities())
            {
                var employeeToDelete = db.Employees.First(e => e.EmployeeID == employeeId);
                db.Employees.Remove(employeeToDelete);
                db.SaveChanges();
            }
        }

        public static void UpdateEmployee(int employeeId, string newJobTitle, decimal newSalary)
        {
            using (var db = new SoftUniEntities())
            {
                var employee = db.Employees.First(e => e.EmployeeID == employeeId);
                employee.JobTitle = newJobTitle;
                employee.Salary = newSalary;
                db.SaveChanges();
            }
        }
    }
}
