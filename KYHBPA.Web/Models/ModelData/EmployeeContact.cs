using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Web.Models
{
    public class EmployeeContact
    {
        [Required]
        public int Id { get; set; }
        public Member Member { get; set; }
        public string Email { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
    }
}