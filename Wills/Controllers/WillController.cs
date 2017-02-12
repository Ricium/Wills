using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wills.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Wills.Controllers
{
    public class WillController : Controller
    {
        private WillsDatabaseEntities db = new WillsDatabaseEntities();

        // GET: Will
        [Authorize]
        public async Task<ActionResult> Index()
        {
            ApplicationUser _LoggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var fullWills = db.FullWills.Where(x => x.UserID.Equals(_LoggedInUser.Id));
            return View(await fullWills.ToListAsync());
        }

        // GET: Will/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullWill fullWill = await db.FullWills.FindAsync(id);
            if (fullWill == null)
            {
                return HttpNotFound();
            }
            return View(fullWill);
        }

        // GET: Will/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Will/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WillID,UserID,PrimaryClientName,PrimaryClientSurname,PrimaryClientIDNumber,SecandaryClientName,SecanderyClientSurname,SecandaryClientIDNumber,WillTypeID,MaritalStatusID,GardianName,GardianSurname,GardianIDNumber,CoExecutorName,CoExecutorSurname,CoExecutorIDNumber,CoTrusteeName,CoTrusteeSurname,CoTrusteeIDNumber,DoCremation,IsLivingWill,IsOrganDoner,HasSpecialRequest,SpecialRequest")] FullWill fullWill)
        {
            if (ModelState.IsValid)
            {
                db.FullWills.Add(fullWill);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", fullWill.UserID);
            return View(fullWill);
        }

        // GET: Will/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullWill fullWill = await db.FullWills.FindAsync(id);
            if (fullWill == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", fullWill.UserID);
            return View(fullWill);
        }

        // POST: Will/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WillID,UserID,PrimaryClientName,PrimaryClientSurname,PrimaryClientIDNumber,SecandaryClientName,SecanderyClientSurname,SecandaryClientIDNumber,WillTypeID,MaritalStatusID,GardianName,GardianSurname,GardianIDNumber,CoExecutorName,CoExecutorSurname,CoExecutorIDNumber,CoTrusteeName,CoTrusteeSurname,CoTrusteeIDNumber,DoCremation,IsLivingWill,IsOrganDoner,HasSpecialRequest,SpecialRequest")] FullWill fullWill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fullWill).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", fullWill.UserID);
            return View(fullWill);
        }

        // GET: Will/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullWill fullWill = await db.FullWills.FindAsync(id);
            if (fullWill == null)
            {
                return HttpNotFound();
            }
            return View(fullWill);
        }

        // POST: Will/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FullWill fullWill = await db.FullWills.FindAsync(id);
            db.FullWills.Remove(fullWill);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
