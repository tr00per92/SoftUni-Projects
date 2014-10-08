using System;
using System.Collections.Generic;

namespace _04_CompanyHierarchy
{
    public class CompanyHierarchy
    {
        public static void Main()
        {
            List<Employee> everyone = GetData();
            foreach (var person in everyone)
            {
                Console.WriteLine(person + "\n");
            }
        }

        public static List<Employee> GetData()
        {
            Developer gosho = new Developer(4, "Gosho", "Goshev", Department.Production, 1600);
            Project game = new Project("Super Game", new DateTime(2014, 4, 16), "The best game");
            gosho.AddProject(game);

            Developer petkan = new Developer(12, "Petkan", "Borisov", Department.Production, 1800);
            Project program = new Project("Super program", new DateTime(2014, 8, 18), "Very useful");
            petkan.AddProject(game);
            petkan.AddProject(program);

            Developer evlogi = new Developer(22, "Evlogi", "Goshev", Department.Production, 2500.65m);
            Project mobileApp = new Project("iOS only", new DateTime(2014, 1, 5), "uses swift");
            evlogi.AddProject(mobileApp);

            SalesEmployee dragan = new SalesEmployee(8, "Dragan", "Toshev", Department.Sales, 1202.65m);
            Sale topka = new Sale(new DateTime(2014, 5, 26), 420m, "Naduvaema topka");
            dragan.AddSale(topka);

            SalesEmployee penka = new SalesEmployee(6, "Penka", "Gencheva", Department.Accounting, 1000.55m);
            Sale balon = new Sale(new DateTime(2014, 2, 27), 510m, "Letyasht balon");
            penka.AddSale(balon);

            Manager peshoManager = new Manager(1, "Pesho", "Peshev", Department.Marketing, 4970);
            peshoManager.AddEmployee(gosho);
            peshoManager.AddEmployee(dragan);
            peshoManager.AddEmployee(petkan);
            peshoManager.AddEmployee(penka);
            peshoManager.AddEmployee(evlogi);

            List<Employee> result = new List<Employee> { gosho, dragan, petkan, penka, evlogi, peshoManager };
            return result;
        }
    }
}
