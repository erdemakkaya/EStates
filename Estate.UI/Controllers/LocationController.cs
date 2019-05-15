using Estate.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Estate.UI.Controllers
{
    public class LocationController : Controller
    {
        private readonly IPropertyEngine _propertyEngine;

        public LocationController(IPropertyEngine propertyEngine)
        {
            _propertyEngine = propertyEngine;
        }

        // GET: Location
        public JsonResult GetMapLocations()
        {
            
            var data = _propertyEngine.GetAll().Select(x => new { x.Id, x.GeoLocation.Lat, x.GeoLocation.Long,x.GeoLocation.Address,x.Price, x.Photo.FirstOrDefault().ImageUrl, x.Title,catid=x.Category.Id}).ToList(); // categori id farklı bir isimle gönder
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public  JsonResult GetMapLocationById(int id)
       {
            var data = _propertyEngine.GetAll().Where(x=>x.Id==id).Select(x => new { x.Id, x.GeoLocation.Lat, x.GeoLocation.Long, x.GeoLocation.Address, x.Price, x.Photo.FirstOrDefault().ImageUrl, x.Title, catid = x.Category.Id }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
      }
    }
}