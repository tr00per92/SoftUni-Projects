namespace Photography.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Photography.Common;
    using Photography.Data.UnitOfWork;
    using Photography.Models;
    using Photography.Web.InputModels;
    using Photography.Web.ViewModels;
    using Photography.Web.ViewModels.Albums;
    using Photography.Web.ViewModels.Photos;

    public class HomeService : ServiceBase, IHomeService
    {
        public HomeService(IPhotographyData data)
            : base(data)
        {
        }

        public HomePageViewModel GetHomePageViewModel()
        {
            var photos = this.Data.Photographs
                .All()
                .OrderByDescending(p => p.UploadDate)
                .Take(GlobalConstants.HomePagePhotos)
                .Project()
                .To<PhotoPreviewViewModel>();

            var albums = this.Data.Albums
                .All()
                .OrderByDescending(a => a.Id)
                .Take(GlobalConstants.HomePageAlbums)
                .Project()
                .To<AlbumPreviewViewModel>();

            var homePageModel = new HomePageViewModel
            {
                LatestAlbums = albums.ToList(),
                LatestPhotos = photos.ToList()
            };

            return homePageModel;
        }

        public UserViewModel GetUserViewModel(string username)
        {
            var user = this.Data.Users
                .All()
                .Where(u => u.UserName == username)
                .Project()
                .To<UserViewModel>()
                .FirstOrDefault();

            return user;
        }

        public Equipment AddUserEquipment(EquipmentInputModel inputModel, string userId)
        {
            var equipment = this.Data.Equipment
                .All()
                .FirstOrDefault(e => 
                    e.CameraId == inputModel.CameraId && 
                    e.LenseId == inputModel.LenseId);

            if (equipment == null)
            {
                equipment = Mapper.Map<Equipment>(inputModel);
                this.Data.Equipment.Add(equipment);
                this.Data.SaveChanges();
            }

            var user = this.Data.Users.Find(userId);
            user.EquipmentId = equipment.Id;
            this.Data.Users.Update(user);
            this.Data.SaveChanges();

            return equipment;
        }

        public IEnumerable<SelectListItem> GetCamerasSelectList()
        {
            var cameras = this.Data.Cameras
               .All()
               .Select(c => new SelectListItem
               {
                   Text = c.Model,
                   Value = c.Id.ToString()
               })
               .ToList();

            return cameras;
        }

        public IEnumerable<SelectListItem> GetLensesSelectList()
        {
            var lenses = this.Data.Lenses
               .All()
               .Select(l => new SelectListItem
               {
                   Text = l.Model,
                   Value = l.Id.ToString()
               })
               .ToList();

            return lenses;
        }

        public EquipmentViewModel GetEquipmentViewModel(int id)
        {
            var equipment = this.Data.Equipment
                .All()
                .Where(e => e.Id == id)
                .Project()
                .To<EquipmentViewModel>()
                .FirstOrDefault();

            return equipment;
        }
    }
}