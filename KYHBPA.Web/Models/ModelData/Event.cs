using System;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Web.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}