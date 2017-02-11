using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wills.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DownloadViewPDF()
        {
            //Code to get content
            return new Rotativa.ViewAsPdf("Index") { FileName = "TestViewAsPdf.pdf" };
        }
    }
}