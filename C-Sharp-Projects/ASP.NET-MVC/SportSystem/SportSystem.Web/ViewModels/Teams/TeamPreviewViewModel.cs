using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels.Teams
{
    public class TeamPreviewViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamPreviewViewModel>()
                .ForMember(t => t.Votes, options => options.MapFrom(t => t.Votes.Count()));
        }
    }
}