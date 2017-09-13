using System;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Web.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}