using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYHBPA
{
    public class Document
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public byte[] FileBytes { get; set; }
        [Required]
        public int ContentLength { get; set; }
        [Required]
        public string ContentType { get; set; }
        [Required]
        public string FileName { get; set; }
        // Uploaded by
        public Member Member { get; set; }
    }
}