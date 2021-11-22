using DoAnWeb.Models;
using Models;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM user)
        {
            if (ModelState.IsValid)
            {
                var ent_user = new User();
                ent_user.Email = user.Email;
                ent_user.UserName = user.UserName;
                ent_user.Pwd = user.Pwd;


                var dao = new UserDao();
                if (dao.findAccount(ent_user.UserName, ent_user.Email))
                {
                    ModelState.AddModelError("", "This account has already been registered.");
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    var pass = Common.EncryptMD5(ent_user.Pwd);
                    ent_user.Pwd = pass;
                    string result = dao.insert(ent_user);
                    if (!string.IsNullOrEmpty(result))
                    {
                        LoginModel model = new LoginModel();
                        model.userName = ent_user.UserName;
                        model.email = ent_user.Email;
                        model.password = ent_user.Pwd;

                        var res = dao.login(model.userName, model.password);
                        if (res != null)
                        {
                            Session.Add(Constants.USER_SESSION, model);
                            return RedirectToAction("Index", "Home");
                        }
                        /*else
                        {
                            ModelState.AddModelError("", "Something was wrong!");
                        }*/
                    }
                    else
                    {
                        ModelState.AddModelError("", "Registration failed! Please try again later.");
                    }
                }
            }
            return View();
        }
    }
}