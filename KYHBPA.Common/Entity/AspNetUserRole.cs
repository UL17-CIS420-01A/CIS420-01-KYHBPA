using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;

namespace KYHBPA.Entity
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;

    public partial class AspNetUserRole : IdentityUserRole<Guid>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUserRole()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
            this.AspNetRoles = new HashSet<AspNetRole>();
        }

        [Key, Required]
        [Column(Order = 0)]
        [ForeignKey(nameof(AspNetRoles))]
        public override Guid RoleId { get; set; }
        [Key, Required]
        [Column(Order = 1)]
        [ForeignKey(nameof(ApplicationUsers))]
        public override Guid UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
