namespace Twitter.Web.ViewModels.Reports
{
    using System;
    using AutoMapper;
    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class ReportViewModel : IMapFrom<Report>, IHaveCustomMappings
    {
        public string Text { get; set; }

        public DateTime ReportedAt { get; set; }

        public int TweetId { get; set; }

        public string Username { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Report, ReportViewModel>()
                .ForMember(t => t.Username, options => options.MapFrom(t => t.User.UserName));
        }
    }
}
