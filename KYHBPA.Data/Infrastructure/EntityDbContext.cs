using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using KYHBPA.Data.Infrastructure.Interceptor;
using KYHBPA.Entity;

namespace KYHBPA.Data.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EntityDbContext : DbContext
    {

        private EntityDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            DbInterception.Add(new SoftDeleteInterceptor());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }

        // Domain Model
        // ... other custom DbSets

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AspNetUserRole>()
            //    .HasKey((obj) => new { obj.RoleId, obj.UserId });
            //modelBuilder.Entity<AspNetUserLogin>()
            //    .HasKey((obj) => new { obj.LoginProvider, obj.ProviderKey, obj.UserId });
            var conv = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                "SoftDeleteColumnName",
                (type, attributes) => attributes.Single().ColumnName);
            modelBuilder.Conventions.Add(conv);

            var userTable = modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");
            //modelBuilder.Entity<AspNetRole>()
            //    .ToTable("Roles");
            modelBuilder.Entity<AspNetUserRole>()
                //.HasKey((obj) => new { obj.RoleId, obj.UserId })
                .ToTable("UserRoles");
            modelBuilder.Entity<AspNetUserClaim>()
                //.HasKey((obj) => new { obj.Id, obj.UserId })
                .ToTable("UserClaims");
            //.Map((obj)=>obj.HasTableAnnotation("",));
            modelBuilder.Entity<AspNetUserLogin>()
                .HasKey((obj) => new { obj.LoginProvider, obj.ProviderKey, obj.UserId })
                .ToTable("UserLogins");
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Document>().ToTable("Documents");
            //modelBuilder.Entity<Employee>().ToTable("Employees");
            //modelBuilder.Entity<EmployeeContact>().ToTable("EmployeeContacts");
            //modelBuilder.Entity<Event>().ToTable("Events");
            //modelBuilder.Entity<EventFeedback>().ToTable("EventFeedback");
            //modelBuilder.Entity<Photo>().ToTable("Photos");
            //modelBuilder.Entity<Poll>().ToTable("Polls");
            //modelBuilder.Entity<PollQuestion>().ToTable("PollQuestions");
            //modelBuilder.Entity<PollResponse>().ToTable("PollResponses");
            //modelBuilder.Entity<Survey>().ToTable("Surveys");
            //modelBuilder.Entity<User>().ToTable("ApplicationUsers");
            //modelBuilder.Entity<AspNetRole>().ToTable("AspNetRoles");
            //modelBuilder.Entity<AspNetUserClaim>().ToTable("AspNetUserClaims");
            //modelBuilder.Entity<AspNetUserLogin>().ToTable("AspNetUserLogins");
            //modelBuilder.Entity<AspNetUserRole>().ToTable("UserRoles");
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
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventFeedback> EventFeedback { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Poll> Polls { get; set; }
        public virtual DbSet<PollQuestion> PollQuestions { get; set; }
        public virtual DbSet<PollResponse> PollResponses { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
    }
}
