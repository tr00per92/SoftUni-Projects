using System.Collections.Generic;
using System.Text;

namespace _04_CompanyHierarchy
{
    public class Manager : Employee, IManager
    {
        private ICollection<IRegularEmployee> employeesUnderCommand;

        public Manager(int id, string firstName, string lastName, Department department, decimal salary)
            : base(id, firstName, lastName, department, salary)
        {
            this.employeesUnderCommand = new List<IRegularEmployee>();
        }

        public void AddEmployee(IRegularEmployee employee)
        {
            this.employeesUnderCommand.Add(employee);
        }

        public void RemoveEmployee(IRegularEmployee employee)
        {
            this.employeesUnderCommand.Remove(employee);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.Append("Employees under his command: ");
            foreach (var employee in this.employeesUnderCommand)
            {
                result.Append(employee.FirstName + " " + employee.LastName + ", ");
            }

            return result.ToString().Trim(',', ' ');
        }
    }
}
