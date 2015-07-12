namespace Twitter.Web.Areas.Administration.ViewModels
{
    using System;
    using AutoMapper;
    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class NotificationAdministrationViewModel : IMapFrom<Notification>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public bool IsRead { get; set; }

        public DateTime NotificationTime { get; set; }

        public string Username { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Notification, NotificationAdministrationViewModel>()
                .ForMember(t => t.Username, options => options.MapFrom(t => t.User.UserName));
            configuration.CreateMap<Notification, NotificationAdministrationViewModel>()
                .ForMember(t => t.Type, options => options.MapFrom(t => t.Type.ToString()));
        }
    }
}
