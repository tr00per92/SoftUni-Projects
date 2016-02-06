using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SportSystem.Data.UnitOfWork;
using SportSystem.Models;
using SportSystem.Web.Extensions;
using SportSystem.Web.InputModels;
using SportSystem.Web.ViewModels.Teams;

namespace SportSystem.Web.Controllers
{
    [Authorize]
    public class TeamsController : BaseController
    {
        public TeamsController(ISportSystemData data) 
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var team = this.Data.Teams.Find(id);
            if (team == null)
            {
                throw new HttpException(404, "There is no such team.");
            }

            var teamModel = Mapper.Map<TeamViewModel>(team);
            teamModel.UserHasVoted = team.Votes.Any(v => v.UserId == this.CurrentUserId);

            return this.View(teamModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int id)
        {
            var team = this.Data.Teams.Find(id);
            if (team == null)
            {
                throw new HttpException(404, "There is no such team.");
            }

            var vote = new Vote
            {
                TeamId = id,
                UserId = this.CurrentUserId
            };

            this.Data.Votes.Add(vote);
            this.Data.SaveChanges();

            return this.Content(team.Votes.Count().ToString());
        }

        public ActionResult Create()
        {
            this.LoadFreePlayers();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                this.LoadFreePlayers();
                return this.View(model);
            }

            var team = Mapper.Map<Team>(model);
            this.Data.Teams.Add(team);
            this.Data.SaveChanges();
            foreach (var id in model.PlayerIds.Distinct())
            {
                var player = this.Data.Players.Find(id);
                if (player != null)
                {
                    player.TeamId = team.Id;
                }
            }
            
            this.Data.SaveChanges();
            this.AddNotification("Team created successfully.", NotificationType.Success);

            return this.RedirectToAction("Details", "Teams", new { id = team.Id });
        }

        private void LoadFreePlayers()
        {
            var players = this.Data.Players
                .All()
                .Where(p => p.TeamId == null)
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                })
                .ToList();

            this.ViewBag.Players = players;
        }
    }
}
