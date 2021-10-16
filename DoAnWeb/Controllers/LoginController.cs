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
                var result = user.login(model.userName, Common.EncryptMD5(model.password));
                if (result != null)
                {
                    model.userName = result.UserName;
                    model.email = result.Email;
                    Session.Add(Constants.USER_SESSION, model);
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