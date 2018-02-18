using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// using WeddingPlanner.Validators; // PastDate

namespace WeddingPlanner.Models
{
    // NEW USER CREATION
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [Display(Name="First Name")]
        [MinLength(2, ErrorMessage="First Name must be 2 or more characters")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName {get;set;}
        [Required]
        [Display(Name="Last Name")]
        [MinLength(2, ErrorMessage="Last Name must be 2 or more characters")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName {get;set;}
        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public List<RSVP> WeddingsRSVPd {get;set;}
        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            WeddingsRSVPd = new List<RSVP>();
        }
    }
    public class NewUser : User
    {
        [Required]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string Confirm {get;set;}
    }

    // LOGIN AND REGISTRATION
    public class RegisterUser
    {
        [Display(Name="First Name")]
        [Required(ErrorMessage="First Name is required.")]
        [MinLength(2, ErrorMessage="First Name must be 2 or more characters.")]
        public string FirstName {get;set;}
        [Display(Name="Last Name")]
        [Required(ErrorMessage="Last Name is required.")]
        [MinLength(2, ErrorMessage="Last Name must be 2 or more characters.")]
        public string LastName {get;set;}
        [Display(Name="Email")]
        [Required(ErrorMessage="Email is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Email is invalid.")]
        public string Email {get;set;}
        [Display(Name="Password")]
        [Required(ErrorMessage="Password is required.")]
        [MinLength(8, ErrorMessage="Password must be 8 or more characters.")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [Display(Name="Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Passwords didn't match!")]
        public string Confirm {get;set;}
    }
    public class LoginUser
    {
        [Display(Name="Email")]
        [Required(ErrorMessage="Email is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Email is invalid.")]
        public string LoginEmail {get;set;}
        [Display(Name="Password")]
        [Required(ErrorMessage="Password is required.")]
        [MinLength(8, ErrorMessage="Password must be 8 or more characters.")]
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}
    }
}