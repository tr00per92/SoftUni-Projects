namespace Photography.Web.Services
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Photography.Models;
    using Photography.Web.InputModels;
    using Photography.Web.ViewModels.Albums;

    public interface IAlbumsService
    {
        IEnumerable<SelectListItem> GetPhotosSelectList();

        Album AddAlbum(AlbumInputModel model, string userId);

        AlbumViewModel GetAlbumViewModel(int id);
    }
}