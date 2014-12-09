using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AbstractHuman
{
    public class Test
    {
        public static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Ivan", "Petrov", "113346"),
                new Student("Petar", "Petrov", "623331E"),
                new Student("Gosho", "Ivanov", "E1ER339"),
                new Student("Kiro", "Shanov", "1324552"),
                new Student("Koce", "Georgiev", "312565"),
                new Student("Emo", "Stilianov", "81933946"),
                new Student("Luben", "Ivanov", "9676964"),
                new Student("Mitko", "Chonev", "4363467"),
                new Student("Gencho", "Minkov", "4534783"),
                new Student("Nako", "Svetlinov", "2342346")
            };

            students.Sort((x, y) => x.FacultyNumber.CompareTo(y.FacultyNumber));
            students.ForEach(Console.WriteLine);
            Console.WriteLine();

            List<Worker> workers = new List<Worker>
            {
                new Worker("Kiril", "Demirev", 300, 8),
                new Worker("Vanko", "Edinichev", 400, 8),
                new Worker("Shosi", "Kondov", 350, 9),
                new Worker("Pena", "Markova", 500, 8),
                new Worker("Vania", "Petrova", 325, 8.5m),
                new Worker("Valeri", "Valeriev", 330.50m, 9),
                new Worker("Minko", "Penev", 200, 8),
                new Worker("Gabriel", "Iliev", 180, 7),
                new Worker("Tzvetan", "Genchev", 250, 8.5m),
                new Worker("Kristian", "Kozuharov", 280, 8),
            };

            workers.Sort((x, y) => y.MoneyPerHour().CompareTo(x.MoneyPerHour()));
            workers.ForEach(Console.WriteLine);
            Console.WriteLine();

            List<Human> mergedLists = new List<Human>();
            mergedLists.AddRange(students);
            mergedLists.AddRange(workers);
            mergedLists = mergedLists.OrderBy(x => x.FirstName + " " + x.LastName).ToList();
            mergedLists.ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));
        }
    }
}
