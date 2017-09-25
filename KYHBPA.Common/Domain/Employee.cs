using System.ComponentModel.DataAnnotations;

namespace KYHBPA
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        public Member Member { get; set; }
        public string JobTitle { get; set; }
    }
}