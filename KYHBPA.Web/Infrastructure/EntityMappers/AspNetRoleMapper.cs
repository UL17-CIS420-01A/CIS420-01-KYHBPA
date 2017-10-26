using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using KYHBPA.Entity;

namespace KYHBPA.EntityMappers
{
    public class AspNetRoleMapper : EntityTypeConfiguration<AspNetRole>
    {
        public AspNetRoleMapper()
        {
            ToTable("Roles", "Identity");

            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}