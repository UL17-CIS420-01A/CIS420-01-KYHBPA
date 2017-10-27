using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KYHBPA.Entity;

namespace KYHBPA.Repository
{
    public interface IUserRepository : IRepository<ApplicationUser, Guid>
    {
        Task<ApplicationUser> FindByUsernameAsync(string userName);
        ApplicationUser FindByUsername(string userName);
        List<ApplicationUser> FindUsers();
        bool? IsInRole(Guid roleId, Guid userId);
        bool? IsInRole(UserRole role, Guid userId);
    }
}