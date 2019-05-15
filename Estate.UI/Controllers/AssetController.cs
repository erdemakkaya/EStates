using Estate.Business;
using Estate.Business.Contracts;
using Estate.Core.SearchModel;
using Estate.Data.Entities;
using Estate.UI.CustomFilter;
using Estate.UI.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Estate.UI.Controllers
{
    public class AssetController : Controller
    {
        private readonly ICategoryEngine _categoryEngine;
        private readonly IPropertyEngine _propertyEngine;
        private readonly IPhotoEngine _iphotoEngine;


        public AssetController(ICategoryEngine categoryEngine, IPropertyEngine propertyEngine, IPhotoEngine photoEngine)
        {
            _categoryEngine = categoryEngine;
            _propertyEngine = propertyEngine;
            _iphotoEngine = photoEngine;
        }

        // GET: Asset
        #region Index Section
        public ActionResult Index(int page = 1)
        {
            ViewBag.CategoryList = _categoryEngine.GetAll();
            var model = _propertyEngine.GetAll().ToPagedList(page, 16);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(PropertySearchModel searchModel, int page = 1)
        {
            ViewBag.CategoryList = _categoryEngine.GetAll();
            var model = _propertyEngine.GetAll(searchModel).ToPagedList(page, 16);
            return View(model);
        }
        #endregion


        #region Add Section
        [LoginFilter, ValidateInput(false)]
        public ActionResult Add()
        {
            ViewBag.CategoryList = _categoryEngine.GetAll();
            AssetViewModel model = new AssetViewModel();
            {
                model.CategoryList = _categoryEngine.GetAll();
                return View(model);
            }



        }
        [HttpPost, LoginFilter, ValidateInput(false)]
        public ActionResult Add(AssetViewModel model, List<HttpPostedFileBase> Gallery)
        {
            int catid = model.property.Category.Id;
            var user = (User)Session["login"];
            model.property.CreatedDate = DateTime.Now;
            model.property.ModifiedDate = DateTime.Now;
            model.property.Category = _categoryEngine.GetAll().Where(x => x.Id == catid).First();
            model.property.User = user;
            _propertyEngine.Add(model.property);
            var path1 = Server.MapPath("~/Gallery/" + model.property.Id.ToString());
            Directory.CreateDirectory(path1);
            if (Gallery != null)
            {

                foreach (var file in Gallery)
                {
                    Photo photo = new Photo();

                    FileInfo info = new FileInfo(file.FileName);
                    var filename = Guid.NewGuid().ToString() + info.Extension;
                    photo.ImageUrl = filename;
                    photo.Property = model.property;
                    _iphotoEngine.Add(photo);

                    model.property.Photo.Add(photo);

                    var path = Path.Combine(path1, filename);
                    WebImage img = new WebImage(file.InputStream);
                    img.Save(path);

                }
            }


            _propertyEngine.Update(model.property);

            return RedirectToAction("Detail", "Asset", new { id = model.property.Id });








        }
        #endregion


        public async Task<ActionResult> Detail(int id)
        {
            ViewBag.CategoryList = _categoryEngine.GetAll();
            var model = await _propertyEngine.GetAsync(id);
            return View(model);
        }

        [ValidateInput(false)]
        public async Task<ActionResult> Edit(int id)
        {
            var model = new AssetViewModel();
            model.property = await _propertyEngine.GetAsync(id);
            model.CategoryList = _categoryEngine.GetAll();
            return View(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(AssetViewModel model, List<HttpPostedFileBase> Gallery)
        {
           
            var getModel = _propertyEngine.GetAll().Where(x => x.Id == model.property.Id).FirstOrDefault();

            int catid = model.property.Category.Id;
            var user = (User)Session["login"];
            model.property.ModifiedDate = DateTime.Now;
            if (Gallery[0] != null)
            {
                var path1 = Server.MapPath("~/Gallery/" + model.property.Id.ToString());

                foreach (var file in Gallery)
                {
                    Photo photo = new Photo();

                    FileInfo info = new FileInfo(file.FileName);
                    var filename = Guid.NewGuid().ToString() + info.Extension;
                    photo.ImageUrl = filename;
                    photo.Property = model.property;
                    _iphotoEngine.Add(photo);

                    model.property.Photo.Add(photo);

                    var path = Path.Combine(path1, filename);
                    WebImage img = new WebImage(file.InputStream);
                    img.Save(path);
                    getModel.Photo = model.property.Photo;

                }
            }

            getModel.Price = model.property.Price;
            getModel.ModifiedDate = model.property.ModifiedDate;
            getModel.Room = model.property.Room;
            getModel.ShortDescription = model.property.ShortDescription;
            getModel.Status = model.property.Status;
            getModel.Title = model.property.Title;
            getModel.TypeOfProperty = model.property.TypeOfProperty;
            getModel.GeoLocation = model.property.GeoLocation;
            getModel.City = model.property.City;
            getModel.District = model.property.District;
            getModel.Discount = model.property.Discount;
            getModel.Category = model.property.Category;
            getModel.Area = model.property.Area;


            _propertyEngine.Update(getModel);

            return RedirectToAction("UserProperties", "User");
        }

        public ActionResult Delete (int id)
        {
           var prop=  _propertyEngine.Delete(id);
            return RedirectToAction("UserProperties", "User");

        }

        public async Task<ActionResult> Sold(int id)
        {
            var GetModel = await _propertyEngine.GetAsync(id);
           GetModel.IsSold = true;
            _propertyEngine.Update(GetModel);

            return RedirectToAction("UserProperties", "User");

        }

           

    }
}
