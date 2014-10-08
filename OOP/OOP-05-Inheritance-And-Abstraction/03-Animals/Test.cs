using System;
using System.Linq;

namespace _03_Animals
{
    public class Test
    {
        public static void Main()
        {
            Animal[] animals =
            {
                new Cat("Kotya", 4, Gender.Female),
                new Dog("Rex", 5, Gender.Male),
                new Frog("Cuoci", 7, Gender.Female),
                new Kitten("Ceca", 2),
                new Tomcat("Mitko", 3),
                new Tomcat("Gosho", 10),
                new Tomcat("Strahil", 13),
                new Kitten("Pepa", 1),
                new Kitten("Vanya", 6), 
                new Dog("Sharo", 10, Gender.Male),
                new Dog("Balkan", 7, Gender.Male),
                new Frog("Cuoci", 12, Gender.Male),
            };

            double averageCatAge = animals.Where(x => x is Cat).Average(x => x.Age);
            Console.WriteLine("Average cat age: " + averageCatAge);
            double averageDogAge = animals.Where(x => x is Dog).Average(x => x.Age);
            Console.WriteLine("Average dog age: " + averageDogAge);
            double averageFrogAge = animals.Where(x => x is Frog).Average(x => x.Age);
            Console.WriteLine("Average frog age: " + averageFrogAge);

            Console.WriteLine("Average age of all animals: " + animals.Average(x => x.Age));
            Console.WriteLine();

            // another solution
            animals.GroupBy(x => x.GetType().Name)
                .Select(group => new { Animal = group.Key, AverageAge = group.Average(x => x.Age) })
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
