namespace KYHBPA.Data.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class EntityDbContext : IdentityDbContext<ApplicationUser>
    {

        private EntityDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }
        
        public DbSet<Member> Members { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeContact> EmployeeContacts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventFeedback> EventFeedback { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollQuestion> PollQuestions { get; set; }
        public DbSet<PollResponse> PollResponses { get; set; }
        public DbSet<Survey> Surveys { get; set; }


        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}
