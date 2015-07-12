namespace Twitter.Web.Areas.Administration.ViewModels
{
    using System;
    using AutoMapper;
    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;
    
    public class TweetAdministrationViewModel : IMapFrom<Tweet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime TweetedAt { get; set; }

        public string Username { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tweet, TweetAdministrationViewModel>()
                .ForMember(t => t.Username, options => options.MapFrom(t => t.Owner.UserName));
        }
    }
}
