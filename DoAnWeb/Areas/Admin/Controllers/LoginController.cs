using DoAnWeb.Areas.Admin.Data;
using Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
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
                var result = user.login(model.adminName, model.password);
                if (result == 1)
                {
                    //ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, model.adminName);
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