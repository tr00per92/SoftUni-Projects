namespace BlogSystem.Services.Controllers
{
    using System.Web.Http;
    using BlogSystem.Data;

    public abstract class BaseController : ApiController
    {
        protected BlogSystemData data;

        protected BaseController()
        {
            this.data = new BlogSystemData(new BlogSystemDbContext());
        }
    }
}