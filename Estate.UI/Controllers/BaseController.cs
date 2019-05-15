using Estate.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estate.UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICategoryEngine _categoryEngine;


        // GET: Base
        public BaseController(ICategoryEngine categoryEngine)
        {
            _categoryEngine = categoryEngine;

        }
       
        


  

        public void setCategory()
        {
            ViewBag.CategoryList = _categoryEngine.GetAll();
        }
    }
}