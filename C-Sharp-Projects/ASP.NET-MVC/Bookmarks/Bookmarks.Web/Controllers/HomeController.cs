namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Bookmarks.Common;
    using Bookmarks.Data;
    using Bookmarks.Web.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(IBookmarksDbContext dbContext)
            : base(dbContext)
        {
        }

        public ActionResult Index()
        {
            var bookmarks = this.DbContext.Bookmarks
                .OrderByDescending(b => b.VotesCount)
                .Take(GlobalConstants.BookmarksPerPage)
                .Project()
                .To<BookmarkPreviewViewModel>();

            return this.View(bookmarks);
        }
    }
}
