using System.ComponentModel.DataAnnotations;

namespace KYHBPA
{
    public class EmployeeContact
    {
        [Required]
        public int Id { get; set; }
        public Member Member { get; set; }
        public string Email { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
    }
}