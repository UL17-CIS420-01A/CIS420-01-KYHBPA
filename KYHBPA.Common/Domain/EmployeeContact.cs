using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYHBPA
{
    public class EmployeeContact
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Member Member { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactSubject { get; set; }
        [Required]
        public string ContactMessage { get; set; }
    }
}