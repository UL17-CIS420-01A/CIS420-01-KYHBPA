using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Web.Models
{
    public class PollResponse
    {
        [Required]
        public int Id { get; set; }
        public PollQuestion PollQuestion { get; set; }
        public Member Member { get; set; }
        public string Message { get; set; }
    }
}