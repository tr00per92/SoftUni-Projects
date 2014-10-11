using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_SoftUniLearningSystem
{
    class SULSTest
    {
        static void Main()
        {
            var nakov = new SeniorTrainer("Svetlin", "Nakov", 35);
            var pesho = new JuniorTrainer("Pesho", "Peshev", 23);
            var kiro = new OnsiteStudent("Kiro", "Ivanov", 20, "222653", 3.63m, 4);
            var vanko = new OnsiteStudent("Ivan", "Dimitrov", 28, "122750", 5.63m, 6);
            var petko = new DropoutStudent("Petko", "Georgiev", 25, "56565", 2.50m, "low grades");
            var joro = new OnlineStudent("Joro", "Petrov", 22, "131365", 4.89m);
            var penka = new OnlineStudent("Penka", "Koncheva", 35, "656565", 4.2m);
            var toshko = new GraduateStudent("Tosho", "Ganchev", 29, "565656565", 5.40m);
            var ian = new OnsiteStudent("Ian", "Bibian", 24, "332693", 6, 5);

            var allPersons = new List<object> { nakov, pesho, kiro, vanko, petko, joro, penka, toshko, ian };
            allPersons
                .Where(person => person is CurrentStudent)
                .Cast<CurrentStudent>()
                .OrderByDescending(student => student.AverageGrade)
                .ToList()
                .ForEach(student => student.PrintInfo());
        }
    }
}
