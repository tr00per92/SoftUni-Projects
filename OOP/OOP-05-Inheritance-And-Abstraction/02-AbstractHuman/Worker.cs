using System;

namespace _02_AbstractHuman
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName,
            decimal weekSalary = 0, decimal workHoursPerDay = 0)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary { get; set; }

        public decimal WorkHoursPerDay { get; set; }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / 5 / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2:F2}", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
