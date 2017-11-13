using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Please enter a valid password", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Your passwords don't match!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Children Age Range(s)")]
        public int KidAgeRanges { get; set; }

        [Required]
        [Display(Name = "Number of Children")]
        public int NumberOfKids { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "City, State")]
        public string CityState { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Play Spots")]
        public int PlaySpots { get; set; }
    }
}
