namespace Events.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var events = this.Db.Events
                .Where(e => !e.IsPrivate)
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

            this.ViewBag.Title = "Public Events";
            return this.View("Events", eventsListModel);
        }
    }
}