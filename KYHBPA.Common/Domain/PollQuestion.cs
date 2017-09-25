using System.ComponentModel.DataAnnotations;

namespace KYHBPA
{
    public class PollQuestion
    {
        [Required]
        public int Id { get; set; }
        public Poll Poll { get; set; }
        public string Message { get; set; }
    }
}