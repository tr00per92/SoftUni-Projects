namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BugTracker.Data.Models;
    using BugTracker.Data.UnitOfWork;
    using BugTracker.RestServices.Models;
    using Microsoft.AspNet.Identity;

    public class BugsController : BaseController
    {
        public BugsController() :
            base(new BugTrackerData())
        {
        }

        public BugsController(IBugTrackerData data) :
            base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var bugs = this.Data.Bugs.All()
                .OrderByDescending(bug => bug.DateCreated)
                .ThenByDescending(bug => bug.Id)
                .Select(BugOutputModel.FromBug)
                .ToList();

            return this.Ok(bugs);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var infoToReturn = new
            {
                bug.Id,
                bug.Title,
                bug.Description,
                Status = bug.Status.ToString(),
                Author = bug.Author != null ? bug.Author.UserName : null,
                bug.DateCreated,
                Comments = bug.Comments
                    .OrderByDescending(c => c.DateCreated)
                    .ThenByDescending(c => c.Id)
                    .Select(CommentOutputModel.FromComment)
            };

            return this.Ok(infoToReturn);
        }

        [HttpPost]
        public IHttpActionResult SubmitBug(SubmitBugInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest("You must submit bug title.");
            }

            var newBug = new Bug
            {
                Title = model.Title,
                Description = model.Description,
                DateCreated = DateTime.Now,
                Status = BugStatus.Open,
                UserId = this.User.Identity.GetUserId()
            };

            this.Data.Bugs.Add(newBug);
            this.Data.SaveChanges();

            object infoToReturn = new { newBug.Id, Message = "Anonymous bug submitted." };
            if (newBug.UserId != null)
            {
                infoToReturn = new
                {
                    newBug.Id, 
                    Author = this.User.Identity.GetUserName(), 
                    Message = "User bug submitted."
                };
            }

            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "bugs", id = newBug.Id },
                infoToReturn);
        }

        [HttpPatch]
        public IHttpActionResult EditBug(int id, EditBugInputModel model)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest("You must provide new bug data in order to change a bug.");
            }

            if (model.Title != null)
            {
                if (model.Title == string.Empty)
                {
                    return this.BadRequest("The bug title cannot be empty.");
                }

                bug.Title = model.Title;
            }

            if (model.Description != null)
            {
                bug.Description = model.Description;
            }

            if (model.Status != null)
            {
                BugStatus status;
                if (!Enum.TryParse(model.Status, true, out status))
                {
                    return this.BadRequest("The provided status is invalid.");
                }

                bug.Status = status;
            }

            this.Data.Bugs.Update(bug);
            this.Data.SaveChanges();

            return this.Ok(new { Message = "Bug #" + bug.Id + " patched." });
        }

        [HttpDelete]
        public IHttpActionResult DeleteBug(int id)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            this.Data.Bugs.Remove(bug);
            this.Data.SaveChanges();

            return this.Ok(new { Message = "Bug #" + bug.Id + " deleted." });
        }

        [HttpGet]
        [Route("api/bugs/filter")]
        public IHttpActionResult ListByFilter([FromUri]FilterInputModel filter)
        {
            if (filter == null)
            {
                return this.GetAll();
            }

            var bugsQuery = this.Data.Bugs.All();

            if (filter.Keyword != null)
            {
                bugsQuery = bugsQuery.Where(bug => bug.Title.Contains(filter.Keyword));
            }

            if (filter.Author != null)
            {
                bugsQuery = bugsQuery.Where(bug => bug.Author.UserName == filter.Author);
            }

            if (filter.Statuses != null)
            {
                var statuses = filter.Statuses.Split('|');
                bugsQuery = bugsQuery.Where(bug => statuses.Contains(bug.Status.ToString()));
            }

            var bugs = bugsQuery
                .OrderByDescending(bug => bug.DateCreated)
                .ThenByDescending(bug => bug.Id)
                .Select(BugOutputModel.FromBug)
                .ToList();

            return this.Ok(bugs);
        }
    }
}