using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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
            ViewBag.Message = "Test Form";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Mail vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("mariedressner@gmail.com");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    var Epassword = vm.EmailPassword;

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    (vm.Email, Epassword);

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult VolunteerProcess()
        {
            return View();
        }

        public ActionResult DownloadFile()
        {
            string file = "\\Users\\Julie\\Documents\\projects\\Capstone\\Capstone\\Capstone\\files\\VolunteerInfo.docx";

            if (!System.IO.File.Exists(file))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(file);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = "VolunteerInfo.docx"
            };
            return response;
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