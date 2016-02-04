namespace Photography.Web.Services
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using PagedList;
    using Photography.Models;
    using Photography.Web.InputModels;
    using Photography.Web.ViewModels.Photos;

    public interface IPhotosService
    {
        IPagedList<PhotoPreviewViewModel> GetPhotos(int? page);

        Photograph AddPhoto(PhotoInputModel model, string userId);

        IEnumerable<SelectListItem> GetEquipmentSelectList();
    }
}