namespace KYHBPA.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KYHBPA.Data.Entity;
    using KYHBPA.Data.Infrastructure;

    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(Entities context) : base(context)
        {
        }

        public async Task<AspNetUser> FindByIdAsync(Guid userId)
        {
            return await new Task<AspNetUser>(() => FindById(userId));
        }

        public async Task<AspNetUser> FindByUsernameAsync(string userName)
        {
            return await new Task<AspNetUser>(() => FindByUsername(userName));
        }

        public AspNetUser FindById(Guid userId)
        {
            return context.AspNetUsers.AsNoTracking().SingleOrDefault(o => Guid.Parse(o.Id) == userId);
        }

        public AspNetUser FindByUsername(string userName)
        {
            return context.AspNetUsers.AsNoTracking().SingleOrDefault(o => o.UserName == userName.ToString());
        }

        public List<AspNetUser> FindUsers()
        {
            return context.AspNetUsers.AsNoTracking().ToList();
        }

        public bool IsInRole(string role, Guid userId)
        {
            return FindUsers().Any(u => u.AspNetRoles.Any(r => r.Name == role));
        }

        public bool IsInRole(AspNetRole role, Guid userId)
        {
            return FindUsers().Any(u => u.AspNetRoles.Any(r => r.Name == role.Name));
        }
    }
}
