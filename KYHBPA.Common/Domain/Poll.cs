using System.ComponentModel.DataAnnotations;

namespace KYHBPA
{
    public class Poll
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}