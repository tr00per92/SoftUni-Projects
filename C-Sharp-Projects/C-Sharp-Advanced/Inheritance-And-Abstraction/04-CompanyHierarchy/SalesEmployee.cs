using System;
using System.Collections.Generic;
using System.Text;

namespace _04_CompanyHierarchy
{
    public class SalesEmployee : Employee, ISalesEmployee
    {
        private ICollection<Sale> sales;

        public SalesEmployee(int id, string firstName, string lastName,
            Department department, decimal salary)
            : base(id, firstName, lastName, department, salary)
        {
            this.sales = new List<Sale>();
        }

        public void AddSale(Sale sale)
        {
            this.sales.Add(sale);
        }

        public void RemoveSale(Sale sale)
        {
            this.sales.Remove(sale);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Employee sales: ");
            result.Append(string.Join("\n", this.sales));

            return result.ToString();
        }
    }
}
