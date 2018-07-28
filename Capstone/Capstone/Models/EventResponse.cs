using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class EventResponse
    {
        [Key]
        public int ID { get; set; }
        public string Response { get; set; }

    }
}