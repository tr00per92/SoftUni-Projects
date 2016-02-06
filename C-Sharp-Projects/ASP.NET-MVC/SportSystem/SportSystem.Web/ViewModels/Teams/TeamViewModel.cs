using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels.Teams
{
    public class TeamViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public DateTime? Founded { get; set; }

        public int Votes { get; set; }

        public ICollection<PlayerViewModel> Players { get; set; }

        public bool UserHasVoted { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamViewModel>()
                .ForMember(t => t.Votes, options => options.MapFrom(t => t.Votes.Count()));
        }
    }
}