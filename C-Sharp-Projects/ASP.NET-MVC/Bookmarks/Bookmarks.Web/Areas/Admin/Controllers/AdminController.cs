namespace Bookmarks.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Bookmarks.Common;
    using Bookmarks.Data;
    using Bookmarks.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        protected AdminController(IBookmarksDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
