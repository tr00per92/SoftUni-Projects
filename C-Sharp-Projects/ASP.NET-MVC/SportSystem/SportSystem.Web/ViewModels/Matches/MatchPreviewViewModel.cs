using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels.Matches
{
    public class MatchPreviewViewModel : IMapFrom<Match>
    {
        public int Id { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime Start { get; set; }
    }
}