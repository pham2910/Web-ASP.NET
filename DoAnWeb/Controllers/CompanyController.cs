using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var com = new CompanyDao();
            var comList = com.ListAll();

            var indus = new IndustryDAO();
            ViewBag.industries = indus.ListIndustry();
            return View(comList);

        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            var com = new CompanyDao();
            var comList = com.ListWhere(name);
            ViewBag.SearchKeyword = name;

            var indus = new IndustryDAO();
            ViewBag.industries = indus.ListIndustry();
            return View(comList);
        }

        public ActionResult Detail(int id)
        {
            var com = new CompanyDao();
            var comDetail = com.Choose(id);
            return View(comDetail);
        }
    }
}