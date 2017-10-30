using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class DocumentFileDetailViewModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int SupportId { get; set; }
        public virtual DocumentSupportViewModel Support { get; set; }
    }
}