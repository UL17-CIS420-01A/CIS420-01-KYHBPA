using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using KYHBPA.Web.ActionResults;

namespace KYHBPA.Web.Models
{
    public class HomepageViewModel
    {
        public List<byte[]> CarouselBytes { get; set; }
        public byte[] EventsImage { get; set; }
        public byte[] NewsImage { get; set; }
        public byte[] LegislationImage { get; set; }
    }
}