namespace Photography.Web.Services
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Photography.Models;
    using Photography.Web.InputModels;
    using Photography.Web.ViewModels;

    public interface IHomeService
    {
        HomePageViewModel GetHomePageViewModel();

        UserViewModel GetUserViewModel(string username);

        Equipment AddUserEquipment(EquipmentInputModel inputModel, string userId);

        IEnumerable<SelectListItem> GetCamerasSelectList();

        IEnumerable<SelectListItem> GetLensesSelectList();

        EquipmentViewModel GetEquipmentViewModel(int id);
    }
}