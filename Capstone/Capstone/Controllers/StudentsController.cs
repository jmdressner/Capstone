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
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ViewResult Index(string sortOrder, string heading, string searchString)
        {
            
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            ViewBag.EmailSortParm = String.IsNullOrEmpty(sortOrder) ? "email_asc" : "";
            ViewBag.PhoneSortParm = String.IsNullOrEmpty(sortOrder) ? "phone_asc" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "address_asc" : "";
            ViewBag.ZipcodeSortParm = String.IsNullOrEmpty(sortOrder) ? "zipcode_asc" : "";
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_asc" : "";
            ViewBag.DateASortParm = String.IsNullOrEmpty(sortOrder) ? "dateA_asc" : "";
            ViewBag.AgencySortParm = String.IsNullOrEmpty(sortOrder) ? "agency_asc" : "";
            ViewBag.DateRSortParm = String.IsNullOrEmpty(sortOrder) ? "dateR_asc" : "";
            ViewBag.ServiceSortParm = String.IsNullOrEmpty(sortOrder) ? "service_asc" : "";

            var students = db.Students.Include(s => s.Agency).Include(s => s.Program).Select(s => s);

            if (!String.IsNullOrEmpty(heading))
            {
                switch (heading)
                {
                    case "Name":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Name.Contains(searchString));
                            return View(students);
                        }
                        break;
                    case "Email":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Email.Contains(searchString));
                            return View(students);
                        }
                        break;
                    case "Phone":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Phone.Contains(searchString));
                            return View(students);
                        }
                        break;
                    case "Address":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Address.Contains(searchString));
                            return View(students);
                        }
                        break;
                    case "Zipcode":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Zipcode.Contains(searchString));
                            return View(students);
                        }
                        break;
                    case "Country":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Country.Contains(searchString));
                            return View(students);
                        }
                        break;
                    case "Date of Arrival":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.DateOfArrival.Equals(searchString));
                            return View(students);
                        }
                        break;
                    case "Agency":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Agency.Settlement.Contains(searchString));
                            return View(students);
                        }
                        break;
                    case "Date of Registration":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.DateOfRegistration.Equals(searchString));
                            return View(students);
                        }
                        break;
                    case "Service":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Program.Service.Contains(searchString));
                            return View(students);
                        }
                        break;
                    case "Notes":
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Bio.Contains(searchString));
                            return View(students);
                        }
                        break;
                    default:
                        if (!String.IsNullOrEmpty(searchString))
                        {
                            students = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.Name.Contains(searchString));
                            return View(students);
                        }
                        break;
                }
            }
            

            switch (sortOrder)
            {
                case "name_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Name);
                    break;
                case "email_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Email);
                    break;
                case "phone_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Phone);
                    break;
                case "address_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Address);
                    break;
                case "zipcode_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Zipcode);
                    break;
                case "country_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Country);
                    break;
                case "dateA_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.DateOfArrival);
                    break;
                case "agency_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Agency.Settlement);
                    break;
                case "dateR_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.DateOfRegistration);
                    break;
                case "service_asc":
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Program.Service);
                    break;
                default:
                    students = db.Students.Include(s => s.Agency).Include(s => s.Program).OrderBy(s => s.Name);
                    break;
            }

            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Include(s => s.Agency).Include(s => s.Program).Where(s => s.ID == id).FirstOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.AgencyID = new SelectList(db.Agencies, "ID", "Settlement");
            ViewBag.ServiceID = new SelectList(db.Programs, "ID", "Service");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Phone,Address,Zipcode,Country,DateOfArrival,AgencyID,DateOfRegistration,ServiceID,Bio")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgencyID = new SelectList(db.Agencies, "ID", "Settlement", student.AgencyID);
            ViewBag.ServiceID = new SelectList(db.Programs, "ID", "Service", student.ServiceID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgencyID = new SelectList(db.Agencies, "ID", "Settlement", student.AgencyID);
            ViewBag.ServiceID = new SelectList(db.Programs, "ID", "Service", student.ServiceID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Phone,Address,Zipcode,Country,DateOfArrival,AgencyID,DateOfRegistration,ServiceID,Bio")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgencyID = new SelectList(db.Agencies, "ID", "Settlement", student.AgencyID);
            ViewBag.ServiceID = new SelectList(db.Programs, "ID", "Service", student.ServiceID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
