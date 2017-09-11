using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KYHBPA.Data.Entity;

namespace KYHBPA.Data.Repository
{
    public interface IUserRepository
    {
        Task<AspNetUser> FindByIdAsync(Guid userId);
        Task<AspNetUser> FindByUsernameAsync(string userName);
        AspNetUser FindById(Guid userId);
        AspNetUser FindByUsername(string userName);
        List<AspNetUser> FindUsers();
        bool IsInRole(string role, Guid userId);
        bool IsInRole(AspNetRole role, Guid userId);
    }
}