using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using KYHBPA.Web.Infrastructure.Attributes;

namespace KYHBPA.Web.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public Member Uploader { get; set; }
        // Associated Event
        public Event Event { get; set; }
        public byte[] Content { get; set; }
        public string PhotoName { get; set; }
        public string Description { get; set; }
        //[MaximumFileSizeValidator(maximumFileSize: 2, ErrorMessage = "File size may not be larger than 2MB.")]
        //[ValidFileTypeValidator(validFileTypes: new[] { "jpg", "png", "gif", "bmp" },
        //    ErrorMessage = "The file uploaded is not an accepted format. Please upload a jpg, png, gif, or bmp file.")]
        //public HttpPostedFileBase ImageData { get; set; }
    }
}