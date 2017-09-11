using Microsoft.AspNet.Identity.EntityFramework;

namespace KYHBPA.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<KYHBPA.Web.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}