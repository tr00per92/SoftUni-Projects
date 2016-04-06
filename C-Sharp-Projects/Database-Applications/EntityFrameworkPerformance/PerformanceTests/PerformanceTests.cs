namespace PerformanceTests
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PerformanceTests
    {
        public static void Main()
        {
            ShowDataFromRelatedTables();
            UsingToList();
            SelectPerformance();
        }

        public static void ShowDataFromRelatedTables()
        {
            using (var db = new AdsEntities())
            {
                foreach (var ad in db.Ads)
                {
                    Console.WriteLine(
                        "Title: {0}, Status: {1}, Category: {2}, Town: {3}, User: {4}",
                        ad.Title,
                        ad.AdStatus.Status,
                        ad.Category != null ? ad.Category.Name : "None",
                        ad.Town != null ? ad.Town.Name : "None",
                        ad.AspNetUser.UserName);
                }
                
                Console.WriteLine();
                foreach (var ad in db.Ads.Include(a => a.Town).Include(a => a.AdStatus).Include(a => a.Category).Include(a => a.AspNetUser))
                {
                    Console.WriteLine(
                        "Title: {0}, Status: {1}, Category: {2}, Town: {3}, User: {4}",
                        ad.Title,
                        ad.AdStatus.Status,
                        ad.Category != null ? ad.Category.Name : "None",
                        ad.Town != null ? ad.Town.Name : "None",
                        ad.AspNetUser.UserName);
                }

                Console.WriteLine();
            }
        }

        public static void UsingToList()
        {
            using (var db = new AdsEntities())
            {
                var wrongWay = db.Ads
                    .ToList()
                    .Where(ad => ad.AdStatus.Status == "Published")
                    .Select(ad => new { ad.Title, ad.Date, ad.Category, ad.Town })
                    .ToList()
                    .OrderBy(ad => ad.Date)
                    .ToList();

                var rightWay = db.Ads
                    .Where(ad => ad.AdStatus.Status == "Published")
                    .Select(ad => new { ad.Title, ad.Date, ad.Category, ad.Town })
                    .OrderBy(ad => ad.Date)
                    .ToList();
            }
        }

        public static void SelectPerformance()
        {
            using (var db = new AdsEntities())
            {
                foreach (var ad in db.Ads)
                {
                    Console.WriteLine(ad.Title);
                }

                Console.WriteLine();
                foreach (var title in db.Ads.Select(ad => ad.Title))
                {
                    Console.WriteLine(title);
                }
            }
        }
    }
}
