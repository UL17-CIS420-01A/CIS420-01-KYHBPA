using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

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
    }
}