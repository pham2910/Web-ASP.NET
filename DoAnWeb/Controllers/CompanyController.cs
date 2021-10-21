﻿using Models.DAO;
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
            return View(comList);
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            var com = new CompanyDao();
            var comList = com.ListWhere(name);
            ViewBag.SearchCom = name;
            return View(comList);
        }
    }
}