namespace MVC_Identity_Homework.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
