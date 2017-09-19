using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Web.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        public Member Member { get; set; }
        public string JobTitle { get; set; }
    }
}