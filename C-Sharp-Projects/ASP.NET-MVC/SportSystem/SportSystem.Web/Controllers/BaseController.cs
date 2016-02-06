using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SportSystem.Data.UnitOfWork;

namespace SportSystem.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(ISportSystemData data)
        {
            this.Data = data;
        }

        protected ISportSystemData Data { get; private set; }

        protected string CurrentUserId
        {
            get { return this.User.Identity.GetUserId(); }
        }
    }
}