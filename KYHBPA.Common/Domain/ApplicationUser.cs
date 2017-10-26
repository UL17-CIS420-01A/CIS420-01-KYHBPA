using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Security.Claims;
using System.Threading.Tasks;
using KYHBPA.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KYHBPA
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    [Table("Users")]
    public class ApplicationUser : IdentityUser<Guid, AspNetUserLogin, AspNetUserRole, AspNetUserClaim>, IUser<Guid>
    {
        //
        // Summary:
        //     Constructor which creates a new Guid for the Id
        //public IdentityUser();
        //
        // Summary:
        //     Constructor that takes a userName
        //
        // Parameters:
        //   userName:
        //public IdentityUser(string userName);x

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        [Required]
        public Member Member { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApplicationUser()
        {
            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();
            this.UserRoles = new HashSet<AspNetUserRole>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [NotMapped]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [NotMapped]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [NotMapped]
        public virtual ICollection<AspNetUserRole> UserRoles { get; set; }
    }
}