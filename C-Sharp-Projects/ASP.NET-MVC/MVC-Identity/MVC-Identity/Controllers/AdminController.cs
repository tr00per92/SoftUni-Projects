namespace MVC_Identity_Homework.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles="Administrator")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
