using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using KYHBPA.Entity;

namespace KYHBPA.Repository.Implementation
{
    public class UserRepository : BaseRepository<ApplicationUser, Guid>, IUserRepository
    {
        public UserRepository(EntityDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> FindByUsernameAsync(string userName)
        {
            return await new Task<ApplicationUser>(() => FindByUsername(userName));
        }

        public override ApplicationUser FindById(Guid id) => id.IsEmpty() ? null : Context.Users.AsNoTracking()
            .Include(o => o.Member)
            .SingleOrDefault(o => o.Id == id);

        public ApplicationUser FindByUsername(string userName) => Context.Users.AsNoTracking()
            .Include(o => o.Member)
            .SingleOrDefault(o => o.UserName == userName.ToString());

        public List<ApplicationUser> FindUsers() => 
            Context.Users.AsNoTracking()
            .Include(o => o.Member).ToList();

        public bool? IsInRole(Guid roleId, Guid userId) => 
            FindById(userId)?.Roles.Any(r => r.RoleId == roleId);

        public bool? IsInRole(AspNetUserRole role, Guid userId) => FindById(userId)?.Roles.Any(r => r.RoleId == role.RoleId);
    }
}
