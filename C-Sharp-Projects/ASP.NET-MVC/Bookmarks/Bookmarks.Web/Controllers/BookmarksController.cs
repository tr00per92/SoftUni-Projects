using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookmarks.Common;
using Bookmarks.Data;
using Bookmarks.Models;
using Bookmarks.Web.Extensions;
using Bookmarks.Web.InputModels;
using Bookmarks.Web.ViewModels;
using PagedList;

namespace Bookmarks.Web.Controllers
{
    [Authorize]
    public class BookmarksController : BaseController
    {
        public BookmarksController(IBookmarksDbContext dbContext) 
            : base(dbContext)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var bookmarks = this.DbContext.Bookmarks
                .OrderByDescending(b => b.VotesCount)
                .Project()
                .To<BookmarkPreviewViewModel>()
                .ToPagedList(page ?? 1, GlobalConstants.BookmarksPerPage);

            return this.View(bookmarks);
        }

        public ActionResult Details(int id)
        {
            var bookmark = this.DbContext.Bookmarks
                .Where(b => b.Id == id)
                .Project()
                .To<BookmarkViewModel>()
                .FirstOrDefault();

            if (bookmark == null)
            {
                throw new HttpException(404, "There is no such bookmark.");
            }

            return this.View(bookmark);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int id)
        {
            var bookmark = this.DbContext.Bookmarks.Find(id);
            if (bookmark == null)
            {
                throw new HttpException(404, "There is no such bookmark.");
            }

            bookmark.VotesCount++;
            this.DbContext.SaveChanges();

            return this.Content(bookmark.VotesCount.ToString());
        }

        public ActionResult Create()
        {
            this.LoadCategories();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookmarkInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                this.LoadCategories();
                return this.View(model);
            }

            var bookmark = Mapper.Map<Bookmark>(model);
            bookmark.UserId = this.CurrentUserId;
            this.DbContext.Bookmarks.Add(bookmark);
            this.DbContext.SaveChanges();
            this.AddNotification("Bookmark created.", NotificationType.Success);

            return this.RedirectToAction("Details", "Bookmarks", new { id = bookmark.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                throw new HttpException(400, "Invalid comment.");
            }

            var comment = Mapper.Map<Comment>(model);
            comment.UserId = this.CurrentUserId;
            this.DbContext.Comments.Add(comment);
            this.DbContext.SaveChanges();

            var viewModel = Mapper.Map<CommentViewModel>(comment);
            viewModel.UserUserName = this.User.GetUsername();

            return this.PartialView("DisplayTemplates/CommentViewModel", viewModel);
        }

        private void LoadCategories()
        {
            var categories = this.DbContext.Categories.ToList();
            this.ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }
    }
}
