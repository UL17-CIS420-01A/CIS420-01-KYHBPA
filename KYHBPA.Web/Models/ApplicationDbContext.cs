using System.Data.Entity;
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

        public override IDbSet<ApplicationUser> Users { get; set; }
        public IDbSet<Document> Documents { get; set; }
        public IDbSet<Event> Events { get; set; }
        public IDbSet<Poll> Polls { get; set; }
    }
}