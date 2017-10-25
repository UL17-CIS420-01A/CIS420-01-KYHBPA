using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class EventFeedbackViewModel
    {
        [Required]
        public Guid Id { get; set; }
        public Event Event { get; set; }
        public Member Member { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}