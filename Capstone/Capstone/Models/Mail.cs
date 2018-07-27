using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Mail
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Email Password")]
        public string EmailPassword { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}