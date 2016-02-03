namespace Events.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Infrastructure;
    using Microsoft.AspNet.Identity;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new EventsDbContext();
        }

        protected EventsDbContext Db { get; private set; }

        protected string CurrentUserId
        {
            get { return this.User.Identity.GetUserId(); }
        }

        protected bool IsAdmin
        {
            get { return this.User.IsAdmin(); }
        }

        protected string GetImagePath(int id)
        {
            return Directory.GetFiles(this.Server.MapPath("~/Images"), string.Format("event-{0}.*", id)).FirstOrDefault();
        }
    }
}