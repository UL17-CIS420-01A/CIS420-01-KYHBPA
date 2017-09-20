using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using KYHBPA.Web.Infrastructure.Attributes;

namespace KYHBPA.Web.Models
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
        [MaximumFileSizeValidator(maximumFileSize: 2, ErrorMessage = "File size may not be larger than 2MB.")]
        [ValidFileTypeValidator(validFileTypes: new[] { "jpg", "png", "gif", "bmp" },
            ErrorMessage = "The file uploaded is not an accepted format. Please upload a jpg, png, gif, or bmp file.")]
        public HttpPostedFileBase ImageData { get; set; }
    }
}
