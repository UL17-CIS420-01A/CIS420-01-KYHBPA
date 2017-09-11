using System;
using System.Collections.Generic;
using KYHBPA.Data.Entity;

namespace KYHBPA.Data.Repository
{
    public interface IUserRepository
    {
        AspNetUser FindUser(Guid userId);
        AspNetUser FindUser(string userName);
        List<AspNetUser> FindUsers();
        bool IsInRole(string role, Guid userId);
    }
}