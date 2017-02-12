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
        [Authorize]
        public ActionResult Create()
        {
            ApplicationUser _LoggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");

            WillViewModel wvm = new WillViewModel();
            wvm.UserID = _LoggedInUser.Id;
            wvm.Heirs = new List<HeirViewModel>();
            wvm.Bequest = new List<HeirViewModel>();

            return View(wvm);
        }

        public ActionResult AddHeir()
        {
            return PartialView("Heir", new HeirViewModel());
        }

        public ActionResult AddBequest()
        {
            return PartialView("Bequest", new HeirViewModel());
        }

        // POST: Will/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(WillViewModel newWill)
        {
            if (ModelState.IsValid)
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //...Mapping
                        FullWill dbWill = new FullWill()
                        {
                            CoExecutorIDNumber = newWill.CoExecutorIDNumber,
                            CoExecutorName = newWill.CoExecutorName,
                            CoExecutorSurname = newWill.CoExecutorSurname,
                            CoTrusteeIDNumber = newWill.CoTrusteeIDNumber,
                            CoTrusteeName = newWill.CoTrusteeName,
                            CoTrusteeSurname = newWill.CoTrusteeSurname,
                            DoCremation = newWill.DoCremation,
                            GardianIDNumber = newWill.GardianIDNumber,
                            GardianName = newWill.GardianName,
                            GardianSurname = newWill.GardianSurname,
                            HasSpecialRequest = newWill.HasSpecialRequest,
                            IsLivingWill = newWill.IsLivingWill,
                            IsOrganDoner = newWill.IsOrganDoner,
                            MaritalStatusID = newWill.MaritalStatusID,
                            PrimaryClientIDNumber = newWill.PrimaryClientIDNumber,
                            PrimaryClientName = newWill.PrimaryClientName,
                            PrimaryClientSurname = newWill.PrimaryClientSurname,
                            SecandaryClientIDNumber = newWill.SecandaryClientIDNumber,
                            SecandaryClientName = newWill.SecandaryClientName,
                            SecanderyClientSurname = newWill.SecanderyClientSurname,
                            SpecialRequest = newWill.SpecialRequest,
                            UserID = newWill.UserID,
                            WillTypeID = newWill.WillTypeID
                        };

                            dbWill = db.FullWills.Add(dbWill);
                        await db.SaveChangesAsync();

                        if (dbWill.WillID != 0)
                        {
                            if (newWill.Heirs != null)
                            {
                                foreach (var Heir in newWill.Heirs)
                                {
                                    var dbHeir = new HeirBequest()
                                    {
                                        BequestAmount = Heir.BequestAmount,
                                        BequestItem = Heir.BequestItem,
                                        FullWillID = dbWill.WillID,
                                        HeirPercentage = Heir.HeirPercentage,
                                        IDNumber = Heir.IDNumber,
                                        Name = Heir.Name,
                                        IsHeir = true,
                                        RelationshipID = Heir.RelationshipID,
                                        Surname = Heir.Surname,
                                    };

                                    db.HeirBequests.Add(dbHeir);
                                }
                            }

                            if (newWill.Bequest != null)
                            {
                                foreach (var Bequest in newWill.Bequest)
                                {
                                    var dbBequest = new HeirBequest()
                                    {
                                        BequestAmount = Bequest.BequestAmount,
                                        BequestItem = Bequest.BequestItem,
                                        FullWillID = dbWill.WillID,
                                        HeirPercentage = Bequest.HeirPercentage,
                                        IDNumber = Bequest.IDNumber,
                                        Name = Bequest.Name,
                                        IsHeir = false,
                                        RelationshipID = Bequest.RelationshipID,
                                        Surname = Bequest.Surname,
                                    };

                                    db.HeirBequests.Add(dbBequest);
                                }
                            }
                        }

                        await db.SaveChangesAsync();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                    }
                }               

                return RedirectToAction("Index");
            }
            
            return View(newWill);
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
