namespace MusicCatalog.Services.Controllers
{
    using System.Web.Http;
    using MusicCatalog.Data;

    public abstract class BaseController : ApiController
    {
        protected MusicCatalogDbContext db;

        protected BaseController()
        {
            this.db = new MusicCatalogDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}