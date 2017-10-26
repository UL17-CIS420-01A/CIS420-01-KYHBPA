using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYHBPA
{
    public class PollResponse
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public PollQuestion PollQuestion { get; set; }
        public Member Member { get; set; }
        [Required]
        public string Message { get; set; }
    }
}