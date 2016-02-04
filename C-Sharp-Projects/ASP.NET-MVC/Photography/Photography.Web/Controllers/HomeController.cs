namespace Photography.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Photography.Web.InputModels;
    using Photography.Web.Services;

    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IHomeService service)
        {
            this.Service = service;
        }

        private IHomeService Service { get; set; } 

        [AllowAnonymous]
        public ActionResult Index()
        {
            var homePageModel = this.Service.GetHomePageViewModel();
            return this.View(homePageModel);
        }

        [ActionName("Profile")]
        public ActionResult UserProfile(string username)
        {
            if (username == null)
            {
                username = this.User.Identity.GetUserName();
            }

            var user = this.Service.GetUserViewModel(username);
            if (user == null)
            {
                throw new HttpException(404, "There is no such user.");
            }

            if (user.Equipment == null && username == this.User.Identity.GetUserName())
            {
                this.LoadEquipment();
            }

            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEquipment(EquipmentInputModel model)
        {
            var equipment = this.Service.AddUserEquipment(model, this.CurrentUserId);
            var viewModel = this.Service.GetEquipmentViewModel(equipment.Id);

            return this.PartialView("DisplayTemplates/EquipmentViewModel", viewModel);
        }

        private void LoadEquipment()
        {
            var cameras = this.Service.GetCamerasSelectList();
            var lenses = this.Service.GetLensesSelectList();
            this.ViewBag.Cameras = cameras;
            this.ViewBag.Lenses = lenses;
        }
    }
}