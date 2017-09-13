using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Web.Models
{
    public class Document
    {
        [Required]
        public int Id { get; set; }
        public byte[] FileBytes { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string UploadedBy { get; set; }
    }
}