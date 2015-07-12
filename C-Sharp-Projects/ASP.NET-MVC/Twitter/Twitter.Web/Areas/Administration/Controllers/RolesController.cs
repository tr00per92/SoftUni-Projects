namespace Twitter.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using EntityFramework.Extensions;
    using Infragistics.Web.Mvc;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Common;
    using Twitter.Data;
    using Twitter.Web.Areas.Administration.ViewModels;

    public class RolesController : AdminController
    {
        public RolesController(ITwitterData data) 
            : base(data)
        {
        }

        [GridDataSourceAction]
        public ActionResult Index()
        {
            var roles = this.Data.Roles
                .All()
                .Where(r => r.Name != Constants.AdminRoleName)
                .OrderBy(r => r.Name)
                .Project()
                .To<RoleAdministrationViewModel>();

            return this.View(roles);
        }

        public JsonResult Update()
        {
            var transactions = new GridModel()
                .LoadTransactions<RoleAdministrationViewModel>(this.HttpContext.Request.Form["ig_transactions"]);

            foreach (var row in transactions.Where(t => t.type == "row").Select(t => t.row))
            {
                this.Data.Roles
                    .All()
                    .Where(r => r.Id == row.Id)
                    .Update(t => new IdentityRole { Name = row.Name });
            }

            foreach (var row in transactions.Where(t => t.type == "deleterow"))
            {
                var role = this.Data.Roles.Find(row.rowId);
                role.Users.Clear();
                this.Data.Roles.Remove(role);
            }

            foreach (var row in transactions.Where(t => t.type == "newrow").Select(t => t.row))
            {
                var newRole = new IdentityRole(row.Name);
                this.Data.Roles.Add(newRole);
            }

            this.Data.SaveChanges();
            var result = new JsonResult { Data = new Dictionary<string, bool> { { "Success", true } } };
            return result;
        }
    }
}
