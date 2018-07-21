using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Agency
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Settlement Agency")]
        public string Settlement { get; set; }
    }
}