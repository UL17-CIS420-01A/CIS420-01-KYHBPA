using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KYHBPA.Data.Repository
{
    public interface IUserRepository : IRepository<ApplicationUser, string>
    {
        Task<ApplicationUser> FindByUsernameAsync(string userName);
        ApplicationUser FindByUsername(string userName);
        List<ApplicationUser> FindUsers();
        bool? IsInRole(string role, string id);
        bool? IsInRole(IdentityUserRole<string> role, string id);
    }
}