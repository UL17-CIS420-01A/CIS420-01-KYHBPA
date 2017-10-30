using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using KYHBPA.ActionResults;

namespace KYHBPA.Models
{
    public class DocumentsViewModel
    {        
        public int ID { get; set; }
        public string Extension { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}