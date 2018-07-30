using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class EventViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventViewModels
        public ActionResult Index()
        {
            var eventViewModels = db.EventViewModels.Include(e => e.Admin).Include(e => e.Event).Include(e => e.EventResponse).Include(e => e.Volunteer);
            return View(eventViewModels.ToList());
        }

        // GET: EventViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventViewModel eventViewModel = db.EventViewModels.Find(id);
            if (eventViewModel == null)
            {
                return HttpNotFound();
            }
            return View(eventViewModel);
        }

        // GET: EventViewModels/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "ID", "Name");
            ViewBag.EventID = new SelectList(db.Events, "ID", "Time");
            ViewBag.ResponseID = new SelectList(db.EventResponses, "ID", "Response");
            ViewBag.VolunteerID = new SelectList(db.Volunteers, "ID", "Name");
            return View();
        }

        // POST: EventViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AdminID,VolunteerID,EventID,ResponseID")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                db.EventViewModels.Add(eventViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminID = new SelectList(db.Admins, "ID", "Name", eventViewModel.AdminID);
            ViewBag.EventID = new SelectList(db.Events, "ID", "Time", eventViewModel.EventID);
            ViewBag.ResponseID = new SelectList(db.EventResponses, "ID", "Response", eventViewModel.ResponseID);
            ViewBag.VolunteerID = new SelectList(db.Volunteers, "ID", "Name", eventViewModel.VolunteerID);
            return View(eventViewModel);
        }

        // GET: EventViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventViewModel eventViewModel = db.EventViewModels.Find(id);
            if (eventViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.Admins, "ID", "Name", eventViewModel.AdminID);
            ViewBag.EventID = new SelectList(db.Events, "ID", "Time", eventViewModel.EventID);
            ViewBag.ResponseID = new SelectList(db.EventResponses, "ID", "Response", eventViewModel.ResponseID);
            ViewBag.VolunteerID = new SelectList(db.Volunteers, "ID", "Name", eventViewModel.VolunteerID);
            return View(eventViewModel);
        }

        // POST: EventViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AdminID,VolunteerID,EventID,ResponseID")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminID = new SelectList(db.Admins, "ID", "Name", eventViewModel.AdminID);
            ViewBag.EventID = new SelectList(db.Events, "ID", "Time", eventViewModel.EventID);
            ViewBag.ResponseID = new SelectList(db.EventResponses, "ID", "Response", eventViewModel.ResponseID);
            ViewBag.VolunteerID = new SelectList(db.Volunteers, "ID", "Name", eventViewModel.VolunteerID);
            return View(eventViewModel);
        }

        // GET: EventViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventViewModel eventViewModel = db.EventViewModels.Find(id);
            if (eventViewModel == null)
            {
                return HttpNotFound();
            }
            return View(eventViewModel);
        }

        // POST: EventViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventViewModel eventViewModel = db.EventViewModels.Find(id);
            db.EventViewModels.Remove(eventViewModel);
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
