﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wills.Models;

namespace Wills.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DownloadViewPDF()
        {

            //Code to get content
            return new Rotativa.ViewAsPdf("Index") { FileName = "TestViewAsPdf.pdf" };
        }
    }
}