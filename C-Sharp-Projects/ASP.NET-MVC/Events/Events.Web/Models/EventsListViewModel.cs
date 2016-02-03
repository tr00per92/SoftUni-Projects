namespace Events.Web.Models
{
    using System.Collections.Generic;

    public class EventsListViewModel
    {
        public IEnumerable<EventViewModel> UpcomingEvents { get; set; }

        public IEnumerable<EventViewModel> PassedEvents { get; set; }
    }
}