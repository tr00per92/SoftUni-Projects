using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.InputModels
{
    public class BetInputModel : IMapTo<Bet>
    {
        public int MatchId { get; set; }

        [Range(1, 1000)]
        public decimal Value { get; set; }

        public bool IsForHomeTeam { get; set; }
    }
}