using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Display(Name = "Event")]
        public string Occasion { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        [Display(Name = "Color Theme")]
        public string ThemeColor { get; set; }
        [Display(Name = "Full Day Event")]
        public bool IsFullDay { get; set; }

    }
}