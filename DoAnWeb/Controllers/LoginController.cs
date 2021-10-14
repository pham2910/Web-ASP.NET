using DoAnWeb.Models;
using Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                var result = user.login(model.userName, model.password);
                if (result == 1)
                {
                    Session.Add(Constants.USER_SESSION, model.userName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Something was wrong!");
                }
            }
            return View("Index");

        }
    }
}