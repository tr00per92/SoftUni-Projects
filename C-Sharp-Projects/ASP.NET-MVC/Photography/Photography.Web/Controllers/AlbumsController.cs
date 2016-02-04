namespace Photography.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Photography.Web.Extensions;
    using Photography.Web.InputModels;
    using Photography.Web.Services;

    [Authorize]
    public class AlbumsController : BaseController
    {
        public AlbumsController(IAlbumsService service)
        {
            this.Service = service;
        }

        private IAlbumsService Service { get; set; } 

        public ActionResult Details(int id)
        {
            var album = this.Service.GetAlbumViewModel(id);

            if (album == null)
            {
                throw new HttpException(404, "There is no such album.");
            }

            return this.View(album);
        }

        public ActionResult Add()
        {
            this.LoadPhotos();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AlbumInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                this.LoadPhotos();
                return this.View();
            }

            var album = this.Service.AddAlbum(model, this.CurrentUserId);
            this.AddNotification("Album created.", NotificationType.Success);

            return this.RedirectToAction("Details", "Albums", new { id = album.Id });
        }

        private void LoadPhotos()
        {
            var photos = this.Service.GetPhotosSelectList();
            this.ViewBag.Photos = photos;
        }
    }
}