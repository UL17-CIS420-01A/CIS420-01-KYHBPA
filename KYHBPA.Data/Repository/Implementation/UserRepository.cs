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

    public class UserRepository : BaseRepository<AspNetUser, string>, IUserRepository
    {
        public UserRepository(Entities context) : base(context)
        {
        }

        public async Task<AspNetUser> FindByUsernameAsync(string userName)
        {
            return await new Task<AspNetUser>(() => FindByUsername(userName));
        }

        public new AspNetUser FindById(string id)
        {
            return Context.AspNetUsers.AsNoTracking().SingleOrDefault(o => o.Id == id);
        }

        public AspNetUser FindByUsername(string userName)
        {
            return Context.AspNetUsers.AsNoTracking().SingleOrDefault(o => o.UserName == userName.ToString());
        }

        public List<AspNetUser> FindUsers()
        {
            return Context.AspNetUsers.AsNoTracking().ToList();
        }

        public bool IsInRole(string role, string id)
        {
            return FindById(id).AspNetRoles.Any(r =>  r.Name == role);
        }

        public bool IsInRole(AspNetRole role, string id)
        {
            return FindById(id).AspNetRoles.Any(r =>  r.Name == role.Name);
        }
    }
}
