using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class DocumentsViewModels
    {
    }

    public class DocumentUploadViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /* [Display(Name = "Show in gallery?")]
         [DefaultValue(true)]
         public bool IsInGallery { get; set; } */

        /* [Required]
         [DataType(DataType.Upload)]
         [MaximumFileSizeValidator(maximumFileSize: 5, ErrorMessage = "File size may not be larger than 5MB.")]
         [ValidFileTypeValidator(validFileTypes: new[] { "jpg", "png", "gif", "bmp" },
             ErrorMessage = "The image uploaded is not an accepted format. Please upload a jpg, png, gif, or bmp file.")]
         public HttpPostedFileBase ImageData { get; set; } */

        [Display(Name = "Include in Collection:")]
        public string PhotoCollectionKey { get; set; }

        public IEnumerable<SelectListItem> PhotoKeys { get; set; }
    }

    public class DocumentDetailedViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        //public Member UploadedBy { get; set; }
        public DateTime Uploaded { get; set; }
        // public Member LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; }
        // public Member DeletedBy { get; set; }
        public DateTime? Deleted { get; set; }

        /*[Display(Name = "Show in gallery?")]
        public bool IsInGallery { get; set; }

        [Display(Name = "Collection:")]
        public string PhotoCollectionKey { get; set; }*/
    }

    public class DocumentEditViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /* [Display(Name = "Show in gallery?")]
         public bool IsInGallery { get; set; }

         [Display(Name = "Include in Collection:")]
         public string PhotoCollectionKey { get; set; }

         public IEnumerable<SelectListItem> PhotoKeys { get; set; }*/
    }
}