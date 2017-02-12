using Rotativa.Options;
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

        public ActionResult DownloadT24APDF()
        {
            //Code to get content
            return new Rotativa.ViewAsPdf("WillAfrikaans") { FileName = "T24TestamentPdf.pdf" };
        }
        public ActionResult DownloadT24EPDF()
        {
            //Code to get content
            string filename = "firstPdf.pdf";
            string AsTESTATR = "As TESTATOR______"+" "+ "As TESTATRIX____";
            string AsTESTATRIX = "As TESTATRIX______________________________";
            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";
            return new Rotativa.ViewAsPdf("WillEnglishT24") {
                FileName = filename
                //PageOrientation = Rotativa.Options.Orientation.Portrait,
                //IsGrayScale = true,
                //IsJavaScriptDisabled = true,
                //IsBackgroundDisabled = true,
                //MinimumFontSize = 12,
                //PageSize = Rotativa.Options.Size.A4,
                //PageMargins = new Rotativa.Options.Margins(20, 15, 20, 15),
                //CustomSwitches = string.Format("--footer-left \"Date: [date] [time]\" "
                //                                + "--footer-center \""+ AsTESTATR+"\""
                //                                + "--footer-right \"Page [page] of [toPage]\" "
                //                                + "--footer-font-size \"8\" "
                //                                + "--footer-line "
                //                                + "--footer-spacing \"3\"",filename)

                
            };
       
    }

        public ActionResult WillAfrikaans ()
        {
            return View();
        }
    }
}