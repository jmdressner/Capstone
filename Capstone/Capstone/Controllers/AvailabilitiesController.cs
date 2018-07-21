using Capstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Capstone.Controllers
{
    public class AvailabilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            if(User.IsInRole("Admin"))
            {
                var admin = db.Admins.Where(a => a.ApplicationUserID == currentUserId).FirstOrDefault();
                var availabilities = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).Where(a => a.AdminID == admin.ID).ToList();
                return View(availabilities);
            }
            else
            {
                var volunteer = db.Volunteers.Where(e => e.ApplicationUserID == currentUserId).FirstOrDefault();
                var availabilities = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).Where(a => a.VolunteerID == volunteer.ID).ToList();
                return View(availabilities);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DayID = new SelectList(db.Weeks, "ID", "Day");
            ViewBag.StartTimeID = new SelectList(db.Programs, "ID", "Service");

            return View();
        }

        [HttpPost, ActionName("AvailabilityACreate")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AdminID,VolunteerID,DayID,ServiceID,RequestID,VolunteerStatus")] Availability availability)
        {
            var currentUserId = User.Identity.GetUserId();
            if (User.IsInRole("Admin"))
            {
                var admin = db.Admins.Where(a => a.ApplicationUserID == currentUserId).FirstOrDefault();
                availability.AdminID = admin.ID;
            }
            else
            {
                var volunteer = db.Volunteers.Where(a => a.ApplicationUserID == currentUserId).FirstOrDefault();
                availability.VolunteerID = volunteer.ID;
            }
            var day = db.Weeks.Where(d => d.ID == availability.DayID).FirstOrDefault();
            var program = db.Programs.Where(s => s.ID == availability.ServiceID).FirstOrDefault();
            var request = db.Requests.Where(t => t.ID == availability.RequestID).FirstOrDefault();


            if (ModelState.IsValid || availability.ID == 0)
            {
                availability.DayID = day.ID;
                availability.ServiceID = program.ID;
                availability.RequestID = request.ID;
                db.Availabilities.Add(availability);
                db.SaveChanges();

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admins");
                }
                else
                {
                    return RedirectToAction("Index", "Volunteers");
                }
            }

            ViewBag.DayID = new SelectList(db.Weeks, "ID", "Day");
            ViewBag.ServiceID = new SelectList(db.Programs, "ID", "Service");
           
            return View(availability);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).Where(a => a.ID == id).FirstOrDefault();

            if (availability == null)
            {
                return HttpNotFound();
            }

            ViewBag.DayID = new SelectList(db.Weeks, "ID", "Day");
            ViewBag.ServiceID = new SelectList(db.Programs, "ID", "Service");

            return View(availability);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AdminID,VolunteerID,DayID,ServiceID,RequestID,VolunteerStatus")] Availability availability)
        {
            var currentUserId = User.Identity.GetUserId();
            if (User.IsInRole("Admin"))
            {
                var admin = db.Admins.Where(a => a.ID == availability.AdminID).FirstOrDefault();
                availability.AdminID = admin.ID;
            }
            else
            {
                var volunteer = db.Volunteers.Where(a => a.ID == availability.VolunteerID).FirstOrDefault();
                availability.VolunteerID = volunteer.ID;
            }
           
            var day = db.Weeks.Where(d => d.ID == availability.DayID).FirstOrDefault();
            var program = db.Programs.Where(s => s.ID == availability.ServiceID).FirstOrDefault();
            var request = db.Requests.Where(t => t.ID == availability.RequestID).FirstOrDefault();

            if (ModelState.IsValid)
            {
                var available = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).Where(a => a.ID == availability.ID).FirstOrDefault();
                availability.DayID = day.ID;
                availability.ServiceID = program.ID;
                availability.RequestID = request.ID;
                availability.VolunteerStatus = available.VolunteerStatus;
                db.SaveChanges();

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admins");
                }
                else
                {
                    return RedirectToAction("Index", "Volunteers");
                }
            }
            return View(availability);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).Where(a => a.ID == id).FirstOrDefault();
            if (availability == null)
            {
                return HttpNotFound();
            }

            ViewBag.DayID = new SelectList(db.Weeks, "ID", "Day");
            ViewBag.ServiceID = new SelectList(db.Programs, "ID", "Service");
            
            return View(availability);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Availability availability = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).Where(a => a.ID == id).FirstOrDefault();
            db.Availabilities.Remove(availability);
            db.SaveChanges();

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admins");
            }
            else
            {
                return RedirectToAction("Index", "Volunteers");
            }
        }

        public ActionResult ScheduleIndex()
        {
            var availabilities = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).OrderBy(a => a.DayID).ToList();
            return View(availabilities);
        }

        public ActionResult ScheduleEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).Where(a => a.ID == id).FirstOrDefault();

            if (availability == null)
            {
                return HttpNotFound();
            }

            ViewBag.DayID = new SelectList(db.Weeks, "ID", "Day");
            ViewBag.ServiceID = new SelectList(db.Programs, "ID", "Service");
            
            return View(availability);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScheduleEdit([Bind(Include = "ID,AdminId,VolunteerID,DayID,ServiceID,RequestID,VolunteerStatus")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(availability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ScheduleIndex", "Admins");
            }
            return View(availability);
        }

        public ActionResult ScheduleCreate()
        {
            var availabilities = db.Availabilities.Include(a => a.Admin).Include(a => a.Volunteer).Include(a => a.Week).Include(a => a.Program).Include(a => a.Request).OrderBy(a => a.DayID).Where(a => a.VolunteerStatus == true).ToList();
            return View(availabilities);
        }
    }
}