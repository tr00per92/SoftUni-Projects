namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;

    public static class TestClass
    {
        public static void Main()
        {
            //DaoTest();

            //var employeesWithProjectsFrom2002 = EmployeesWithProjectFromYear(2002);
            //var employeesWithProjectsFrom2002Native = EmployeesWithProjectFromYearNative(2002);
            //var employeesFromSales = EmployeesFromDepartment("Sales");
            //var employeesWithManagerBrown = EmployeesWithManager("Jo", "Brown");

            //CreateSoftUniTwin();
            //PlayWithTwoDataContexts();

            //var employeesForTheNewProject = EmployeesFromDepartment("Engineering");
            //AddProject("Project 101", "The most important project for the engineers", employeesForTheNewProject);

			// First you must create the stored procedure in the database
            //var robProjectsCount = GetTotalProjects("Rob", "Walters");
        }

        public static void DaoTest()
        {
            Dao.AddEmployee("Pesho", "Goshev", "Web Developer", "Engineering", 4000);
            Dao.AddEmployee("Tosho", "Goshev", "Team Lead", "Finance", 2000);
            Dao.DeleteEmployee(295);
            Dao.UpdateEmployee(296, "Senior Developer", 2500);
        }

        public static ICollection<Employee> EmployeesWithProjectFromYear(int year)
        {
            using (var db = new SoftUniEntities())
            {
                return db.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == year)).ToList();
            }
        }

        public static ICollection<Employee> EmployeesWithProjectFromYearNative(int year)
        {
            using (var db = new SoftUniEntities())
            {
                return db.Database.SqlQuery<Employee>(
                    string.Format("SELECT DISTINCT e.EmployeeID, e.FirstName, e.MiddleName, e.LastName, e.AddressID, e.DepartmentID, e.Salary, " +
                        "e.HireDate, e.JobTitle, e.ManagerID FROM Employees e JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID " + 
                        "JOIN Projects p ON p.ProjectID = ep.ProjectId WHERE YEAR(p.StartDate) = {0}", year)).ToList();
            }
        }

        public static ICollection<Employee> EmployeesFromDepartment(string departmentName)
        {
            using (var db = new SoftUniEntities())
            {
                return db.Employees.Where(e => e.Department.Name == departmentName).ToList();
            }
        }

        public static ICollection<Employee> EmployeesWithManager(string firstName, string lastName)
        {
            using (var db = new SoftUniEntities())
            {
                return db.Employees.Where(e => e.Employee1.FirstName == firstName && e.Employee1.LastName == lastName).ToList();
            }
        }

        public static void CreateSoftUniTwin()
        {
            using (var connection = new SqlConnection("Server=.;Database=master;Integrated Security=true"))
            {
                connection.Open();
                using (var command = new SqlCommand("CREATE DATABASE SoftUniTwin", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand("USE SoftUniTwin", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var db = new SoftUniEntities())
                {
                    var dbScript = ((IObjectContextAdapter)db).ObjectContext.CreateDatabaseScript();
                    using (var command = new SqlCommand(dbScript, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void PlayWithTwoDataContexts()
        {
            using (var db = new SoftUniEntities())
            {
                using (var db2 = new SoftUniEntities())
                {
                    var employee = db.Employees.First();
                    employee.FirstName = "Pesho";
                    var employee2 = db2.Employees.First();
                    employee2.FirstName = "Gosho";
                    db.SaveChanges();
                    db2.SaveChanges();
                }
            }
        }

        public static void AddProject(string name, string description, ICollection<Employee> employees)
        {
            using (var db = new SoftUniEntities())
            {
                db.Projects.Add(new Project
                {
                    Name = name,
                    Description = description,
                    StartDate = DateTime.Now,
                    Employees = employees
                });

                db.SaveChanges();
            }
        }

        public static int? GetTotalProjects(string firstName, string lastName)
        {
            using (var db = new SoftUniEntities())
            {
                var result = db.usp_getTotalProjects(firstName, lastName).FirstOrDefault();
                if (result != null)
                {
                    return result.Value;
                }

                return null;
            }
        }
    }
}
