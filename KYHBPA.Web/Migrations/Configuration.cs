using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using KYHBPA.Entity;
using Microsoft.AspNet.Identity;

namespace KYHBPA.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityDbContext>, IDatabaseInitializer<EntityDbContext>
    {

        private static readonly string ServerPath = System.Text.RegularExpressions.Regex.Replace(AppDomain.CurrentDomain.BaseDirectory,
            @"\\bin\\((Debug)|(Release))$", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        private static readonly string PathToSeedFiles = System.IO.Path.Combine(ServerPath, @"App_Data\Seed\");
        private ApplicationUser KYHBPAAdministrator { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextType = typeof(EntityDbContext);
            ContextKey = this.ContextType.FullName;
        }

        public void InitializeDatabase(EntityDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            var logger = new MyLogger();
            context.Database.Log = s => logger.Log("EntityDbContextSeed", s);

            Seed(context);
        }

        protected override void Seed(EntityDbContext context)
        {
            SeedUsers(context);

            var homeIndexCarouselImage0 = System.Drawing.Image.FromFile($"{PathToSeedFiles}homeIndexCarousel0.jpg");
            var homeIndexCarouselByteArray0 = homeIndexCarouselImage0.ToByteArray();
            var homeIndexCarouselPhoto0 =
                new Photo()
                {
                    Content = homeIndexCarouselByteArray0,
                    ContentLength = homeIndexCarouselByteArray0.Length,
                    ContentType = "image/jpeg",
                    PhotoName = "Kentucky Derby Museum",
                    Description =
                        "The Kentucky Derby Museum is one of the premiere attractions in the Louisville region, celebrating the tradition, history, hospitality and pride of the world-renown event that is the Kentucky Derby.",
                    UploadedBy = this.KYHBPAAdministrator?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "Carousel",
                    IsInGallery = true,
                };

            var homeIndexCarouselImage1 = System.Drawing.Image.FromFile($"{PathToSeedFiles}homeIndexCarousel1.jpg");
            var homeIndexCarouselByteArray1 = homeIndexCarouselImage1.ToByteArray();
            var homeIndexCarouselPhoto1 =
                new Photo()
                {
                    Content = homeIndexCarouselByteArray1,
                    ContentLength = homeIndexCarouselByteArray1.Length,
                    ContentType = "image/jpeg",
                    PhotoName = "Churchill Downs Twin Spires",
                    Description = "View of the Churchill Downs track.",
                    UploadedBy = this.KYHBPAAdministrator?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "Carousel",
                    IsInGallery = true,
                };

            //var homeIndexLegislationImage = System.Drawing.Image.FromFile($"{PathToSeedFiles}homeIndexLegislation.jpg");
            //var homeIndexLegislationByteArray = homeIndexLegislationImage.ToByteArray();
            //var homeIndexLegislationPhoto =
            //    new Photo()
            //    {
            //        Content = homeIndexLegislationByteArray,
            //        ContentLength = homeIndexLegislationByteArray.Length,
            //        ContentType = "image/jpeg",
            //        PhotoName = "Legislation",
            //        Description = "Image showing the word 'legislation'.",
            //        UploadedBy = this.KYHBPAAdministrator?.Member,
            //        Uploaded = DateTime.UtcNow,
            //        PhotoCollectionKey = "Legislation",
            //        IsInGallery = false,
            //    };

            var homeIndexEventsImage = System.Drawing.Image.FromFile($"{PathToSeedFiles}homeIndexEvents.jpg");
            var homeIndexEventsByteArray = homeIndexEventsImage.ToByteArray();
            var homeIndexEventsPhoto =
                new Photo()
                {
                    Content = homeIndexEventsByteArray,
                    ContentLength = homeIndexEventsByteArray.Length,
                    ContentType = "image/jpeg",
                    PhotoName = "Events",
                    Description = "Image showing the Kentucky Derby race event.",
                    UploadedBy = this.KYHBPAAdministrator?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "Events",
                    IsInGallery = false,
                };

            var homeIndexNewsImage = System.Drawing.Image.FromFile($"{PathToSeedFiles}homeIndexNews.jpg");
            var homeIndexNewsByteArray = homeIndexNewsImage.ToByteArray();
            var homeIndexNewsPhoto =
                new Photo()
                {
                    Content = homeIndexNewsByteArray,
                    ContentLength = homeIndexNewsByteArray.Length,
                    ContentType = "image/jpeg",
                    PhotoName = "News",
                    Description = "Image of a newspaper.",
                    UploadedBy = this.KYHBPAAdministrator?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "News",
                    IsInGallery = false,
                };

            var carouselCollection = new PhotoCollection("Carousel", new List<Photo>(), 5);
            //var legislationCollection = new PhotoCollection("Legislation", new List<Photo>());
            var eventsCollection = new PhotoCollection("Events", new List<Photo>());
            var newsCollection = new PhotoCollection("News", new List<Photo>());

            context.PhotoCollections.Add(carouselCollection);
            context.SaveChanges();
            //context.PhotoCollections.Add(legislationCollection);
            //context.SaveChanges();
            context.PhotoCollections.Add(eventsCollection);
            context.SaveChanges();
            context.PhotoCollections.Add(newsCollection);
            context.SaveChanges();

            context.Photos.Add(homeIndexCarouselPhoto0);
            context.SaveChanges();
            context.Photos.Add(homeIndexCarouselPhoto1);
            context.SaveChanges();
            //context.Photos.Add(homeIndexLegislationPhoto);
            //context.SaveChanges();
            context.Photos.Add(homeIndexEventsPhoto);
            context.SaveChanges();
            context.Photos.Add(homeIndexNewsPhoto);
            context.SaveChanges();            
        }

        private void SeedUsers(EntityDbContext context)
        {
            KYHBPAAdministrator = context.Users.Include(o => o.Member).SingleOrDefault(o => o.UserName == "kentuckyhbpa@gmail.com");
            if (KYHBPAAdministrator == null)
            {
                KYHBPAAdministrator = new ApplicationUser
                {
                    UserName = "kentuckyhbpa@gmail.com",
                    Email = "kentuckyhbpa@gmail.com",
                    PhoneNumber = "5023631077",
                    Member = new Member()
                    {
                        Email = "kentuckyhbpa@gmail.com",
                        FirstName = "KYHBPA",
                        LastName = "Administrator",
                        DateOfBirth = new DateTime(1940, 1, 1),
                        PhoneNumber = "5023631077",
                        Address = "3729 S. Fourth St.",
                        City = "Louisville",
                        State = States.KY,
                        ZipCode = "40214-1712",
                        LicenseNumber = "Administrator",
                        IsOwner = false,
                        IsTrainer = false,
                        Signature = "KYHBPA Administrator",
                        AgreedToTerms = true,
                        MembershipEnrollment = new DateTime(1940, 1, 1),
                    },
                };


                IdentityResult result = new IdentityResult();
                try
                {
                    result = new ApplicationUserManager(new ApplicationUserStore(context: context)).Create(KYHBPAAdministrator,
                        "ILoveHorses"); // In production, password should be changed immediately.
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                }
                KYHBPAAdministrator = context.Users.Include(o => o.Member).Single((o) => o.UserName == KYHBPAAdministrator.UserName);
            }

            Role adminRole = context.Set<Role>().SingleOrDefault(role => role.Name == Roles.Administrator.ToString());
            Role memberRole = context.Set<Role>().SingleOrDefault(role => role.Name == Roles.Member.ToString());
            if (adminRole.IsNull())
            {
                adminRole = new Role()
                {
                    Name = Roles.Administrator.ToString()
                };
                adminRole = context.Set<Role>().Add(adminRole);
            }
            if (memberRole.IsNull())
            {
                memberRole = new Role()
                {
                    Name = Roles.Member.ToString()
                };
                memberRole = context.Set<Role>().Add(memberRole);
            }

            UserRole userAdmin =
                context.Set<UserRole>().SingleOrDefault(userRole =>
                userRole.UserId == KYHBPAAdministrator.Id &&
                userRole.RoleId == adminRole.Id);
            if (userAdmin.IsNull())
            {
                userAdmin = new UserRole
                {
                    Role = adminRole,
                    User = KYHBPAAdministrator
                };

                userAdmin = context.Set<UserRole>().Add(userAdmin);
                context.SaveChanges();
            }

        }
    }
}
