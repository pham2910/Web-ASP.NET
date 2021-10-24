using Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ///if (Session[Constants.USER_SESSION] == null)
            // return RedirectToAction("Index", "Login");
            var com = new CompanyDao();
            var comList = com.ListTop();

            return View(comList);
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }


    }
}