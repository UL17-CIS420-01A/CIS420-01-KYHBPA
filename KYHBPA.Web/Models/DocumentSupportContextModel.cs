using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class DocumentSupportContextModel : DbContext
        : base("name=DefaultConnection")
    {
    }
    public DbSet<DocumentSupportViewModel> Supports { get; set; }
    public DbSet<DocumentFileDetailViewModel> FileDetails { get; set; }
}