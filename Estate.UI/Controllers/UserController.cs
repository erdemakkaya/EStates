using Estate.Business.Contracts;
using Estate.Data.Entities;
using Estate.UI.CustomFilter;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estate.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserEngine _userEngine;
        private readonly IPropertyEngine _propertyEngine;

        public UserController(IUserEngine userEngine,IPropertyEngine proertyEngine)
        {
            _userEngine = userEngine;
            _propertyEngine = proertyEngine;
        }
        // GET: User
     
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string Mail, string Pw)
        {


            var state = _userEngine.GetAll().First(x => x.Mail == Mail && x.Pw == Pw);
            if (state != null)
            {

                Session["login"] = state;

                return RedirectToAction("Index", "Home");
            }
            else {

                return View();
            }
          

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            _userEngine.Add(user);
            return RedirectToAction("SignIn", "User");



        }

        public ActionResult LogOut()
        {
            Session["login"] = null;
            return RedirectToAction("Index", "Home");

        
        }

        [LoginFilter]
        public ActionResult Profile()
        {
            var userModel = (User)Session["login"];
            return View(userModel);
        }

        [LoginFilter]

        public ActionResult UserProperties(int page=1)
        {
            var user = (User)Session["Login"];
            var model = _propertyEngine.GetAll().Where(x => x.User.Id == user.Id).ToPagedList(page,6);
            return  View(model);
            
        }
        
    }
}