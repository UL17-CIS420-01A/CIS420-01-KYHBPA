using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

// ReSharper disable once CheckNamespace
namespace KYHBPA
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
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<EmployeeContact> EmployeeContacts { get; set; }
        public IDbSet<Event> Events { get; set; }
        public IDbSet<EventFeedback> EventFeedback {get;set; }
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Poll> Polls { get; set; }
        public IDbSet<PollQuestion> PollQuestions { get; set; }
        public IDbSet<PollResponse> PollResponses { get; set; }
    }
}