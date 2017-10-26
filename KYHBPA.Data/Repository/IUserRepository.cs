using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KYHBPA.Entity;

namespace KYHBPA.Data.Repository
{
    public interface IUserRepository : IRepository<ApplicationUser, Guid>
    {
        Task<ApplicationUser> FindByUsernameAsync(string userName);
        ApplicationUser FindByUsername(string userName);
        List<ApplicationUser> FindUsers();
        bool? IsInRole(Guid role, Guid id);
        bool? IsInRole(AspNetUserRole role, Guid id);
    }
}