using DoAnWeb.Models;
using Models;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.comDetail = com.Choose(id);

            var review = new ReviewDAO();
            ViewBag.reviews = review.ListAll(id);
            return View();
        }

        public ActionResult Write()
        {
            return PartialView("Write");
        }

        [HttpPost]
        public ActionResult Write(Review review)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var re = new ReviewDAO();
            var user = new UserDao();
            var session = (LoginModel)Session[Constants.USER_SESSION];
            review.UserId = user.findUserByName(session.userName);
            re.insert(review);

            return RedirectToAction("Index");
        }

        public ActionResult Insert()
        {
            var industry = new IndustryDAO();
            var listIndustry = industry.ListIndustry();
            ViewBag.listIndustry = listIndustry;
            //ViewBag.listIndustry = new SelectList(listIndustry, "FieldName", "ID");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CompanyVM model)
        {


            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            var filename = Path.GetFileName(model.ImageLogo.FileName);
            var path = Path.Combine(Server.MapPath("~/Assets/img/Logo/"), filename);
            model.ImageLogo.SaveAs(path);

            var company = new CompanyDao();
            var user = new UserDao();
            var session = (LoginModel)Session[Constants.USER_SESSION];

            var com = new Company();
            com.Name = model.Name;
            com.Address = model.Address;
            com.Logo = filename;
            com.Web = model.Web;
            com.Rating = 0;
            com.Confirm = false;
            //com.FieldID = industry.findIndustryByName(model.Field);
            com.FieldID = model.FieldID;
            com.UserRequest = user.findUserByName(session.userName);

            company.insert(com);
            ModelState.Clear();

            return RedirectToAction("Index");
        }
    }
}