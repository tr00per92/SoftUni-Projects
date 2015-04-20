namespace BugTracker.RestServices.Controllers
{
    using System.Web.Http;
    using BugTracker.Data.UnitOfWork;

    public class BaseController : ApiController
    {
        public BaseController(IBugTrackerData data)
        {
            this.Data = data;
        }

        protected IBugTrackerData Data { get; private set; }
    }
}