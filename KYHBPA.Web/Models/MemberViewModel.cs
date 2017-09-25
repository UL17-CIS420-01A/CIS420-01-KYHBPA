using System;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Web.Models
{
    public class Member
    {
        [Required]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [RegularExpression(@"[\w' -]+")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name Required")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression(@"[\w' -]+")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        //[Display(Name = "")]
        [Display(AutoGenerateField = false)]
        public DateTime MembershipEnrollment { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "Phone Number")]
        [Phone]
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

        //[Required(AllowEmptyStrings = false, ErrorMessage = " Required")]
        [Display(Name = "KRC License Number")]
        public string LicenseNumber { get; set; }

        public bool isOwner { get; set; }

        public bool isTrainer { get; set; }

        public bool isOwnerAndTrainer { get; set; }

        [Required]
        [IsTrue(ErrorMessage = "You must agree to the Terms of Service.")]
        [Display(Name = "By checking this, you agree to the Terms of Service of the Kentucky Horseman's Benevolent and Protective Association.")]
        public bool AgreedToTerms { get; set; }

        [Display(Name = "By checking this, you confirm that all information provided is correct.")]
        [Compare("FullName", ErrorMessage = "Your signature must match your first and last name.")]
        public string Signature { get; set; }

        [Display(Name = "Full Name")]
        public virtual string FullName => $"{FirstName} {LastName}";
    }
}
