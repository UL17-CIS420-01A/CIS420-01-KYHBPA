using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYHBPA.Data.Entity;

namespace KYHBPA.Data.Repository
{
    public class UserRepository
    {
        public AspNetUser GetUser(Guid userId)
        {
            using (var context = new KYHBPAEntities())
            {
                var user = context.AspNetUsers.AsNoTracking().Where(o => o.Id == userId.ToString()).FirstOrDefault();
                return user;
            }
        }
        public AspNetUser GetUser(string userName)
        {
            using (var context = new KYHBPAEntities())
            {
                var user = context.AspNetUsers.AsNoTracking().Where(o => o.UserName == userName.ToString()).FirstOrDefault();
                return user;
            }
        }

        public List<AspNetUser> GetUsers()
        {
            using (var context = new KYHBPAEntities())
            {
                var users = context.AspNetUsers.AsNoTracking();
                return users.ToList();
            }
        }
        public bool IsInRole(string role, Guid userId)
        {
            return GetUsers().Any(u => u.AspNetRoles.Any(r => r.Name == role));
        }
    }
}
