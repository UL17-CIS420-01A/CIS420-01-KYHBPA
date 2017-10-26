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
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextType = typeof(EntityDbContext);
            ContextKey = this.ContextType.FullName;
        }

        protected override void Seed(EntityDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            var logger = new MyLogger();
            context.Database.Log = s => logger.Log("EntityDbContextSeed", s);


            ApplicationUser user = new ApplicationUser
            {
                UserName = "Admin",
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
                    State = State.KY,
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
                result = new ApplicationUserManager(new ApplicationUserStore(context: context)).Create(user, "123456");
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
            user = context.Users.Include(o => o.Member).Single((o) => o.UserName == user.UserName);

            AspNetRole adminRole = new AspNetRole()
            {
                Name = "Administrator"
            };

            AspNetRole memberRole = new AspNetRole()
            {
                Name = "Member"
            };


            adminRole = context.Set<AspNetRole>().Add(adminRole);
            memberRole = context.Set<AspNetRole>().Add(memberRole);

            AspNetUserRole adminUsers = new AspNetUserRole();
            adminUsers.Role = adminRole;
            adminUsers.User = user;

            context.Set<AspNetUserRole>().AddOrUpdate(adminUsers);
            context.SaveChanges();

            //user.Roles.Add(adminUsers);

            string serverPath = System.Text.RegularExpressions.Regex.Replace(AppDomain.CurrentDomain.BaseDirectory,
                @"\\bin\\((Debug)|(Release))$", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            string pathToSeedFiles = System.IO.Path.Combine(serverPath, @"App_Data\Seed\");
            var homeIndexCarouselImage0 = System.Drawing.Image.FromFile($"{pathToSeedFiles}homeIndexCarousel0.jpg");
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
                    UploadedBy = user?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "Carousel",
                    IsInGallery = true,
                };

            var homeIndexCarouselImage1 = System.Drawing.Image.FromFile($"{pathToSeedFiles}homeIndexCarousel1.jpg");
            var homeIndexCarouselByteArray1 = homeIndexCarouselImage1.ToByteArray();
            var homeIndexCarouselPhoto1 =
                new Photo()
                {
                    Content = homeIndexCarouselByteArray1,
                    ContentLength = homeIndexCarouselByteArray1.Length,
                    ContentType = "image/jpeg",
                    PhotoName = "Churchill Downs Twin Spires",
                    Description = "View of the Churchill Downs track.",
                    UploadedBy = user?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "Carousel",
                    IsInGallery = true,
                };

            var homeIndexLegislationImage = System.Drawing.Image.FromFile($"{pathToSeedFiles}homeIndexLegislation.jpg");
            var homeIndexLegislationByteArray = homeIndexLegislationImage.ToByteArray();
            var homeIndexLegislationPhoto =
                new Photo()
                {
                    Content = homeIndexLegislationByteArray,
                    ContentLength = homeIndexLegislationByteArray.Length,
                    ContentType = "image/jpeg",
                    PhotoName = "Legislation",
                    Description = "Image showing the word 'legislation'.",
                    UploadedBy = user?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "Legislation",
                    IsInGallery = false,
                };

            var homeIndexEventsImage = System.Drawing.Image.FromFile($"{pathToSeedFiles}homeIndexEvents.jpg");
            var homeIndexEventsByteArray = homeIndexEventsImage.ToByteArray();
            var homeIndexEventsPhoto =
                new Photo()
                {
                    Content = homeIndexEventsByteArray,
                    ContentLength = homeIndexEventsByteArray.Length,
                    ContentType = "image/jpeg",
                    PhotoName = "Events",
                    Description = "Image showing the Kentucky Derby race event.",
                    UploadedBy = user?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "Events",
                    IsInGallery = false,
                };

            var homeIndexNewsImage = System.Drawing.Image.FromFile($"{pathToSeedFiles}homeIndexNews.jpg");
            var homeIndexNewsByteArray = homeIndexNewsImage.ToByteArray();
            var homeIndexNewsPhoto =
                new Photo()
                {
                    Content = homeIndexNewsByteArray,
                    ContentLength = homeIndexNewsByteArray.Length,
                    ContentType = "image/jpeg",
                    PhotoName = "News",
                    Description = "Image of a newspaper.",
                    UploadedBy = user?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = "News",
                    IsInGallery = false,
                };

            var carouselCollection = new PhotoCollection("Carousel", new List<Photo>(), 5);
            var legislationCollection = new PhotoCollection("Legislation", new List<Photo>());
            var eventsCollection = new PhotoCollection("Events", new List<Photo>());
            var newsCollection = new PhotoCollection("News", new List<Photo>());

            context.PhotoCollections.Add(carouselCollection);
            context.SaveChanges();
            context.PhotoCollections.Add(legislationCollection);
            context.SaveChanges();
            context.PhotoCollections.Add(eventsCollection);
            context.SaveChanges();
            context.PhotoCollections.Add(newsCollection);
            context.SaveChanges();

            context.Photos.Add(homeIndexCarouselPhoto0);
            context.SaveChanges();
            context.Photos.Add(homeIndexCarouselPhoto1);
            context.SaveChanges();
            context.Photos.Add(homeIndexLegislationPhoto);
            context.SaveChanges();
            context.Photos.Add(homeIndexEventsPhoto);
            context.SaveChanges();
            context.Photos.Add(homeIndexNewsPhoto);
            context.SaveChanges();

            //var homeIndexCarouselPhotos = new List<Photo>()
            //{
            //    homeIndexCarouselPhoto0,
            //    homeIndexCarouselPhoto1,
            //};
            //var homeIndexLegislationPhotos = new List<Photo>()
            //{
            //    homeIndexLegislationPhoto,
            //};
            //var homeIndexEventsPhotos = new List<Photo>()
            //{
            //    homeIndexEventsPhoto,
            //};
            //var homeIndexNewsPhotos = new List<Photo>()
            //{
            //    homeIndexNewsPhoto,
            //};

            //var homeIndexCarousel = new PhotoCollection(homeIndexCarouselPhotos, "Carousel", 5);
            //var homeIndexLegislation = new PhotoCollection(homeIndexLegislationPhotos, "Legislation");
            //var homeIndexEvents = new PhotoCollection(homeIndexEventsPhotos, "Events");
            //var homeIndexNews = new PhotoCollection(homeIndexNewsPhotos, "News");

            //var photoCollections = new List<PhotoCollection>
            //{
            //    homeIndexCarousel,
            //    homeIndexLegislation,
            //    homeIndexEvents,
            //    homeIndexNews
            //};

            //context.PhotoCollections.AddRange(photoCollections);
            //context.SaveChanges();
        }

        public void InitializeDatabase(EntityDbContext context)
        {
            Seed(context);
        }
    }
}
