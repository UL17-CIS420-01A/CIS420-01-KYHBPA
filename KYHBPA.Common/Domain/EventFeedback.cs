using System.ComponentModel.DataAnnotations;

namespace KYHBPA
{
    public class EventFeedback
    {
        [Required]
        public int Id { get; set; }
        public Event Event { get; set; }
        public Member Member { get; set; }
        public string Comments { get; set; }
    }
}