using System.ComponentModel.DataAnnotations;

namespace KYHBPA
{
    public class Document
    {
        [Required]
        public int Id { get; set; }
        public byte[] FileBytes { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        // Uploaded by
        public Member Member { get; set; }
    }
}