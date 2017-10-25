using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYHBPA
{
    public class PollQuestion
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Poll Poll { get; set; }
        [Required]
        public string Message { get; set; }
    }
}