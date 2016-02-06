using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using PagedList;
using SportSystem.Common;
using SportSystem.Data.UnitOfWork;
using SportSystem.Models;
using SportSystem.Web.InputModels;
using SportSystem.Web.ViewModels;
using SportSystem.Web.ViewModels.Matches;

namespace SportSystem.Web.Controllers
{
    [Authorize]
    public class MatchesController : BaseController
    {
        public MatchesController(ISportSystemData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var matches = this.Data.Matches
                .All()
                .OrderBy(m => m.Start)
                .Project()
                .To<MatchPreviewViewModel>()
                .ToPagedList(page ?? 1, GlobalConstants.MatchesPerPage);

            return this.View(matches);
        }

        public ActionResult Details(int id)
        {
            var match = this.Data.Matches
                .All()
                .Where(m => m.Id == id)
                .Project()
                .To<MatchViewModel>()
                .FirstOrDefault();

            if (match == null)
            {
                throw new HttpException(404, "There is no such match.");
            }

            return this.View(match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                throw new HttpException(400, "Invalid Comment.");
            }

            var comment = Mapper.Map<Comment>(model);
            comment.DateTime = DateTime.Now;
            comment.AuthorId = this.CurrentUserId;
            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            var viewModel = Mapper.Map<CommentViewModel>(comment);
            viewModel.AuthorEmail = this.User.Identity.GetUserName();

            return this.PartialView("DisplayTemplates/CommentViewModel", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBet(BetInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                throw new HttpException(400, "Invalid bet.");
            }

            var bet = Mapper.Map<Bet>(model);
            bet.UserId = this.CurrentUserId;
            this.Data.Bets.Add(bet);
            this.Data.SaveChanges();

            var totalBets = this.Data.Bets
                .All()
                .Where(b => b.MatchId == bet.MatchId && b.IsForHomeTeam == bet.IsForHomeTeam)
                .Sum(b => b.Value);

            return this.Content(totalBets.ToString(CultureInfo.InvariantCulture));
        }
    }
}
