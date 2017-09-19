using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Web.Models
{
    public class Poll
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}