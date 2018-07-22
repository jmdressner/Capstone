using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Volunteer")]
        [Display(Name = "Volunteer")]
        public int? VolunteerID { get; set; }
        public Volunteer Volunteer { get; set; }

        public DateTime Date { get; set; }
        public string Reason { get; set; }

    }
}