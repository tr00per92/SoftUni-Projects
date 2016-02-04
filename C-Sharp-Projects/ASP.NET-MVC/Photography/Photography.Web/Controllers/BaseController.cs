namespace Photography.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    public abstract class BaseController : Controller
    {
        protected string CurrentUserId
        {
            get { return this.User.Identity.GetUserId(); }
        }
    }
}