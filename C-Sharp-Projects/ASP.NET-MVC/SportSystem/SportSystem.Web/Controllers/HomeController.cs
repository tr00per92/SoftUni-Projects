using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SportSystem.Data.UnitOfWork;
using SportSystem.Web.ViewModels;
using SportSystem.Web.ViewModels.Matches;
using SportSystem.Web.ViewModels.Teams;

namespace SportSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var topMatches = this.Data.Matches
                .All()
                .OrderByDescending(m => m.Bets.Count())
                .Take(3)
                .Project()
                .To<MatchPreviewViewModel>();

            var bestTeams = this.Data.Teams
                .All()
                .OrderByDescending(t => t.Votes.Count())
                .Take(3)
                .Project()
                .To<TeamPreviewViewModel>();

            var homePageViewModel = new HomePageViewModel
            {
                TopMatches = topMatches.ToList(),
                BestTeams = bestTeams.ToList()
            };

            return this.View(homePageViewModel);
        }
    }
}