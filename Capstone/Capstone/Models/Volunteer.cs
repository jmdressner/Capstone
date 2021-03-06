﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Volunteer
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Volunteer")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name ="Phone Number")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Church { get; set; }
        [Display(Name = "Background Check")]
        public bool BackgroundCheckStatus { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}