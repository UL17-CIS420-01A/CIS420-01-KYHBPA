using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using KYHBPA.ActionResults;

namespace KYHBPA.Models
{
    public class UploadPhotoViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Photo Name")]
        public string PhotoName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        //[Required]
        [DataType(DataType.Upload)]
        [MaximumFileSizeValidator(maximumFileSize: 5, ErrorMessage = "File size may not be larger than 5MB.")]
        [ValidFileTypeValidator(validFileTypes: new[] { "jpg", "png", "gif", "bmp" },
            ErrorMessage = "The image uploaded is not an accepted format. Please upload a jpg, png, gif, or bmp file.")]
        public HttpPostedFileBase ImageData { get; set; }

        public string PhotoKey { get; set; }

        public IEnumerable<string> PhotoKeys { get; set; }
    }
    public class EditPhotoViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Photo Name")]
        public string PhotoName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public ImageResult ImageData { get; set; }

        public string PhotoKey { get; set; }

        public IEnumerable<string> PhotoKeys { get; set; }
    }
    public class PhotoViewModel
    {
        public ApplicationUser CurrentUser { get; set; }

        public IEnumerable<Guid> Ids { get; set; }
    }
}
