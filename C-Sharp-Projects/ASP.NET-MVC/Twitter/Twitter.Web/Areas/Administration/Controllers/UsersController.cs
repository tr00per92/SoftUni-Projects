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

    public class UsersController : AdminController
    {
        public UsersController(ITwitterData data) 
            : base(data)
        {
        }

        [GridDataSourceAction]
        public ActionResult Index()
        {
            var users = this.Data.Users
                .All()
                .OrderBy(u => u.UserName)
                .Project()
                .To<UserAdministrationViewModel>();

            return this.View(users);
        }

        public JsonResult Update()
        {
            var editedRows = new GridModel()
                .LoadTransactions<UserAdministrationViewModel>(this.HttpContext.Request.Form["ig_transactions"])
                .Where(t => t.type == "row")
                .Select(t => t.row);

            foreach (var row in editedRows)
            {
                this.Data.Users
                    .All()
                    .Where(u => u.Id == row.Id)
                    .Update(u => new User { UserName = row.UserName, Email = row.Email });
            }

            var result = new JsonResult { Data = new Dictionary<string, bool> { { "Success", true } } };
            return result;
        }
    }
}
