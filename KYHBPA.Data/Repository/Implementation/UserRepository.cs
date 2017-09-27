namespace KYHBPA.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KYHBPA.Data.Infrastructure;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserRepository : BaseRepository<ApplicationUser, string>, IUserRepository
    {
        public UserRepository(EntityDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> FindByUsernameAsync(string userName)
        {
            return await new Task<ApplicationUser>(() => FindByUsername(userName));
        }

        public override ApplicationUser FindById(string id)
        {
            var applicationUser = Context.Users.AsNoTracking()
                .SingleOrDefault(o => o.Id.ToString() == id);
            //var member = Context.Users.Select(o =>
            //      new BaseRepository<Entity.AspNetUser, string>(Context).FindById(id).Member
            //).SingleOrDefault(o => o.Id.ToString() == applicationUser.Id);
            //applicationUser.Member = member.ToDomain();
            return applicationUser;
        }

        public ApplicationUser FindByUsername(string userName)
        {
            return Context.Users.AsNoTracking().SingleOrDefault(o => o.UserName == userName.ToString());
        }

        public List<ApplicationUser> FindUsers()
        {
            return Context.Users.AsNoTracking().ToList();
        }

        public bool? IsInRole(string role, string id)
        {
            return FindById(id)?.Roles.Any(r => r.RoleId == role);
        }

        public bool? IsInRole(IdentityUserRole<string> role, string id)
        {
            return FindById(id)?.Roles.Any(r => r.RoleId == role.RoleId);
        }
    }
}
