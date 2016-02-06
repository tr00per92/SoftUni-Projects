using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels.Matches
{
    public class MatchViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public decimal HomeTeamBets { get; set; }

        public decimal AwayTeamBets { get; set; }

        public DateTime Start { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchViewModel>()
                .ForMember(m => m.HomeTeamBets, options => options.MapFrom(
                    m => m.Bets.Where(b => b.IsForHomeTeam).Select(b => b.Value).DefaultIfEmpty(0).Sum()))
                .ForMember(m => m.AwayTeamBets, options => options.MapFrom(
                    m => m.Bets.Where(b => !b.IsForHomeTeam).Select(b => b.Value).DefaultIfEmpty(0).Sum()));
        }
    }
}
