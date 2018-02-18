using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{
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
        // [Display(Name="Age")]
        // [Required(ErrorMessage="Age is required.")]
        // [Range(0, Int32.MaxValue, ErrorMessage="Age must be a positive number.")]
        // public int Age {get;set;}
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
    
    public class LogRegBundle
    {
        public RegisterUser Register {get;set;}
        public LoginUser Login {get;set;}
    }

}