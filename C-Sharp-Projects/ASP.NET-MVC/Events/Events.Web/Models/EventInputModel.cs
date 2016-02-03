namespace Events.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using AutoMapper;
    using Data;
    using Infrastructure;
    using Infrastructure.Mapping;

    public class EventInputModel : IMapWith<Event>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "The event title is required.")]
        [StringLength(200, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Title *")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Date and Time *")]
        public string StartTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public string Description { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Private event?")]
        public bool IsPrivate { get; set; }

        [ValidateImage(
            ErrorMessage = "The file must be an image under 100KB with width and height between 100 and 400 pixels.")]
        public HttpPostedFileBase Image { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<EventInputModel, Event>()
                .ForMember(e => e.StartTime, options => options.MapFrom(e => DateTime.Parse(e.StartTime)))
                .ForMember(e => e.StartTime, options => options.MapFrom(e => e.StartTime.ToString()));
        }
    }
}