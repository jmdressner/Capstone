using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Event")]
        public string Occasion { get; set; }
        public string Description { get; set; }

    }
}