using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYHBPA
{
    [Table("Photos", Schema = "Photo")]
    public class Photo
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string PhotoName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public byte[] Content { get; set; }
        [Required]
        public int ContentLength { get; set; }
        [Required]
        public string ContentType { get; set; }

        [Required]
        public Member UploadedBy { get; set; }
        [Required]
        public DateTime Uploaded { get; set; }
        public Member LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public Member DeletedBy { get; set; }
        public DateTime? Deleted { get; set; }

        public bool IsInGallery { get; set; }

        [ForeignKey(nameof(PhotoCollection))]
        public string PhotoCollectionKey { get; set; }
        public PhotoCollection PhotoCollection { get; set; }

        //public Event Event { get; set; }
    }
}