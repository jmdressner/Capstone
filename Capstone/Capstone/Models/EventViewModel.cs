﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class EventViewModel
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

        [ForeignKey("Event")]
        [Display(Name = "Event")]
        public int EventID { get; set; }
        public Event Event { get; set; }

        public IEnumerable<Event> Events { get; set; }

        [ForeignKey("EventResponse")]
        [Display(Name = "Response")]
        public int? ResponseID { get; set; }
        public EventResponse EventResponse { get; set; }

        public IEnumerable<EventResponse> EventResponses { get; set; }
    }
}