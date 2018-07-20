using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Program
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Program")]
        public string Service { get; set; }

    }
}