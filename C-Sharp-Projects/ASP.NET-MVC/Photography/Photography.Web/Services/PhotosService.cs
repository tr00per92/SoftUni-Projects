namespace Photography.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PagedList;

    using Photography.Common;
    using Photography.Data.UnitOfWork;
    using Photography.Models;
    using Photography.Web.InputModels;
    using Photography.Web.ViewModels.Photos;

    public class PhotosService : ServiceBase, IPhotosService
    {
        public PhotosService(IPhotographyData data)
            : base(data)
        {
        }

        public IPagedList<PhotoPreviewViewModel> GetPhotos(int? page)
        {
            var photos = this.Data.Photographs
                .All()
                .OrderByDescending(p => p.UploadDate)
                .Project()
                .To<PhotoPreviewViewModel>()
                .ToPagedList(page ?? 1, GlobalConstants.PhotosPerPage);

            return photos;
        }

        public Photograph AddPhoto(PhotoInputModel model, string userId)
        {
            var photo = Mapper.Map<Photograph>(model);
            photo.UserId = userId;
            this.Data.Photographs.Add(photo);
            this.Data.SaveChanges();

            return photo;
        }

        public IEnumerable<SelectListItem> GetEquipmentSelectList()
        {
            var equipment = this.Data.Equipment
                .All()
                .Select(e => new SelectListItem
                {
                    Text = e.Camera.Model + " + " + e.Lense.Model,
                    Value = e.Id.ToString()
                })
                .ToList();

            return equipment;
        }
    }
}