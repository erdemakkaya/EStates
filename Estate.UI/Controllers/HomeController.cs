using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estate.Business.Contracts;

namespace Estate.UI.Controllers
{
    public class HomeController: BaseController
    {
        private readonly IPropertyEngine _propertyEngine;
        public HomeController(ICategoryEngine categoryEngine,IPropertyEngine propertyEngine) : base(categoryEngine)
        {
            _propertyEngine = propertyEngine;
        }

        // GET: Home
        public ActionResult Index()
        {
            setCategory();
            var model = _propertyEngine.GetAll(4,4).Where(x=>!x.IsDeleted).ToList(); ;

            return View(model);
        }
        public ActionResult Map()
        {
            return View();
        }
    }
}