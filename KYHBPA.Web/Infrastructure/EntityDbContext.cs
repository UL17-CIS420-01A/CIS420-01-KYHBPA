using System.Data.Entity;
using KYHBPA.Entity;
using KYHBPA.EntityMappers;

namespace KYHBPA
{
    public class EntityDbContext : DbContext
    {

        private EntityDbContext() : base("DefaultConnection")
        {
            var logger = new MyLogger();
            Database.Log = s => logger.Log("EntityDbContext", s);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static EntityDbContext Create()
        {
            var result = new EntityDbContext();
            return result;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMapper());

            //modelBuilder.Entity<ApplicationUser>()
            //    .ToTable("Users");
            //modelBuilder.Entity<AspNetUserRole>()
            //    .ToTable("UserRoles");
            //modelBuilder.Entity<AspNetUserClaim>()
            //    .ToTable("UserClaims");
            modelBuilder.Entity<AspNetUserRole>()
                .HasRequired(c => c.Role)
                .WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<AspNetUserRole>()
                .HasRequired(c => c.User)
                .WithMany()
                .WillCascadeOnDelete(true);
            //modelBuilder.Entity<AspNetRole>()
            //    .HasOptional(s => s.Users)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);
            modelBuilder.Entity<AspNetUserLogin>()
                .HasKey((obj) => new {obj.LoginProvider, obj.ProviderKey, obj.UserId});
                //.ToTable("UserLogins");
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ApplicationUser> Users { get; set; }
        //public virtual DbSet<IdentityUserRole> Roles { get; set; }
        //public virtual DbSet<AspNetUserClaim> UserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> UserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> UserRoles { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeContact> EmployeeContacts { get; set; }
        public virtual DbSet<PhotoCollection> PhotoCollections { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventFeedback> EventFeedback { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Poll> Polls { get; set; }
        public virtual DbSet<PollQuestion> PollQuestions { get; set; }
        public virtual DbSet<PollResponse> PollResponses { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
    }
}
