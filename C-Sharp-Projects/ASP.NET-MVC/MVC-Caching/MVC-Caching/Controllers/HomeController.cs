namespace MVC_Caching.Controllers
{
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using System.Web.UI;
    using System.Xml.Linq;
    using MVC_Caching.Models;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [OutputCache(Location = OutputCacheLocation.Client, Duration = 15)]
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users()
        {
            if (this.HttpContext.Cache["users"] == null)
            {
                var users = this.db.Users.Select(u => u.UserName).ToList();
                this.HttpContext.Cache.Insert(
                    "users", users, new SqlCacheDependency("MVC-Caching", "AspNetUsers"));
            }

            return this.View(this.HttpContext.Cache["users"]);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 5 * 60)]
        public ActionResult RssFeed()
        {
            var rssItems = XDocument.Load("https://softuni.bg/feed/news")
                .Descendants("item")
                .Select(i => new RssItemViewModel
                {
                    Title = i.Descendants("title").First().Value,
                    Link = i.Descendants("link").First().Value
                });

            return this.PartialView("_RssItems", rssItems);
        }
    }
}
