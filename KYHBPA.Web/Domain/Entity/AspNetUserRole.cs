using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYHBPA.Entity
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;

    [Table("UserRoles", Schema = "Identity")]
    public partial class AspNetUserRole : IdentityUserRole<Guid>
    {
        public AspNetUserRole()
        {
            //this.User = new HashSet<ApplicationUser>();
            //this.Role = new HashSet<AspNetRole>();
        }

        [Key, Required]
        [Column(Order = 0)]
        [ForeignKey(nameof(Role))]
        public override Guid RoleId { get; set; }

        [Key, Required]
        [Column(Order = 1)]
        [ForeignKey(nameof(User))]
        public override Guid UserId { get; set; }

        [InverseProperty("Roles")]
        public ApplicationUser User { get; set; }

        [InverseProperty("Users")]
        public AspNetRole Role { get; set; }
    }
}
