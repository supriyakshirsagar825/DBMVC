using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBMVC.Models
{
    public class student
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int city { get; set; }

        public HttpPostedFileBase file { get; set; }
    }
}