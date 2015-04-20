namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BugTracker.Data.Models;
    using BugTracker.Data.UnitOfWork;
    using BugTracker.RestServices.Models;
    using Microsoft.AspNet.Identity;

    public class CommentsController : BaseController
    {
        public CommentsController() :
            base(new BugTrackerData())
        {
        }

        public CommentsController(IBugTrackerData data) :
            base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var comments = this.Data.Comments.All()
                .OrderByDescending(c => c.DateCreated)
                .ThenByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.Text,
                    Author = c.Author != null ? c.Author.UserName : null,
                    c.DateCreated,
                    c.BugId,
                    BugTitle = c.Bug.Title
                })
                .ToList();

            return this.Ok(comments);
        }

        [HttpGet]
        [Route("api/bugs/{id}/comments")]
        public IHttpActionResult GetBugComments(int id)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = bug.Comments
                .OrderByDescending(c => c.DateCreated)
                .Select(CommentOutputModel.FromComment)
                .ToList();

            return this.Ok(comments);
        }

        [HttpPost]
        [Route("api/bugs/{id}/comments")]
        public IHttpActionResult AddComment(int id, CommentInputModel model)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest("The comment text is required.");
            }

            var newComment = new Comment
            {
                Text = model.Text,
                DateCreated = DateTime.Now,
                BugId = bug.Id,
                UserId = this.User.Identity.GetUserId()
            };

            this.Data.Comments.Add(newComment);
            this.Data.SaveChanges();

            object infoToReturn = new { newComment.Id, Message = "Added anonymous comment for bug #" + bug.Id };
            if (newComment.UserId != null)
            {
                infoToReturn = new
                {
                    newComment.Id,
                    Author = this.User.Identity.GetUserName(),  
                    Message = "User comment added for bug #" + bug.Id
                };
            }

            return this.Ok(infoToReturn);
        }
    }
}