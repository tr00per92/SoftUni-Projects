namespace Twitter.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using EntityFramework.Extensions;
    using Infragistics.Web.Mvc;
    using Twitter.Data;
    using Twitter.Models;
    using Twitter.Web.Areas.Administration.ViewModels;

    public class TweetsController : AdminController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        [GridDataSourceAction]
        public ActionResult Index()
        {
            var tweets = this.Data.Tweets
                .All()
                .OrderByDescending(t => t.TweetedAt)
                .Project()
                .To<TweetAdministrationViewModel>();

            return this.View(tweets);
        }

        public JsonResult Update()
        {
            var transactions = new GridModel()
                .LoadTransactions<TweetAdministrationViewModel>(this.HttpContext.Request.Form["ig_transactions"]);

            foreach (var row in transactions.Where(t => t.type == "row").Select(t => t.row))
            {
                this.Data.Tweets
                    .All()
                    .Where(t => t.Id == row.Id)
                    .Update(t => new Tweet { Text = row.Text });
            }

            foreach (var row in transactions.Where(t => t.type == "deleterow"))
            {
                this.Data.Tweets.All().Where(t => t.Id.ToString() == row.rowId).Delete();
            }

            var result = new JsonResult { Data = new Dictionary<string, bool> { { "Success", true } } };
            return result;
        }
    }
}
