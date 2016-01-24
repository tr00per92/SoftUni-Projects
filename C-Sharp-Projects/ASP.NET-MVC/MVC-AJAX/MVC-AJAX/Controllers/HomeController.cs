namespace MVC_AJAX.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using MVC_AJAX.Data;

    public class HomeController : Controller
    {
        private readonly TownsData townsData = new TownsData();
        private readonly PeopleData peopleData = new PeopleData();

        public ActionResult Index()
        {
            var names = this.peopleData.All().Select(p => p.Name);

            return this.View(names);
        }

        public JsonResult GetPersonData(string name)
        {
            var data = this.peopleData.All().FirstOrDefault(p => p.Name == name);

            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutoCompleteTown(string input)
        {
            var towns = this.townsData.All()
                .Where(t => t.Name.ToLower().Contains(input.ToLower()));

            return this.Json(towns, JsonRequestBehavior.AllowGet);
        }
    }
}
