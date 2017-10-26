using KYHBPA.Entity;
using static AutoMapper.Mapper;

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

        //if (result.IsNull())
        //    return null;
        //result.Member = Context.Members.Single(o => o.Id == result.Member_Id);
        public ApplicationUser FindByUsername(string userName) => Context.Users.AsNoTracking()
            .Include(o => o.Member)
            .SingleOrDefault(o => o.UserName == userName.ToString());

        public List<ApplicationUser> FindUsers() => Context.Users.AsNoTracking()
            .Include(o => o.Member).ToList();

        public bool? IsInRole(Guid role, Guid id) => FindById(id)?.Roles.Any(r => r.RoleId == role);

        public bool? IsInRole(AspNetUserRole role, Guid id) => FindById(id)?.Roles.Any(r => r.RoleId == role.RoleId);

        //private ApplicationUser FindApplicationUserByAspNetUser(ApplicationUser ApplicationUser)
        //{
        //    ApplicationUser applicationUser = Map(ApplicationUser, new ApplicationUser());
        //    applicationUser.Member = Map(Context.Members.Single(o => ApplicationUser.Member_Id == o.Id), new Member());
        //    return applicationUser;
        //}
    }
}
