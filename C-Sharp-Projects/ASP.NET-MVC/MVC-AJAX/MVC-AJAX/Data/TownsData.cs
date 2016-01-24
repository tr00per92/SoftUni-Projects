namespace MVC_AJAX.Data
{
    using System.Collections.Generic;
    using MVC_AJAX.Models;

    public class TownsData
    {
        public IEnumerable<TownViewModel> All()
        {
            return new HashSet<TownViewModel>
            {
                new TownViewModel { Name = "Sofia" },
                new TownViewModel { Name = "Plovid" },
                new TownViewModel { Name = "Varna" },
                new TownViewModel { Name = "Bourgas" },
                new TownViewModel { Name = "Russe" },
                new TownViewModel { Name = "Veliko Tarnovo" },
                new TownViewModel { Name = "Sliven" },
                new TownViewModel { Name = "Blagoevgrad" },
                new TownViewModel { Name = "Haskovo" },
                new TownViewModel { Name = "Targovishte" },
                new TownViewModel { Name = "Stara Zagora" }
            };
        }  
    }
}
