using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookmarks.Data;
using Bookmarks.Models;
using Bookmarks.Web.Areas.Admin.ViewModels;
using EntityFramework.Extensions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Bookmarks.Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdminController
    {
        public CategoriesController(IBookmarksDbContext dbContext)
            : base(dbContext)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var categories = this.DbContext.Categories
                .Project()
                .To<CategoryAdminViewModel>();

            return this.Json(categories.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                this.DbContext.Categories.Add(category);
                this.DbContext.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.DbContext.Categories
                    .Where(c => c.Id == model.Id)
                    .Update(c => new Category { Name = model.Name });
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (this.DbContext.Bookmarks.Any(b => b.CategoryId == model.Id))
            {
                this.ModelState.AddModelError("Category", "There are existing bookmarks in this category.");
            }

            if (model != null && this.ModelState.IsValid)
            {
                this.DbContext.Categories.Where(c => c.Id == model.Id).Delete();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
