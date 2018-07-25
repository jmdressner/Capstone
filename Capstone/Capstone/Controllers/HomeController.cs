using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            ViewBag.Key = Key.GOOGLE_MAP_KEY;
            return View();
        }

        public ActionResult Download()
        {
            string file = "\\Users\\Julie\\Documents\\projects\\Capstone\\Capstone\\Capstone\\files\\100q.pdf";

            if (!System.IO.File.Exists(file))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(file);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = "100q.pdf"
            };
            return response;
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Videos()
        {
            return View();
        }

        public ActionResult Questions()
        {
            return View();
        }


    }
}