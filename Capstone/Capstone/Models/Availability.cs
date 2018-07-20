using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Availability
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Admin")]
        [Display(Name = "Admin")]
        public int? AdminID { get; set; }
        public Admin Admin { get; set; }

        [ForeignKey("Volunteer")]
        [Display(Name = "Volunteer")]
        public int? VolunteerID { get; set; }
        public Volunteer Volunteer { get; set; }

        [ForeignKey("Week")]
        [Display(Name = "Day")]
        public int DayID { get; set; }
        public Week Week { get; set; }

        [ForeignKey("Program")]
        public int ServiceID { get; set; }
        public Program Program { get; set; }

        [ForeignKey("Request")]
        [Display(Name = "Request Off")]
        public int RequestID { get; set; }
        public Request Request { get; set; }

        [Display(Name = "Volunteer Status")]
        public bool VolunteerStatus { get; set; }

    }
}