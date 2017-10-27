using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using Google.Apis.Util;
using KYHBPA.Entity;
using KYHBPA.Models;
using KYHBPA.EntityMappers;

namespace KYHBPA
{
    public class EntityDbContext : DbContext
    {

        public EntityDbContext() : base("DefaultConnection")
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
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //        System.Diagnostics.Debugger.Launch();

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            //modelBuilder.Entity<ApplicationUser>()
            //    .ToTable("Users");
            //modelBuilder.Entity<AspNetUserClaim>()
            //    .ToTable("UserClaims");
            modelBuilder.Entity<UserLogin>()
                .HasKey((obj) => new {obj.LoginProvider, obj.ProviderKey, obj.UserId});
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
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
