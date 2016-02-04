namespace Photography.Web.Controllers
{
    using System.Web.Mvc;
    using Photography.Web.Extensions;
    using Photography.Web.InputModels;
    using Photography.Web.Services;

    [Authorize]
    public class PhotosController : BaseController
    {
        public PhotosController(IPhotosService service)
        {
            this.Service = service;
        }

        private IPhotosService Service { get; set; }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var photos = this.Service.GetPhotos(page);
            return this.View(photos);
        }

        public ActionResult Add()
        {
            this.LoadEquipment();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PhotoInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                this.LoadEquipment();
                return this.View(model);
            }

            this.Service.AddPhoto(model, this.CurrentUserId);
            this.AddNotification("Photograph added.", NotificationType.Success);

            return this.RedirectToAction("Index");
        }

        private void LoadEquipment()
        {
            var equipment = this.Service.GetEquipmentSelectList();
            this.ViewBag.Equipment = equipment;
        }
    }
}