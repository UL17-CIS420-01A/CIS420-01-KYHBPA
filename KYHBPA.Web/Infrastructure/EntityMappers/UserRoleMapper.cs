using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using KYHBPA.Entity;

namespace KYHBPA.EntityMappers
{
    public class UserRoleMapper : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMapper()
        {
            ToTable("UserRoles", "Identity");

            HasKey(c => new { c.RoleId, c.UserId });
            HasRequired(c => c.Role).WithMany(o => o.Users).WillCascadeOnDelete(true);
            HasRequired(c => c.User).WithMany(o => o.Roles).WillCascadeOnDelete(true);
        }
    }
}