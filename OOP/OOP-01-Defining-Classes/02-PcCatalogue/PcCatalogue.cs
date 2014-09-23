using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;

namespace _02_PcCatalogue
{
    class PcCatalogue
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            Component CPU = new Component("CPU", 302.69m, "Quad Core 4GHz");
            Component RAM = new Component("RAM", 170.18m, "8GB 1600MHz DDR3");
            Component videoCard = new Component("Video Card", 420.60m);
            Component motherboard = new Component("Motherboard", 110m);
            List<Component> myComponents = new List<Component> { CPU, RAM, videoCard, motherboard };
            Computer myComputer = new Computer("My Cool PC", myComponents);
            //Console.WriteLine(myComputer.getInfo());

            Component CPU2 = new Component("CPU", 380.69m, "Core i7");
            Component RAM2 = new Component("RAM", 300.23m, "16GB 1600MHz DDR3");
            Component videoCard2 = new Component("Video Card", 700.53m);
            Component SSD = new Component("Solid state drive", 200.50m, "128GB");
            Component motherboard2 = new Component("Motherboard", 150m);
            List<Component> goshoComponents = new List<Component> { CPU2, RAM2, videoCard2, SSD, motherboard2 };
            Computer goshoComputer = new Computer("Gosho's PC", goshoComponents);
            //Console.WriteLine(goshoComputer.getInfo());

            Component CPU1 = new Component("CPU", 350.69m, "Core i7");
            Component RAM1 = new Component("RAM", 300.23m, "16GB 1600MHz DDR3");
            Component videoCard1 = new Component("Video Card", 600.60m);
            Component HDD = new Component("Hard drive", 112.50m, "1TB space");
            List<Component> peshoComponents = new List<Component> { CPU1, RAM1, videoCard1, HDD };
            Computer peshoComputer = new Computer("Pesho's PC", peshoComponents);
            //Console.WriteLine(peshoComputer.getInfo());            

            List<Computer> allComputers = new List<Computer> { myComputer, goshoComputer, peshoComputer };
            allComputers
                .OrderByDescending(pc => pc.Price)
                .ToList()
                .ForEach(pc => Console.WriteLine(pc.getInfo() + "\n"));
        }
    }
}
