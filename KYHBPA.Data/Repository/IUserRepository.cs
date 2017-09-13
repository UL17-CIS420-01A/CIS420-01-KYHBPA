using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KYHBPA.Data.Entity;
using KYHBPA.Data.Repository;

namespace KYHBPA.Data.Repository
{
    public interface IUserRepository : IRepository<AspNetUser, string>
    {
        Task<AspNetUser> FindByUsernameAsync(string userName);
        AspNetUser FindByUsername(string userName);
        List<AspNetUser> FindUsers();
        bool IsInRole(string role, string id);
        bool IsInRole(AspNetRole role, string id);
    }
}