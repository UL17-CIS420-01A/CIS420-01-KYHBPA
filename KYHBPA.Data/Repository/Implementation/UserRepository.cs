namespace KYHBPA.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KYHBPA.Data.Entity;
    using KYHBPA.Data.Infrastructure;

    public class UserRepository : IUserRepository
    {
        public AspNetUser FindUser(Guid userId)
        {
            using (var context = new Entities())
            {
                var user = context.AspNetUsers.AsNoTracking().FirstOrDefault(o => o.Id == userId.ToString());
                return user;
            }
        }

        public AspNetUser FindUser(string userName)
        {
            using (var context = new Entities())
            {
                var user = context.AspNetUsers.AsNoTracking().FirstOrDefault(o => o.UserName == userName.ToString());
                return user;
            }
        }

        public List<AspNetUser> FindUsers()
        {
            using (var context = new Entities())
            {
                var users = context.AspNetUsers.AsNoTracking();
                return users.ToList();
            }
        }

        public bool IsInRole(string role, Guid userId)
        {
            return FindUsers().Any(u => u.AspNetRoles.Any(r => r.Name == role));
        }
    }
}
