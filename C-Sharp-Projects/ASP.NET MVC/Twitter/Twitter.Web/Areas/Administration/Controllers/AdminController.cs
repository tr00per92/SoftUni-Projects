namespace Twitter.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Twitter.Common;
    using Twitter.Data;
    using Twitter.Web.Controllers;

    [Authorize(Roles = Constants.AdminRoleName)]
    public abstract class AdminController : BaseController
    {
        protected AdminController(ITwitterData data) 
            : base(data)
        {
        }
    }
}
