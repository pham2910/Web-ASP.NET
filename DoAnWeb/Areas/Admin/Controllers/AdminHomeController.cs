using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            CompanyDao CD = new CompanyDao();
            UserDao UD = new UserDao();
            IndustryDAO FD = new IndustryDAO();

            ViewBag.Company = CD.ListAll();
            ViewBag.User = UD.getListUsers();
            ViewBag.Field = FD.ListIndustry();

            return View();
        }

        public ActionResult Confirm()
        {
            return View();
        }

        public ActionResult Company()
        {
            return View();
        }

        public ActionResult Field()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult ViewUIUXDesign()
        {
            return View();
        }
    }
}