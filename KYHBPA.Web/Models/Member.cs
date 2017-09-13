using System;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Web.Models
{
    public class Member
    {
        public int Id { get; set; }

        [RegularExpression(@"\w+")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression(@"\w+")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "")]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "")]
        public DateTime MembershipEnrollment { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City Required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "State Required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Zip Code Required")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "KRC License Number")]
        public string LicenseNumber { get; set; }

        public bool isOwner { get; set; }

        public bool isTrainer { get; set; }

        public bool isOwnerAndTrainer { get; set; }

        public bool AgreedToTerms { get; set; }

        public string Signature { get; set; }

        [Display(Name = "Full Name")]
        public virtual string FullName => $"{FirstName} {LastName}";
    }
}