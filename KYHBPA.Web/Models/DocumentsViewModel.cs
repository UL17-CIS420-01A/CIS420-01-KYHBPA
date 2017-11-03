using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using KYHBPA.ActionResults;

namespace KYHBPA.Models
{
    public class DocumentsListViewModel
    {
        public ApplicationUser CurrentUser { get; set; }

        public IEnumerable<Guid> Ids { get; set; }
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
        public string Descritpion { get; set; }

        [Display(Name = "Show in list?")]
        [DefaultValue(true)]
        public bool IsInList { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase DocumentData { get; set; }

        [Display(Name = "Include in Collection")]
        public string DocumentCollectionKey { get; set; }

        public IEnumerable<SelectListItem> DocumentKeys { get; set; }
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

        public Member UploadedBy { get; set; }
        public DateTime Uploaded { get; set; }
        public Member LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public Member DeletedBy { get; set; }
        public DateTime? Deleted { get; set; }

        [Display(Name = "Show in list?")]
        public bool IsInList { get; set; }

        [Display(Name = "Collection:")]
        public string DocumentCollectionKey { get; set; }
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

        [Display(Name = "Show in list?")]
        public bool IsInList { get; set; }

        public IEnumerable<SelectListItem> DocumentKeys { get; set; }
    }
}