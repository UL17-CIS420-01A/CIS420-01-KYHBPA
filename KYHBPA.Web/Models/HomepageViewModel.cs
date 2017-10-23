using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using KYHBPA.Web.ActionResults;

namespace KYHBPA.Web.Models
{
    public class HomepageViewModel
    {
        public List<Guid> CarouselIds { get; set; }
        public Guid EventsImageId { get; set; }
        public Guid NewsImageId { get; set; }
        public Guid LegislationImageId { get; set; }
    }
}