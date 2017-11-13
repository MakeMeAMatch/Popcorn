using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class User
    {
        public int Id { get; set; }

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
        public string[] KidAgeRanges { get; set; }

        [Required]
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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Play Spots")]
        public string[] PlaySpots { get; set; }

    }
}
