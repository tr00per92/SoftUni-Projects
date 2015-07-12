namespace Bookmarks.Web.Controllers
{
    using System.Web.Mvc;
    using Bookmarks.Data;
    using Microsoft.AspNet.Identity;

    public abstract class BaseController : Controller
    {
        protected BaseController(IBookmarksDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        protected IBookmarksDbContext DbContext { get; private set; }

        protected string CurrentUserId
        {
            get { return this.User.Identity.GetUserId(); }
        }
    }
}
