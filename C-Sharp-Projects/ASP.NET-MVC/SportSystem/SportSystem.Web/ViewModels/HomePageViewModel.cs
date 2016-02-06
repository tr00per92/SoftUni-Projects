using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportSystem.Web.ViewModels.Matches;
using SportSystem.Web.ViewModels.Teams;

namespace SportSystem.Web.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<MatchPreviewViewModel> TopMatches { get; set; }

        public IEnumerable<TeamPreviewViewModel> BestTeams { get; set; }
    }
}