namespace Events.Web.Models
{
    using System;
    using System.ComponentModel;
    using Data;
    using Infrastructure.Mapping;

    public class EventViewModel : IMapWith<Event>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public string Location { get; set; }

        [DisplayName("Username")]
        public string AuthorFullName { get; set; }

        public bool HasImage { get; set; }
    }
}
