namespace Events.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Extensions;
    using Microsoft.AspNet.Identity;
    using Models;

    [Authorize]
    public class EventsController : BaseController
    {
        public ActionResult My()
        {
            var events = this.Db.Events
                .Where(e => e.AuthorId == this.CurrentUserId)
                .OrderByDescending(e => e.StartTime)
                .Project()
                .To<EventViewModel>()
                .ToList();

            events.ForEach(e => e.HasImage = this.GetImagePath(e.Id) != null);
            var eventsListModel = new EventsListViewModel
            {
                PassedEvents = events.Where(e => e.StartTime <= DateTime.Now),
                UpcomingEvents = events.Where(e => e.StartTime > DateTime.Now)
            };

            this.ViewBag.Title = "My Events";
            return this.View("Events", eventsListModel);
        }

        [AllowAnonymous]
        public ActionResult GetDetails(int id)
        {
            var eventDetails = this.Db.Events
                .Where(e => e.Id == id)
                .Where(e => !e.IsPrivate || this.IsAdmin || (e.AuthorId != null && e.AuthorId == this.CurrentUserId))
                .Project()
                .To<EventDetailsViewModel>()
                .FirstOrDefault();

            var isOwner = eventDetails != null &&
                          eventDetails.AuthorId != null &&
                          eventDetails.AuthorId == this.CurrentUserId;

            this.ViewBag.CanEdit = isOwner || this.IsAdmin;

            return this.PartialView("_EventDetails", eventDetails);
        }

        public ActionResult Create()
        {
            this.ViewBag.Title = "Create Event";
            return this.View("EventForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventInputModel inputModel)
        {
            if (inputModel == null || !this.ModelState.IsValid)
            {
                this.ViewBag.Title = "Create Event";
                return this.View("EventForm", inputModel);
            }

            var model = Mapper.Map<Event>(inputModel);
            model.AuthorId = this.User.Identity.GetUserId();
            this.Db.Events.Add(model);
            this.Db.SaveChanges();

            if (inputModel.Image != null && inputModel.Image.ContentLength > 0)
            {
                var name = string.Format("event-{0}{1}", model.Id, Path.GetExtension(inputModel.Image.FileName));
                inputModel.Image.SaveAs(Path.Combine(this.Server.MapPath("~/Images"), name));
            }

            this.AddNotification("Event created.", NotificationType.Success);

            return this.RedirectToAction("My");
        }

        public ActionResult Edit(int id)
        {
            var inputModel = this.Db.Events
                .Where(e => e.Id == id && (this.IsAdmin || e.AuthorId == this.CurrentUserId))
                .Project()
                .To<EventInputModel>()
                .FirstOrDefault();

            if (inputModel == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.Error);
                return this.RedirectToAction("My");
            }

            inputModel.StartTime = DateTime.Parse(inputModel.StartTime).ToString("dd-MMM-yyyy HH:mm");
            this.ViewBag.Title = "Edit Event #" + id;

            return this.View("EventForm", inputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventInputModel inputModel)
        {
            if (inputModel == null || !this.ModelState.IsValid)
            {
                this.ViewBag.Title = "Edit Event #" + id;
                return this.View("EventForm", inputModel);
            }

            var model = this.Db.Events.FirstOrDefault(e => e.Id == id && e.AuthorId == this.CurrentUserId);
            if (model == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.Error);
                return this.RedirectToAction("My");
            }

            model.Description = inputModel.Description;
            model.Duration = inputModel.Duration;
            model.IsPrivate = inputModel.IsPrivate;
            model.Location = inputModel.Location;
            model.StartTime = DateTime.Parse(inputModel.StartTime);
            model.Title = inputModel.Title;

            this.Db.SaveChanges();
            this.AddNotification("Event edited.", NotificationType.Success);

            return this.RedirectToAction("My");
        }

        public ActionResult Delete(int id)
        {
            var model = this.Db.Events
                .Where(e => e.Id == id && (this.IsAdmin || e.AuthorId == this.CurrentUserId))
                .Project()
                .To<EventViewModel>()
                .FirstOrDefault();

            if (model == null)
            {
                this.AddNotification("Cannot delete event #" + id, NotificationType.Error);
                return this.RedirectToAction("My");
            }

            return this.View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var model = this.Db.Events
                .FirstOrDefault(e => e.Id == id && (this.IsAdmin || e.AuthorId == this.CurrentUserId));

            if (model == null)
            {
                this.AddNotification("Cannot delete event #" + id, NotificationType.Error);
            }
            else
            {
                this.Db.Events.Remove(model);
                this.Db.SaveChanges();
                this.AddNotification("Event deleted.", NotificationType.Info);
            }

            return this.RedirectToAction("My");
        }

        public ActionResult Image(int id)
        {
            var imagePath = this.GetImagePath(id);
            if (imagePath == null)
            {
                return null;
            }

            var image = System.IO.File.ReadAllBytes(imagePath);

            return this.File(image, "image/jpeg");
        }
    }
}