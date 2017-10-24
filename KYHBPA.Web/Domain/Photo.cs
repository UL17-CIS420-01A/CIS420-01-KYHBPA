using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core;

namespace KYHBPA
{
    public class Photo
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Event Event { get; set; }
        [Required]
        public string PhotoName { get; set; }
        [Required]
        public string Description { get; set; }
        public byte[] Content { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }

        public Member UploadedBy { get; set; }
        public DateTime Uploaded { get; set; }
        public Member LastModifiedBy { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public Member DeletedBy { get; set; }
        public DateTime? Deleted { get; set; }
        
        public IEnumerable<PhotoCollection> PhotoCollection { get; set; }
    }
}