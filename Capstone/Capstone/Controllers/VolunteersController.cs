using Capstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            ViewBag.EmailSortParm = String.IsNullOrEmpty(sortOrder) ? "email_asc" : "";
            ViewBag.PhoneSortParm = String.IsNullOrEmpty(sortOrder) ? "phone_asc" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "address_asc" : "";
            ViewBag.ZipcodeSortParm = String.IsNullOrEmpty(sortOrder) ? "zipcode_asc" : "";
            ViewBag.ChurchSortParm = String.IsNullOrEmpty(sortOrder) ? "church_asc" : "";
            ViewBag.BackgroundCheckSortParm = sortOrder == "BackgroundCheck" ? "BackGC_asc" : "BackgroundCheck";
            var volunteers = db.Volunteers.Select(v => v);

            switch (sortOrder)
            {
                case "name_asc":
                    volunteers = db.Volunteers.OrderBy(v => v.Name);
                    break;
                case "email_asc":
                    volunteers = db.Volunteers.OrderBy(v => v.Email);
                    break;
                case "phone_asc":
                    volunteers = db.Volunteers.OrderBy(v => v.Phone);
                    break;
                case "address_asc":
                    volunteers = db.Volunteers.OrderBy(v => v.Address);
                    break;
                case "zipcode_asc":
                    volunteers = db.Volunteers.OrderBy(v => v.Zipcode);
                    break;
                case "church_asc":
                    volunteers = db.Volunteers.OrderBy(v => v.Church);
                    break;
                case "BackgroundCheck":
                    volunteers = db.Volunteers.OrderBy(v => v.BackgroundCheckStatus);
                    break;
                default:
                    volunteers = db.Volunteers.OrderBy(v => v.Name);
                    break;
            }
            return View(volunteers.ToList());
        }

        // GET: Volunteers/Details/5
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

        // GET: Volunteers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteers/Create
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

        // GET: Volunteers/Edit/5
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

        // POST: Volunteers/Edit/5
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
                if (User.IsInRole("Volunteer"))
                {
                    return RedirectToAction("Details");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(volunteer);
        }

        // GET: Volunteers/Delete/5
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

        // POST: Volunteers/Delete/5
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
                
        public ActionResult RequestOffIndex()
        {
            var currentUserId = User.Identity.GetUserId();
            if (User.IsInRole("Admin"))
            {
                var request = db.Requests.Include(r => r.Volunteer).ToList();
                return View(request);
            }
            else
            {
                var volunteer = db.Volunteers.Where(v => v.ApplicationUserID == currentUserId).FirstOrDefault();
                var request = db.Requests.Where(r => r.VolunteerID == volunteer.ID).ToList();
                return View(request);
            }
        }

        public ActionResult RequestOffCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestOffCreate([Bind(Include = "ID,VolunteerID,Date,Reason")] Request request)
        {
            var currentUserId = User.Identity.GetUserId();
            var volunteer = db.Volunteers.Where(v => v.ApplicationUserID == currentUserId).FirstOrDefault();
            
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                request.VolunteerID = volunteer.ID;
                db.SaveChanges();
                return RedirectToAction("RequestOffIndex", "Volunteers");
            }

            return View(volunteer);
        }

        public ActionResult RequestOffEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);

            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestOffEdit([Bind(Include = "Id,VolunteerID,Date,Reason")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RequestOffIndex", "Volunteers");
            }
            return View(request);
        }

        public ActionResult RequestOffDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        [HttpPost, ActionName("RequestOffDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RequestOffDeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("RequestOffIndex", "Volunteers");
        }
    }
}