using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA
{
    public class Member
    {
        [Required]
        public int Id { get; set; }

        [RegularExpression(@"[\w' -]+")]
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression(@"[\w' -]+")]
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth Required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? MembershipEnrollment { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City Required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State Required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip Code Required")]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "KRC License Number Required")]
        [Display(Name = "KRC License Number")]
        public string LicenseNumber { get; set; }

        public bool isOwner { get; set; }

        public bool isTrainer { get; set; }

        [Required]
        [IsTrue(ErrorMessage = "You must agree to the Terms of Service.")]
        [Display(Name = "Agree to Terms", Description = "By checking this, you agree to the Terms of Service of the Kentucky Horseman's Benevolent and Protective Association.")]
        public bool AgreedToTerms { get; set; }

        [Display(Name = "Signature")]
        [Description(description: "By checking this, you confirm that all information provided is correct.")]
        [Compare("FullName", ErrorMessage = "Your signature must match your first and last name.")]
        public string Signature { get; set; }

        [Display(Name = "Full Name")]
        public virtual string FullName => $"{FirstName} {LastName}";
    }
}