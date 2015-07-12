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

    public class NotificationsController : AdminController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        [GridDataSourceAction]
        public ActionResult Index()
        {
            var notifications = this.Data.Notifications
                .All()
                .OrderByDescending(t => t.NotificationTime)
                .Project()
                .To<NotificationAdministrationViewModel>();

            return this.View(notifications);
        }

        public JsonResult Update()
        {
            var transactions = new GridModel()
                .LoadTransactions<NotificationAdministrationViewModel>(this.HttpContext.Request.Form["ig_transactions"]);

            foreach (var row in transactions.Where(t => t.type == "row").Select(t => t.row))
            {
                this.Data.Notifications
                    .All()
                    .Where(n => n.Id == row.Id)
                    .Update(t => new Notification { Text = row.Text, IsRead = row.IsRead });
            }

            foreach (var row in transactions.Where(t => t.type == "deleterow"))
            {
                this.Data.Notifications.All().Where(n => n.Id.ToString() == row.rowId).Delete();
            }

            var result = new JsonResult { Data = new Dictionary<string, bool> { { "Success", true } } };
            return result;
        }
    }
}
