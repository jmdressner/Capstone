using Capstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class VolunteersController : Controller
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Volunteers
        public ActionResult Index()
        {
            return View(db.Volunteers.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            var currentUserId = User.Identity.GetUserId();

            if (currentUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Where(e => e.ApplicationUserID == currentUserId).FirstOrDefault();
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,Address,Zipcode,Church,BackgroundCheckStatus,ApplicationUserId")] Volunteer volunteer)
        {
            var currentUserId = User.Identity.GetUserId();
            volunteer.ApplicationUserID = currentUserId;

            if (ModelState.IsValid)
            {
                db.Volunteers.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(volunteer);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,Address,Zipcode,Church,BackgroundCheckStatus,ApplicationUserId")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(volunteer);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteer);
            db.SaveChanges();
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