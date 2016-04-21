namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static IList<int>[] employees;
        private static long[] salaries;

        public static void Main()
        {
            ReadGraph();
            foreach (var boss in FindBosses())
            {
                CalculateSalary(boss);
            }

            Console.WriteLine(salaries.Sum());
        }

        private static void CalculateSalary(int manager)
        {
            if (salaries[manager] > 1)
            {
                return;
            }

            var salary = 0L;
            foreach (var employee in employees[manager])
            {
                CalculateSalary(employee);
                salary += salaries[employee];
            }

            if (salary > 1)
            {
                salaries[manager] = salary;
            }
        }

        private static void ReadGraph()
        {
            var count = int.Parse(Console.ReadLine());
            salaries = new long[count];
            employees = new IList<int>[count];
            for (var i = 0; i < count; i++)
            {
                salaries[i] = 1;
                employees[i] = new List<int>();
                var input = Console.ReadLine();
                for (var j = 0; j < count; j++)
                {
                    if (input[j] == 'Y')
                    {
                        employees[i].Add(j);
                    }
                }
            }
        }

        private static IEnumerable<int> FindBosses()
        {
            for (var employee = 0; employee < employees.Length; employee++)
            {
                if (employees.All(manager => !manager.Contains(employee)))
                {
                    yield return employee;
                }
            }
        } 
    }
}
