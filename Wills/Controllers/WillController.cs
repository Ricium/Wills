using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Wills.Models;

namespace Wills.Controllers
{
    public class WillController : Controller
    {
        [Authorize]
        public ActionResult Index()
        { 
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            //...Get user
            ApplicationUser _LoggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            //...Load the last client profile entered, if any
            Client _LastClientProfile = new Client();

            using (WillsDatabaseEntities db = new WillsDatabaseEntities())
            {
                _LastClientProfile = db.Clients.Where(x => x.UserId.Equals(_LoggedInUser.Id)).OrderByDescending(x => x.ClientID).FirstOrDefault();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(int a)
        {
            return View();
        }
    }
}