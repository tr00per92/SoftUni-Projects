namespace Events.Web.Models
{
    using System.Collections.Generic;
    using Data;
    using Infrastructure.Mapping;

    public class EventDetailsViewModel : IMapWith<Event>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}