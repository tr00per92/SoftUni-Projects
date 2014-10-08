using System;
using System.Linq;

namespace _02_CustomLINQMethods
{
    public class Tests
    {
        public static void Main()
        {
            string[] towns = { "Sofia", "Plovdiv", "Varna", "Sopot", "Silistra", "Kaspichan" };

            var townsNotStartingWithS = towns.WhereNot(town => town.StartsWith("S"));
            townsNotStartingWithS.ToList().ForEach(town => Console.WriteLine(town));
            Console.WriteLine();

            var repeated = towns.Repeat(2);
            repeated.ToList().ForEach(town => Console.WriteLine(town));
            Console.WriteLine();

            var townEndingWithAorN = towns.WhereEndsWith(new[] { "a", "n" });
            townEndingWithAorN.ToList().ForEach(town => Console.WriteLine(town));
        }
    }
}
