using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Web.Models
{
    public class EventFeedback
    {
        [Required]
        public int Id { get; set; }
        public Event Event { get; set; }
        public Member Member { get; set; }
        public String Comments { get; set; }
    }
}