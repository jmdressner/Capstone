﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        [Display(Name = "Country of Origin")]
        public string Country { get; set; }

        [ForeignKey("Program")]
        [Display(Name = "Services used")]
        public int ServiceID { get; set; }
        public Program Program { get; set; }

        [Display(Name = "Brief Biography")]
        public string Bio { get; set; }
    }
}